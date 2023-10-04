using Zenject;
using UnityEngine;

namespace Game
{
    public class GameManagerInstaller : MonoInstaller
    {
        [SerializeField, HideInInspector] private GameManager _instance;

        private void Reset() => _instance = this.GetComponent<GameManager>();

        public override void InstallBindings()
            => Container.Bind<GameManager>().FromInstance(_instance).NonLazy();
    }
}