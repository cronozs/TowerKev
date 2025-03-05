using System.Collections.Generic;
using UnityEngine;

namespace Tower.Tower
{
    [RequireComponent(typeof(TowerShooting))]
    public class TowerPoolingh : MonoBehaviour, IObjectPool
    {
        [SerializeField, Tooltip("tamaño del pool a la hora de crear la torre")] private int poolSize;
        [SerializeField, Tooltip("El prefab de la bala que usara la torre")] private GameObject bullet;
        private Queue<GameObject> _bulletPool = new Queue<GameObject>();


        void Start()
        {
            for (int index = 0; index <= poolSize; index++)
            {
                GameObject currentBullet = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
                currentBullet.transform.SetParent(transform);
                _bulletPool.Enqueue(currentBullet);
                currentBullet.SetActive(false);
            }
        }
        public GameObject GetObject()
        {
            if (_bulletPool.Count > 0)
            {
                GameObject bullet = _bulletPool.Dequeue();
                bullet.SetActive(true);
                return bullet;
            }
            return null;
        }

        public void ReturnObject(GameObject obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
