using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Game.UI
{
    [RequireComponent(typeof(Button))]
    public abstract class BaseClickReceiver : MonoBehaviour
    {
        [SerializeField, HideInInspector] private Button _clickReceiver;

        private void Reset() => _clickReceiver = this.GetComponent<Button>();

        public void Sub(UnityAction action) => _clickReceiver.onClick.AddListener(action);
        public void Unsub(UnityAction action) => _clickReceiver.onClick.RemoveListener(action);
    }
}