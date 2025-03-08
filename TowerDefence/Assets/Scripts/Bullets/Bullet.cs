using System;
using System.Collections;
using UnityEngine;

namespace Tower.Bullets
{
    public abstract class Bullet : MonoBehaviour
    {
        [SerializeField, Tooltip("cuanto tiempo mi bala vivira si no golpea algo")] private float lifeTime;
        [SerializeField, Tooltip("la veklocidad que quiero que tenga mi bala al ser disparada")] private float speed;
        [SerializeField] private float damage;
        private float _currentSpeed;
        private Transform _target;
        private IReturnPool _returnPool;

        public static event Action<float> OnCol;

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

        public void Initialize(IReturnPool pool) 
        {
            _returnPool = pool;
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
            gameObject.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Effect();
            OnCol?.Invoke(damage);
            ReturnToPool();
        }


        private void ReturnToPool()
        {
            if (_returnPool != null)
            {
                _returnPool.ReturnObject(gameObject);
            }
            else
            {
                Debug.LogWarning("No hay pool asignado para esta bala.");
            }
        }

        protected abstract void Effect();
    }
}
