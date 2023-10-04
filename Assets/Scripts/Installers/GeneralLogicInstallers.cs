using Zenject;
using Game.SM;
using UnityEngine;

namespace Game
{
    public class GeneralLogicInstallers : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallController<LevelSMController>();
            InstallController<PlayerSMController>();
            InstallController<UISMController>();
        }

        private void InstallController<T>() where T : MonoBehaviour
        {
            var controller = new GameObject();
            controller.transform.parent = this.transform;
            controller.name = typeof(T).Name;
            var instance = controller.AddComponent<T>();

            Container.Bind<T>().FromInstance(instance).AsSingle().NonLazy();
        }
    }
}