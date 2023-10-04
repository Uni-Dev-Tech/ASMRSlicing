using System;
using UnityEngine;

namespace Game
{
    public class CustomMeshHandler
    {
        public Vector3 GetEdgeForwardPoint(MeshFilter meshFilter)
        {
            try
            {
                Vector3[] vertices = meshFilter.mesh.vertices;

                var edgePoint = meshFilter.transform.TransformPoint(vertices[0]);
                for (int i = 1; i < vertices.Length; i++)
                {
                    var comp = meshFilter.transform.TransformPoint(vertices[i]);
                    if (comp.z < edgePoint.z) edgePoint = comp;
                }

                return edgePoint;
            }
            catch (Exception e) { throw new NullReferenceException("Null verticles!"); }
        }

        public Vector3 GetEdgeBackwardPoint(MeshFilter meshFilter)
        {
            try
            {
                Vector3[] vertices = meshFilter.mesh.vertices;

                var edgePoint = meshFilter.transform.TransformPoint(vertices[0]);
                for (int i = 1; i < vertices.Length; i++)
                {
                    var comp = meshFilter.transform.TransformPoint(vertices[i]);
                    if (comp.z > edgePoint.z) edgePoint = comp;
                }

                return edgePoint;
            }
            catch (Exception e) { throw new NullReferenceException("Null verticles!"); }
        }
    }
}