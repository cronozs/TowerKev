using System.Collections;
using UnityEngine;
using Tower.Bullets;

namespace Tower.Tower
{
    [RequireComponent(typeof(CircleCollider2D), typeof(Rigidbody2D), typeof(TowerTargeting))]
    public class TowerShooting : MonoBehaviour
    {

        [SerializeField] private float delay;
        private bool _canShoot = true;
        private TowerTargeting _towerTargeting;
        [SerializeField] private string bulletType;
        private BulletPoolManager _bulletPoolManager;

        private void Start()
        {
            _towerTargeting = GetComponent<TowerTargeting>();
            _bulletPoolManager = FindObjectOfType<BulletPoolManager>();
        }

        private void Update()
        {
            if (_towerTargeting.targets.Count != 0 && _canShoot)
            {
                Shoot();
                _canShoot = false;
            }
        }

        private void Shoot()
        {
            GameObject currentTarget = _towerTargeting.targets[0];
            GameObject currentBullet = _bulletPoolManager.GetObject(bulletType);
            if (currentBullet != null)
            {
                currentBullet.transform.position = transform.position;
                Bullet bullet = currentBullet.GetComponent<Bullet>();
                if (bullet != null)
                {
                    bullet.Target = currentTarget.transform;
                }
            }
            StartCoroutine(DelayShoot());
        }

        IEnumerator DelayShoot()
        {
            yield return new WaitForSeconds(delay);
            _canShoot = true;
        }
    }
}
