using UnityEngine;

namespace Game.Configs
{
    [CreateAssetMenu(fileName = "GeneralConfig", menuName = "Configs/GeneralConfig")]
    public class GeneralConfig : ScriptableObject
    {
        [field: SerializeField, Range(0f, 100f), Header("Accuracy")] 
        public float AccuracyPercenage { get; private set; }
    }
}