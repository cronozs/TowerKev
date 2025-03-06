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

        protected void Move()
        {      
            if (target == null) return;
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

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("istrigeeeeer");
            Effect();
            gameObject.SetActive(false);
        }

        protected abstract void Effect();
    }
}
