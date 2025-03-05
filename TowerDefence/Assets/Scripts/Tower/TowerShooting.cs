using System.Collections;
using UnityEngine;

namespace Tower.Tower
{
    [RequireComponent(typeof(CircleCollider2D), typeof(Rigidbody2D), typeof(TowerTargeting))]
    public class TowerShooting : MonoBehaviour
    {

        [SerializeField, Tooltip("tiempo de espera para el disparo de la torre")] private float delay;
        private bool _canShoot = true;
        private IObjectPool _pooling;
        private TowerTargeting _towerTargeting;

        private void Start()
        {
            _towerTargeting = GetComponent<TowerTargeting>();
            _pooling = GetComponent<TowerPoolingh>();
        }

        private void Update()
        {
            if(_towerTargeting.targets.Count != 0 && _canShoot)
            {
                Shoot();
                _canShoot = false;
            }
        }

        private void Shoot()
        {
            GameObject bullet = _pooling?.GetObject();
            if (bullet != null)
            {
                bullet.transform.position = transform.position;
                // falta darle la velocidad
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
