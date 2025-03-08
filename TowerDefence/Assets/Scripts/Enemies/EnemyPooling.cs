using System.Collections.Generic;
using UnityEngine;
namespace Tower.Enemy
{
    public class EnemyPooling : MonoBehaviour, IObjectPool, IReturnPool
    {
        [SerializeField] private int poolSize;
        [SerializeField] private EnemyLife[] enemisPrefabs;
        private Queue<GameObject> _enemyPool = new Queue<GameObject>();

        private void Start()
        {
            for (int index = 0; index <= poolSize; index++)
            {
                GameObject currentEnemy = Instantiate(enemisPrefabs[Random.Range(0, enemisPrefabs.Length -1)].gameObject, transform.position, Quaternion.identity);
                currentEnemy.transform.SetParent(transform);
                currentEnemy.SetActive(false);
                _enemyPool.Enqueue(currentEnemy);
            }
        }

        private void OnEnable()
        {
            EnemyLife.Ondeath += ReturnObject;
        }

        private void OnDisable()
        {
            EnemyLife.Ondeath -= ReturnObject;
        }

        public GameObject GetObject()
        {
            if (_enemyPool.Count > 0)
            {
                GameObject enemy = _enemyPool.Dequeue();
                enemy.SetActive(true);
                return enemy;
            }

            GameObject newEnemy = Instantiate(enemisPrefabs[Random.Range(0, enemisPrefabs.Length - 1)].gameObject, transform.position, Quaternion.identity);
            newEnemy.transform.SetParent(transform);
            return newEnemy;
        }

        public void ReturnObject(GameObject obj)
        {
            _enemyPool.Enqueue(obj);
            obj.transform.position = transform.position;
        }
    }
}
