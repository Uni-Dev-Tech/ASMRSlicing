using Game.MVC;
using Game.Events;

namespace Game.UI.Menu
{
    public class MenuUIController : BaseUIController<MenuUIModel>
    {
        protected override void PreInit()
        {
            if (model == null) model = new MenuUIModel();
        }

        public override void InitView(IInitiable<MenuUIModel> view)
        {
            if (model == null) model = new MenuUIModel();

            view.Init(model);
            views.Add(view);
        }

        protected override void OnControllerEnable()
        {
            base.OnControllerEnable();

            model.OnPlayClick += OnPlayClick;
        }

        protected override void OnControllerDisable()
        {
            base.OnControllerDisable();

            model.OnPlayClick -= OnPlayClick;
        }

        private void OnPlayClick()
            => EventHolder<UIEvents.OnMenu.OnPlayClick>.CallEvent(new UIEvents.OnMenu.OnPlayClick());
    }
}