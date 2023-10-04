using Deform;
using UnityEngine;
using Game.Configs;
using System.Collections.Generic;

namespace Game.Entity.Cutting
{
    public class CuttedMeshHandlerView : CuttingView
    {
        private TwirlDeformer _twirlDeformer;

        protected override void OnInitedEnable()
        {
            base.OnInitedEnable();

            Model.OnCuttingStarted += OnCuttingStarted;
            Model.OnCuttingProcessUpdate += OnCuttingProcessUpdate;
        }

        protected override void OnInitedDisable()
        {
            base.OnInitedDisable();

            Model.OnCuttingStarted -= OnCuttingStarted;
            Model.OnCuttingProcessUpdate -= OnCuttingProcessUpdate;
        }

        private void OnCuttingStarted(CuttingResult cuttingResult)
        {
            var deformables = new List<Deformable>(cuttingResult.CuttedPieces.Count);
            cuttingResult.CuttedPieces.ForEach(x => deformables.Add(x.gameObject.AddComponent<Deformable>()));

            var twirl = new GameObject("Twirl");
            twirl.transform.parent = cuttingResult.CuttedObject.transform;
            twirl.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);

            _twirlDeformer = twirl.AddComponent<TwirlDeformer>();
            _twirlDeformer.Mode = BoundsMode.Unlimited;

            CuttableConfig config = GameConfig.Instance.CuttableConfig;
            twirl.transform.rotation = Quaternion.Euler(config.TwirlRotation);
            _twirlDeformer.Angle = cuttingResult.Angel;
            _twirlDeformer.Factor = 0;

            deformables.ForEach(x => x.AddDeformer(_twirlDeformer));
        }

        private void OnCuttingProcessUpdate(float percent)
        {
            if (_twirlDeformer == null) return;

            float speed = GameConfig.Instance.CuttableConfig.TwirlSpeed;
            _twirlDeformer.Factor = Mathf.Lerp(_twirlDeformer.Factor, percent / 100, Time.deltaTime * speed);
        }
    }
}