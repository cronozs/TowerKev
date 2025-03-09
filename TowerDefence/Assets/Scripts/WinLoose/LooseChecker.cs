using UnityEngine;
using TMPro;

namespace Tower.Condition
{
    public class LooseChecker : MonoBehaviour
    {
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
            
        }
    }
}
