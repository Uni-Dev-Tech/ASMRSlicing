using Game.MVC;

namespace Game.Entity
{
    namespace Cuttable { public abstract class CuttableView : Initiable<CuttableModel, CuttableController> { } }
    namespace Cutting { public abstract class CuttingView : Initiable<CuttingModel, CuttingController> { } }
}

namespace Game.UI
{
    public abstract class UIVIew<T, K> : Initiable<T, K>
        where T : BaseUIModel where K : BaseUIController<T> { }

    namespace Menu { public abstract class MenuUIView : UIVIew<MenuUIModel, MenuUIController> { } }
    namespace InGame { public abstract class InGameView : UIVIew<InGameModel, InGameUIController> { } }
    namespace Complete { public abstract class CompleteUIView : UIVIew<CompleteUIModel, CompleteUIController> { } }
}