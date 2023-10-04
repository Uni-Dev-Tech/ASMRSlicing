using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;

namespace Game.Configs
{
    [CreateAssetMenu(fileName = "Cutting Config", menuName = "Configs/CuttingConfig")]
    public class CuttingConfig : ScriptableObject
    {
        [field: FoldoutGroup("General"), SerializeField]
        public LayerMask CuttableLayer { get; private set; }
        [field: FoldoutGroup("General"), SerializeField]
        public float MaxCuttingDelay { get; private set; }

        [field: FoldoutGroup("Cutting animation"), SerializeField]
        public float CuttingRange { get; private set; }
        [field: FoldoutGroup("Cutting animation"), SerializeField]
        public float MovingDownTime { get; private set; }
        [field: FoldoutGroup("Cutting animation"), SerializeField]
        public float MovingUpTime { get; private set; }
        [field: FoldoutGroup("Cutting animation"), SerializeField]
        public float CuttingObjetTime { get; private set; }
        [field: FoldoutGroup("Cutting animation"), SerializeField]
        public Ease CuttingEase { get; private set; }

        [field: FoldoutGroup("Complete animation"), SerializeField]
        public Vector3 CompleteOffset { get; private set; }
        [field: FoldoutGroup("Complete animation"), SerializeField]
        public float CompleteDuration { get; private set; }
        [field: FoldoutGroup("Complete animation"), SerializeField]
        public Ease CompleteEase { get; private set; }
    }
}