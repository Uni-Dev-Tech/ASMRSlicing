using Game.UI.Complete;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(CompleteUIInstaller))]
    public class CompleteUIInstaller : BaseMVCInstaller<CompleteUIController, CompleteUIModel, CompleteUIView> { }
}