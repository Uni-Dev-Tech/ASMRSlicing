using Game.Configs;
using System.Collections;
using UnityEngine;

namespace Game
{
    public class CuttedObject : MonoBehaviour
    {
        private Rigidbody _rb;

        public void AddPhysics()
        {
            _rb = this.gameObject.AddComponent<Rigidbody>();
            _rb.isKinematic = true;
        }

        public void ActivateAndPushPhysics()
        {
            if (_rb != null)
            {
                CuttableConfig config = GameConfig.Instance.CuttableConfig;

                _rb.isKinematic = false;
                _rb.AddForce(config.PushDirection * config.PushForce, config.PushForceMode);
            }

            StartCoroutine(SelfDestroy());
        }

        private IEnumerator SelfDestroy()
        {
            yield return new WaitForSeconds(GameConfig.Instance.CuttableConfig.LifeDuration);

            Destroy(this.gameObject);
        }
    }
}