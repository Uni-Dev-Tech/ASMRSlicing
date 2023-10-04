using System;

namespace Game.UI.Menu
{
    public class MenuUIModel : BaseUIModel
    {
        public event Action OnPlayClick;

        public void CallPlayClickEvent() => OnPlayClick?.Invoke();
    }
}