using UnityEngine;

namespace Game.Configs 
{
    [CreateAssetMenu(fileName = "Game Configs", menuName = "Configs/Game Configs")]
    public class GameConfig : SingletonScriptableObject<GameConfig>
    {
        [field: SerializeField] public CuttingConfig CuttingConfig { get; private set; }
        [field: SerializeField] public CuttableConfig CuttableConfig { get; private set; }
        [field: SerializeField] public GeneralConfig GeneralConfig { get; private set; }
    }
}