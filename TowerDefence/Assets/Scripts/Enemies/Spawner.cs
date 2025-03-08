using System.Collections;
using UnityEngine;

namespace Tower.Enemy
{
    public class Spawner : MonoBehaviour
    {
        private EnemyPooling _enemyPooling;
        [SerializeField] private float timeToSpawn;
        void Start()
        {
            _enemyPooling = GetComponent<EnemyPooling>();
            StartCoroutine(DelayToSpawn());
        }

        IEnumerator DelayToSpawn()
        {
            yield return new WaitForSeconds(timeToSpawn);
            GameObject currentEnemy =  _enemyPooling.GetObject();
            currentEnemy.SetActive(true);
            StartCoroutine(DelayToSpawn());
        }
    }
}
