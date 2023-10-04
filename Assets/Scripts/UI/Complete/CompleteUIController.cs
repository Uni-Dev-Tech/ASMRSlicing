using Game.MVC;
using Game.Events;

namespace Game.UI.Complete
{
    public class CompleteUIController : BaseUIController<CompleteUIModel>
    {
        protected override void PreInit()
        {
            model = new CompleteUIModel();
        }

        public override void InitView(IInitiable<CompleteUIModel> view)
        {
            if (model == null) model = new CompleteUIModel();

            view.Init(model);
            views.Add(view);
        }

        protected override void OnControllerEnable()
        {
            base.OnControllerEnable();

            model.OnContinueClick += OnContinueClick;
        }

        protected override void OnControllerDisable()
        {
            base.OnControllerDisable();

            model.OnContinueClick -= OnContinueClick;
        }

        private void OnContinueClick()
            => EventHolder<UIEvents.OnComplete>.CallEvent(new UIEvents.OnComplete());
    }
}