using System.Collections.Generic;
using UnityEngine;

namespace Tower.Bullets
{
    public class BulletPoolManager : MonoBehaviour, IObjectPool, IReturnPool
    {
        [SerializeField] private int poolSize; 
        [SerializeField] private GameObject[] bulletPrefabs; 
        private Dictionary<string, Queue<GameObject>> _bulletPools = new Dictionary<string, Queue<GameObject>>();

        void Start()
        {
            for (int i = 0; i < bulletPrefabs.Length; i++)
            {
                if (bulletPrefabs[i] == null)
                {
                    Debug.LogError($"El prefab de bala en la posición {i} es nulo.");
                    continue;
                }

                Queue<GameObject> bulletQueue = new Queue<GameObject>();
                for (int j = 0; j < poolSize; j++)
                {
                    GameObject bullet = Instantiate(bulletPrefabs[i], transform.position, Quaternion.identity);
                    bullet.SetActive(false);
                    bulletQueue.Enqueue(bullet);
                }
                _bulletPools.Add(bulletPrefabs[i].name, bulletQueue);
            }
        }

        public GameObject GetObject(string bulletType)
        {
            if (_bulletPools.ContainsKey(bulletType) && _bulletPools[bulletType].Count > 0)
            {
                GameObject bullet = _bulletPools[bulletType].Dequeue();
                Debug.Log($"Obteniendo bala del pool: {bulletType}");

                Bullet bulletComponent = bullet.GetComponent<Bullet>();
                if (bulletComponent != null)
                {
                    bulletComponent.Initialize(this, bulletType);  
                }
                else
                {
                    Debug.LogError($"La bala {bulletType} no tiene un componente Bullet.");
                }

                bullet.SetActive(true);
                return bullet;
            }

            Debug.LogWarning($"No hay balas disponibles para el tipo {bulletType}. Considera aumentar el tamaño del pool.");
            return null;
        }

        public void ReturnObject(GameObject obj, string bulletType)
        {
            if (obj == null)
            {
                Debug.LogError("El objeto a devolver es nulo.");
                return;
            }

            if (_bulletPools.ContainsKey(bulletType))
            {
                obj.SetActive(false);
                _bulletPools[bulletType].Enqueue(obj);
            }
            else
            {
                Debug.LogError($"El tipo de bala {bulletType} no existe en el pool.");
            }
        }
    }
}