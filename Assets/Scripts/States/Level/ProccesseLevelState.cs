using Game.Events;
using Game.Configs;
using UnityEngine;

namespace Game.SM
{
    public class ProccesseLevelState : BaseLevelState
    {
        public ProccesseLevelState(LevelSMController controller) : base(controller) { }

        private Timer _timer;

        public override void Enter()
        {
            base.Enter();

            EventHolder<LevelEvents.OnLevelStarted>.CallEvent(new LevelEvents.OnLevelStarted());

            EventHolder<LevelEvents.OnCuttingStarted>.AddListener(OnCuttingStarted, false);
            EventHolder<LevelEvents.OnCuttingOver>.AddListener(OnCuttingOver, false);

            _timer = new Timer(GameConfig.Instance.CuttingConfig.MaxCuttingDelay);
            _timer.OnTimeAlarm += OnTimeAlarm;
            _timer.Activate();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            _timer.Update(Time.deltaTime);
        }

        public override void Exit()
        {
            base.Exit();

            EventHolder<LevelEvents.OnCuttingStarted>.RemoveListener(OnCuttingStarted);
            EventHolder<LevelEvents.OnCuttingOver>.RemoveListener(OnCuttingOver);

            _timer.OnTimeAlarm -= OnTimeAlarm;
        }

        private void OnTimeAlarm()
        {
            _timer.Deactivate();

            EventHolder<LevelEvents.OnCuttingRequest>.CallEvent(new LevelEvents.OnCuttingRequest());
        }

        private void OnCuttingStarted(LevelEvents.OnCuttingStarted action)
        {
            _timer.Reset();
            _timer.Deactivate();
        }

        private void OnCuttingOver(LevelEvents.OnCuttingOver action)
        {
            _timer.Activate();
        }
    }
}