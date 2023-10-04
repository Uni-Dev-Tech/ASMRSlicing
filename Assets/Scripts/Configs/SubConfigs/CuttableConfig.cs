using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;

namespace Game.Configs
{
    [CreateAssetMenu(fileName = "CuttableConfig", menuName = "Configs/CuttableConfig")]
    public class CuttableConfig : ScriptableObject
    {
        [field: FoldoutGroup("Motion"), SerializeField, Header("Unit metr per seconds")] 
        public float MotionDuration { get; private set; }
        [field: FoldoutGroup("Motion"), SerializeField] public float MotionDelay { get; private set; }
        [field: FoldoutGroup("Motion"), SerializeField] public Ease MotionEase { get; private set; }

        [field: FoldoutGroup("Cut off physics"), SerializeField]
        public Vector3 PushDirection { get; private set; }
        [field: FoldoutGroup("Cut off physics"), SerializeField] public float PushForce { get; private set; }
        [field: FoldoutGroup("Cut off physics"), SerializeField] public ForceMode PushForceMode { get; private set; }

        [field: FoldoutGroup("Lifecycle"), SerializeField] public float LifeDuration { get; private set; }

        [field: FoldoutGroup("Twirl settings"), SerializeField]
        public Vector3 TwirlRotation { get; private set; }
        [field: FoldoutGroup("Twirl settings"), SerializeField]
        public float TwirlSpeed { get; private set; }
        [FoldoutGroup("Twirl settings"), SerializeField, MinMaxSlider(0, 180, true)]
        private Vector2 _twirlAngel;
        [FoldoutGroup("Twirl settings"), SerializeField, MinMaxSlider(0, 1f, true)]
        private Vector2 _twirlValue;

        public float GetTwirlAngel(float twirlValue)
        {
            float percentage = Mathf.InverseLerp(_twirlValue.x, _twirlValue.y, twirlValue);
            float twirlAngel = Mathf.Lerp(_twirlAngel.x, _twirlAngel.y, 1 - percentage);

            return twirlAngel;
        }
    }
}