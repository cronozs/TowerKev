using System.Collections.Generic;
using UnityEngine;

namespace Tower.Tower
{
    public class TowerPoolingh : MonoBehaviour
    {
        [SerializeField] private int poolSize;
        [SerializeField] private GameObject bullet;
        [SerializeField] private List<GameObject> bullets;
        void Start()
        {
            for (int index = 0; index <= poolSize; index++)
            {
                GameObject currentBullet = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
                currentBullet.transform.SetParent(transform);
                bullets.Add(currentBullet);
                currentBullet.SetActive(false);
            }
        }
    }
}
