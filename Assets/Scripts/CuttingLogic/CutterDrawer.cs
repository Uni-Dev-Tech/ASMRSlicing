using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class CutterDrawer : MonoBehaviour
    {
        [Header("Line renderer points settings")]
        [SerializeField] private LayerMask _layers;
        [SerializeField, Range(1, 10)] private float _range;
        [SerializeField, Range(0.1f, 1f)] private float _per;

        [Header("Line renderer drawing settings")]
        [SerializeField] private LineRenderer lineRenderer;
        [SerializeField] private float _lineMotionSpeed;

        private List<Vector3> _linePoints = new List<Vector3>();

        private void LateUpdate()
        {
            if (lineRenderer == null) return;

            _linePoints.Clear();

            var point = -_range;

            do
            {
                Ray ray = new Ray(this.transform.position + Vector3.right * point, Vector3.down);

                point += _per;

                bool isCatched = Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _layers);
                if (isCatched) _linePoints.Add(hit.point);

            } while (point < _range);

            lineRenderer.positionCount = _linePoints.Count;
            lineRenderer.SetPositions(_linePoints.ToArray());

            float offsetX = Mathf.Cos(Time.time) * _lineMotionSpeed;
            float offsetY = Mathf.Sin(Time.time) * _lineMotionSpeed;
            lineRenderer.sharedMaterial.mainTextureOffset = new Vector2(offsetX, offsetY);
        }

        public void Activate() => this.gameObject.SetActive(true);
        public void Deactivate() => this.gameObject.SetActive(false);
    }
}