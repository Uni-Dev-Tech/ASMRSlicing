using Zenject;
using Game.MVC;
using UnityEngine;

namespace Game
{
    public abstract class BaseMVCInstaller<T, A, B> : MonoInstaller where T : BaseController<A> where
        A : BaseModel where B : IInitiable<A>
    {
        [SerializeField, HideInInspector] private T _instance;

        private void Reset() => _instance = this.GetComponent<T>();

        public override void InstallBindings() => Container.Bind<T>().FromInstance(_instance).NonLazy();
    }
}