namespace Game.SM
{
    public class LevelStateBundles : StatesBundle<BaseLevelState, LevelType>
    {
        public LevelStateBundles(BaseLevelState state, LevelType type) : base(state, type) { }
    }

    public class PlayerStateBundles : StatesBundle<BasePlayerState, PlayerType>
    {
        public PlayerStateBundles(BasePlayerState state, PlayerType type) : base(state, type) { }
    }

    public class UIStateBundles : StatesBundle<BaseUIState, UIType>
    {
        public UIStateBundles(BaseUIState state, UIType type) : base(state, type) { }
    }

    public abstract class StatesBundle<T, K> where T : BaseState
    {
        public T State { get; private set; }
        public K Type { get; private set; }

        public StatesBundle(T state, K type) { State = state; Type = type; }
    }
}