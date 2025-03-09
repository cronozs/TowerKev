using UnityEngine;
using TMPro;
using Tower.Enemy;
namespace Tower
{
    public class WinChecker : MonoBehaviour
    {
        private int kills = 0;
        [SerializeField] private Canvas winCanvas;
        private void OnEnable()
        {
            EnemyLife.Ondeath += kilCounter; 
        }

        private void kilCounter(GameObject obj)
        {
            kills += 1;
            if(kills >= 30)
            {
                winCanvas.enabled = true;
                Time.timeScale = 0;
            }
        }
    }
}
