using UnityEngine;
using Game.Events;
using UnityEngine.SceneManagement;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        private void OnEnable()
        {
            EventHolder<GameEvents.OnNextLevel>.AddListener(OnNextLevel, false);
        }

        private void Start()
        {
            Application.targetFrameRate = Screen.currentResolution.refreshRate;
        }

        private void OnDisable()
        {
            EventHolder<GameEvents.OnNextLevel>.RemoveListener(OnNextLevel);
        }

        private void OnNextLevel(GameEvents.OnNextLevel action)
            => SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}