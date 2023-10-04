namespace Game.Entity.Cutting
{
    public class CuttedRigidbodyHandlerView : CuttingView
    {
        private CuttedObject _cuttedObject;

        protected override void OnInitedEnable()
        {
            base.OnInitedEnable();

            Model.OnCuttingStarted += OnCuttingStarted;
            Model.OnCuttedOff += OnCuttedOff;
        }

        protected override void OnInitedDisable()
        {
            base.OnInitedDisable();

            Model.OnCuttingStarted -= OnCuttingStarted;
            Model.OnCuttedOff -= OnCuttedOff;
        }

        private void OnCuttingStarted(CuttingResult cuttingResult)
        {
            _cuttedObject = cuttingResult.CuttedObject;
            _cuttedObject.AddPhysics();
        }

        private void OnCuttedOff() => _cuttedObject?.ActivateAndPushPhysics();
    }
}