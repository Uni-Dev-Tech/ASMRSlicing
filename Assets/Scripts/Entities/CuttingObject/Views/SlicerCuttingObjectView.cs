using UnityEngine;
using Game.Entity.Cuttable;

namespace Game.Entity.Cutting
{
    [RequireComponent(typeof(BoxCollider), typeof(Rigidbody))]
    public class SlicerCuttingObjectView : CuttingView
    {
        [SerializeField] private Cutter _cutter;
        [SerializeField, HideInInspector] private BoxCollider _boxScale;

        private void Reset()
        {
            _boxScale = this.GetComponent<BoxCollider>();
            _boxScale.isTrigger = true;

            var rb = this.GetComponent<Rigidbody>();
            rb.isKinematic = true;
            rb.useGravity = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (Model.IsCutting || !Model.IsMovingDown) return;

            bool isCuttable = other.TryGetComponent(out CuttableObject obj);
            if (isCuttable)
            {
                var cuttingResult = _cutter.Cut();

                if (cuttingResult != null) Model.CallCuttingStartEvent((CuttingResult)cuttingResult);
                else Debug.LogWarning("Cutting result is null!");
            }
        }
    }
}