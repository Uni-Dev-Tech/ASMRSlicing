using Game.MVC;

namespace Game.UI.InGame
{
    public class InGameUIController : BaseUIController<InGameModel>
    {
        protected override void PreInit()
        {
            model = new InGameModel();
        }

        public override void InitView(IInitiable<InGameModel> view)
        {
            if (model == null) model = new InGameModel();

            view.Init(model);
            views.Add(view);
        }

        public void SetProgressPercent(float percentage) => model.CallProgressSetEvent(percentage);

        public void ActivateTutorial() => model.CallTutorialActivationEvent();
        public void DeactivateTutorial() => model.CallTutotialDeactivationEvent();
    }
}