using Zenject;
using Game.SM;
using UnityEngine;
using Game.UI.Menu;
using Game.UI.InGame;
using Game.UI.Complete;

namespace Game
{
    [RequireComponent(typeof(UISMController))]
    public class CanvasInstaller : MonoInstaller
    {
        [HideInInspector, SerializeField] private UISMController _canvas;

        [SerializeField] private MenuUIController _menu;
        [SerializeField] private InGameUIController _inGame;
        [SerializeField] private CompleteUIController _complete;

        private void Reset() => _canvas = this.GetComponent<UISMController>();

        public override void InstallBindings()
        {
            BindController(_menu);
            BindController(_inGame);
            BindController(_complete);
            BindController(_canvas);
        }

        private void BindController<T>(T controller)
            => Container.Bind<T>().FromInstance(controller).AsSingle().NonLazy();
    }
}