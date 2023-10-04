namespace Game.MVC
{
    public interface IInitiable<T>
    {
        void Init(T model);
    }
}