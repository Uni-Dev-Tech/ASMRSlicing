using Game.UI.Menu;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(MenuUIController))]
    public class MenuUIInstaller : BaseMVCInstaller<MenuUIController, MenuUIModel, MenuUIView> { }
}