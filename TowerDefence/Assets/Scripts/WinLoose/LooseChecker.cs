using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
namespace Tower.Condition
{
    public class LooseChecker : MonoBehaviour
    {
        [SerializeField] private Canvas losseCanvas;
        private void OnEnable()
        {
            PlayerLife.PlayerOnnDeath += ActiveCanvas;
        }

        private void OnDisable()
        {
            PlayerLife.PlayerOnnDeath -= ActiveCanvas;
        }

        private void ActiveCanvas()
        {
            losseCanvas.enabled = true;
            Time.timeScale = 0;
        }

        public void Reload()
        {
            SceneManager.LoadScene(0);
        }
    }
}
