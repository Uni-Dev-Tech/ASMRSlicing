using UnityEngine;
using DG.Tweening;
using Game.Configs;
using System;

namespace Game.Entity.Cutting
{
    public class MotionCuttingObjectView : CuttingView
    {
        [SerializeField] private MotionCuttingPoint _motionPoint;

        private float _defaultPos;
        private float _cuttingPercentLeft;
        private bool _isCutting;

        private Tween _cuttingTween;

        protected override void OnInitializing()
        {
            base.OnInitializing();

            _defaultPos = _motionPoint.GetTransform.position.y;
            _cuttingPercentLeft = 100;
            _isCutting = false;
        }

        protected override void OnInitedEnable()
        {
            base.OnInitedEnable();

            Model.OnMoveUp += OnMoveUp;
            Model.OnMoveDown += OnMoveDown;
            Model.OnCuttingOver += OnCuttingOver;
            Model.OnLevelCompleted += OnLevelCompleted;
        }

        protected override void OnInitedDisable()
        {
            base.OnInitedDisable();

            Model.OnMoveUp -= OnMoveUp;
            Model.OnMoveDown -= OnMoveDown;
            Model.OnCuttingOver -= OnCuttingOver;
            Model.OnLevelCompleted -= OnLevelCompleted;
        }

        private void OnMoveUp() => MotionUpAnimation(_defaultPos);

        private void OnMoveDown()
        {
            CuttingConfig config = GameConfig.Instance.CuttingConfig;
            MotionDownAnimation(_defaultPos - config.CuttingRange, config.MovingDownTime);
        }

        private void OnCuttingOver()
        {
            _cuttingPercentLeft = 100;
            _isCutting = false;

            MotionUpForced();
        }

        private void MotionUpAnimation(float target)
        {
            _cuttingTween?.Kill();

            var config = GameConfig.Instance.CuttingConfig;
            _isCutting = false;

            var current = _motionPoint.GetTransform.position.y;
            var distance = Mathf.Abs(target - current);
            var general = Mathf.Abs(_defaultPos -
                (_defaultPos - GameConfig.Instance.CuttingConfig.CuttingRange));
            var percent = (distance * 100) / general;
            var coef = percent / 100;
            var finalTime = config.MovingUpTime * coef;

            _cuttingTween =
                _motionPoint.GetTransform.DOMoveY(target, finalTime)
                .SetEase(config.CuttingEase)
                .OnComplete(Model.CallCuttinOverEvent);
        }

        private void MotionDownAnimation(float target, float time)
        {
            _cuttingTween?.Kill();

            var config = GameConfig.Instance.CuttingConfig;

            var current = _motionPoint.GetTransform.position.y;
            var distance = Mathf.Abs(target - current);
            var general = Mathf.Abs(_defaultPos - 
                (_defaultPos - GameConfig.Instance.CuttingConfig.CuttingRange));
            var percent = (distance * 100) / general;
            var coef = percent / 100;
            var finalTime = time * coef;

            Predicate<float> isUpdate = (percent) => percent < _cuttingPercentLeft;
            Func<float, float> percenage = (target) => CalculateCarrentPercenatage(target);

            _cuttingTween =
                _motionPoint.GetTransform.DOMoveY(target, finalTime)
                .SetEase(config.CuttingEase)
                .OnUpdate(() => OnUpdating(isUpdate, percenage, target))
                .OnComplete(Model.CallCuttinOverEvent);
        }

        private void MotionUpForced()
        {
            _cuttingTween?.Kill();

            var config = GameConfig.Instance.CuttingConfig;
            _isCutting = false;

            var current = _motionPoint.GetTransform.position.y;
            var distance = Mathf.Abs(_defaultPos - current);
            var general = Mathf.Abs(_defaultPos -
                (_defaultPos - GameConfig.Instance.CuttingConfig.CuttingRange));
            var percent = (distance * 100) / general;
            var coef = percent / 100;
            var finalTime = config.MovingUpTime * coef;

            _cuttingTween =
                _motionPoint.GetTransform.DOMoveY(_defaultPos, finalTime)
                .SetEase(config.CuttingEase)
                .OnComplete(Model.CallReleaseOverEvent);
        }

        private void OnLevelCompleted()
        {
            _cuttingTween?.Kill();

            CuttingConfig config = GameConfig.Instance.CuttingConfig;

            _cuttingTween =
                _motionPoint.GetTransform.DOMove(_motionPoint.GetTransform.position +
                config.CompleteOffset, config.CompleteDuration).SetEase(config.CompleteEase);
        }

        private void OnUpdating(Predicate<float> isUpdate, Func<float, float> percenage, float target)
        {
            if (!Model.IsCutting) return;

            var percent = percenage(target);
            if (_isCutting != isUpdate(percent))
            {
                CuttingConfig config = GameConfig.Instance.CuttingConfig;
                MotionDownAnimation(_defaultPos - config.CuttingRange, config.CuttingObjetTime);
            }

            _isCutting = isUpdate(percent);
            if (_isCutting)
            {
                _cuttingPercentLeft = percent;
                Model.CallCuttingProcessUpdateEvent(percent);
            }
        }

        private float CalculateCarrentPercenatage(float target)
        {
            var distance = Mathf.Abs(target -  _motionPoint.GetTransform.position.y);
            var general = Mathf.Abs(_defaultPos -
                (_defaultPos - GameConfig.Instance.CuttingConfig.CuttingRange));

            return (distance * 100) / general;
        }
    }
}