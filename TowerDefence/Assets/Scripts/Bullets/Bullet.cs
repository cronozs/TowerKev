using System;
using System.Collections;
using UnityEngine;

namespace Tower.Bullets
{
    public abstract class Bullet : MonoBehaviour
    {
        [SerializeField] private float lifeTime;  
        [SerializeField] private float speed;     
        [SerializeField] protected float effectDuration; 
        private float _currentSpeed;
        private Transform _target;
        private BulletPoolManager _bulletPoolManager; 
        private string _bulletType;  

        public Transform Target
        {
            get => _target;
            set
            {
                _target = value;
                if (_target != null)
                {
                    _currentSpeed = speed;
                }
            }
        }

        public void Initialize(BulletPoolManager poolManager, string bulletType)
        {
            if (poolManager == null)
            {
                Debug.LogError("El pool manager no puede ser nulo.");
                return;
            }

            _bulletPoolManager = poolManager;
            _bulletType = bulletType;
            StartCoroutine(LifeTime());  
        }

        protected void Move()
        {
            if (_target == null)
            {
                ReturnToPool();  
                return;
            }

            Vector3 direction = (_target.position - transform.position);
            if (direction.magnitude > 0.1f)
            {
                transform.position += direction.normalized * _currentSpeed * Time.deltaTime;
            }
        }

        private void OnEnable()
        {
            StartCoroutine(LifeTime());  
        }

        private void OnDisable()
        {
            StopAllCoroutines();
            _currentSpeed = 0;
        }

        IEnumerator LifeTime()
        {
            yield return new WaitForSeconds(lifeTime);  
            ReturnToPool();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Effect(collision.gameObject);

            ReturnToPool();
        }

        public void ReturnToPool()
        {
            if (_bulletPoolManager != null)
            {
                _bulletPoolManager.ReturnObject(gameObject, _bulletType);  
            }
            else
            {
                Debug.LogWarning("No hay pool asignado para esta bala.");
            }

            gameObject.SetActive(false);
        }

        protected abstract void Effect(GameObject col);
    }
}