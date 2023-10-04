using System;
using UnityEngine;
using DG.Tweening;
using Game.Configs;

namespace Game.Entity.Cuttable
{
    public class MotionCuttableObjectView : CuttableView
    {
        [SerializeField] private MotionCuttableObject _cuttableMotion;

        private Tween _motionTween;

        private float _finalZValue;
        private float _startZValue;

        protected override void OnInitializing()
        {
            base.OnInitializing();

            _startZValue = _cuttableMotion.GetTransform.position.z;
            _finalZValue = _cuttableMotion.GetTransform.position.z - Model.Data.TargetDistance;
        }

        protected override void OnInitedEnable()
        {
            base.OnInitedEnable();

            Model.OnMotionStart += OnMotionStart;
            Model.OnMotionStop += OnMotionStop;
        }

        protected override void OnInitedDisable()
        {
            base.OnInitedDisable();

            Model.OnMotionStart -= OnMotionStart;
            Model.OnMotionStop -= OnMotionStop;
        }

        private void OnMotionStart()
        {
            _motionTween?.Kill();

            var config = GameConfig.Instance.CuttableConfig;

            var currentDistanceLeft = Mathf.Abs(_cuttableMotion.GetTransform.position.z - _finalZValue);
            var time = currentDistanceLeft * GameConfig.Instance.CuttableConfig.MotionDuration;

            Func<float, float> percentage = (x) 
                => (x - _startZValue) / (_finalZValue - _startZValue) * 100f;

            _motionTween = _cuttableMotion.GetTransform.DOMoveZ(_finalZValue, time)
                .OnUpdate(() => 
                Model.CallProgressUpdateEvent(percentage(_cuttableMotion.GetTransform.position.z)))
                .SetDelay(config.MotionDelay)
                .SetEase(config.MotionEase);
        }

        private void OnMotionStop()
        {
            _motionTween?.Kill();
            _motionTween = null;
        }
    }
}