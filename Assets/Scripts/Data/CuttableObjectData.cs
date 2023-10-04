using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "CuttableObjectData", menuName = "Data/CuttableObjectData")]
    public class CuttableObjectData : ScriptableObject
    {
        [field: SerializeField] public float TargetDistance { get; private set; }
    }
}