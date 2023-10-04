using UnityEngine;
using UnityEngine.UI.ProceduralImage;

namespace Game.UI
{
    [RequireComponent(typeof(ProceduralImage))]
    public abstract class BaseProgressBar : MonoBehaviour
    {
        [SerializeField, HideInInspector] private ProceduralImage _progressBar;

        private void Reset() => _progressBar = this.GetComponent<ProceduralImage>();

        public void SetValue(float value) => _progressBar.fillAmount = value;
    }
}