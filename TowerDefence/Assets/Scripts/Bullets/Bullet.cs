using System.Collections;
using UnityEngine;

namespace Tower.Bullets
{
    public abstract class Bullet : MonoBehaviour
    {
        [SerializeField] private float lifeTime;
        [SerializeField] private float speed;
        private float currentSpeed;
        private Transform target;
        private IReturnPool returnPool;

        public Transform Target
        {
            get => target;
            set
            {
                target = value;
                if (target != null)
                {
                    currentSpeed = speed;
                }
            }
        }

        public void Initialize(IReturnPool pool) 
        {
            returnPool = pool;
        }

        protected void Move()
        {
            if (target == null)
            {
                ReturnToPool();
                return;
            }
            Vector3 direction = (target.position - transform.position);
            if (direction.magnitude > 0.1f)
            {
                transform.position += direction.normalized * currentSpeed * Time.deltaTime;
            }
        }

        private void OnEnable()
        {
            StartCoroutine(LifeTime());
        }

        private void OnDisable()
        {
            StopAllCoroutines();
            currentSpeed = 0;
        }

        IEnumerator LifeTime()
        {
            yield return new WaitForSeconds(lifeTime);
            gameObject.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("istrigeeeeer");
            Effect();
            ReturnToPool();
        }


        private void ReturnToPool()
        {
            if (returnPool != null)
            {
                returnPool.ReturnObject(gameObject);
            }
            else
            {
                Debug.LogWarning("No hay pool asignado para esta bala.");
            }
        }

        protected abstract void Effect();
    }
}
