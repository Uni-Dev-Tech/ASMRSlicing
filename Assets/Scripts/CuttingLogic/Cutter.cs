using BLINDED_AM_ME.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using Game.Configs;

namespace Game
{
    public class Cutter : MonoBehaviour
	{
		[SerializeField] private Vector3 _boxScale;

        private (Transform, float) Cut(GameObject target, CancellationToken cancellationToken = default)
		{
			try
			{
				var leftSide = target;
				var leftMeshFilter = leftSide.GetComponent<MeshFilter>();
				var leftMeshRenderer = leftSide.GetComponent<MeshRenderer>();

				var materials = new List<Material>();
				leftMeshRenderer.GetSharedMaterials(materials);

				bool isMaterial = target.TryGetComponent(out MeshRenderer meshRenderer);
				if (!isMaterial) throw new NullReferenceException("Target object doesn`t have mesh rederer!");
				var material = meshRenderer.sharedMaterial;

				var capSubmeshIndex = 0;
				if (materials.Contains(material)) capSubmeshIndex = materials.IndexOf(material);
				else
				{
					capSubmeshIndex = materials.Count;
					materials.Add(material);
				}

				var blade = new Plane(
					leftSide.transform.InverseTransformDirection(transform.right),
					leftSide.transform.InverseTransformPoint(transform.position));

				var mesh = leftMeshFilter.sharedMesh;

				var pieces = mesh.Cut(blade, capSubmeshIndex);

				leftSide.name = "LeftSide";
				leftMeshFilter.mesh = pieces.Item1;
				leftMeshRenderer.sharedMaterials = materials.ToArray();

				var rightSide = new GameObject("RightSide");
				var rightMeshFilter = rightSide.AddComponent<MeshFilter>();
				var rightMeshRenderer = rightSide.AddComponent<MeshRenderer>();

				rightSide.transform.SetPositionAndRotation(leftSide.transform.position, leftSide.transform.rotation);
				rightSide.transform.localScale = leftSide.transform.localScale;

				rightMeshFilter.mesh = pieces.Item2;
				rightMeshRenderer.sharedMaterials = materials.ToArray();

				Destroy(leftSide.GetComponent<Collider>());

				var leftCollider = leftSide.AddComponent<MeshCollider>();
				leftCollider.convex = true;
				leftCollider.sharedMesh = pieces.Item1;

				CustomMeshHandler meshHandler = new CustomMeshHandler();
				Vector3 forwardEdge = meshHandler.GetEdgeForwardPoint(rightMeshFilter);
				Vector3 backwardEdge = meshHandler.GetEdgeBackwardPoint(rightMeshFilter);
				var distance = Mathf.Abs(forwardEdge.z - backwardEdge.z);

				return (rightSide.transform, distance);
			}
			catch (Exception ex) { Debug.LogError(ex); }

			return (null, 0f);
		}

		public CuttingResult? Cut()
        {
			var colls = 
				Physics.OverlapBox(this.transform.position, _boxScale / 2,
				this.transform.rotation, GameConfig.Instance.CuttingConfig.CuttableLayer).ToList();
			if (colls.Count == 0) return null;

			var obj = new GameObject("CuttedPart");
			var cuttedObj = obj.AddComponent<CuttedObject>();

			List<Transform> cutted = new(colls.Count);
			var longestDistance = 0f;
			colls.ForEach(x => 
			{
				(Transform point, float distance) = Cut(x.gameObject);
				cutted.Add(point);

				if (distance > longestDistance) longestDistance = distance;
			});

			var angel = GameConfig.Instance.CuttableConfig.GetTwirlAngel(longestDistance);

			obj.transform.position = colls[0].transform.position;
			cutted.ForEach(x => x.parent = obj.transform);

			var cuttedPieces = new List<CuttedPieces>(colls.Count);
			cutted.ForEach(x => cuttedPieces.Add(x.gameObject.AddComponent<CuttedPieces>()));
			
			return new CuttingResult(angel, cuttedObj, cuttedPieces);
		}

		private void OnDrawGizmos()
		{
			Color prevColor = Gizmos.color;
			Matrix4x4 prevMatrix = Gizmos.matrix;

			Gizmos.color = Color.red;
			Gizmos.matrix = this.transform.localToWorldMatrix;

			Vector3 pos = transform.InverseTransformPoint(this.transform.position);
			Gizmos.DrawWireCube(pos, _boxScale);

			Gizmos.color = prevColor;
			Gizmos.matrix = prevMatrix;
		}
	}
}
