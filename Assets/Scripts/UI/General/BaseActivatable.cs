using UnityEngine;

namespace Game.UI
{
    public abstract class BaseActivatable : MonoBehaviour
    {
        public void Activate() => this.gameObject.SetActive(true);
        public void Deactivate() => this.gameObject.SetActive(false);
    }
}