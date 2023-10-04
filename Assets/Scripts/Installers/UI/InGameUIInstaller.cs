using Game.UI.InGame;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(InGameUIController))]
    public class InGameUIInstaller : BaseMVCInstaller<InGameUIController, InGameModel, InGameView> { }
}