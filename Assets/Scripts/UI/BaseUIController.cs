using Game.MVC;

namespace Game.UI
{
    public abstract class BaseUIController<T> : BaseController<T> where T : BaseUIModel
    {
        public void Activate() => this.gameObject.SetActive(true);
        public void Deactivate() => this.gameObject.SetActive(false);
    }
}