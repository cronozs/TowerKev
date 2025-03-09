using System;
using UnityEngine;

namespace Tower.Enemy
{
    [RequireComponent(typeof(EnemyPath), typeof(BoxCollider2D))]
    public class EnemyLife : MonoBehaviour, IDamagable
    {
        [SerializeField] private float life;
        public float _currentLife;
        private EnemyPath _enemyPath;
        public float damage;

        public static event Action<GameObject> Ondeath;

        private void Start()
        {
            _enemyPath = GetComponent<EnemyPath>();
            _currentLife = life;
        }

        private void OnEnable()
        {
            _currentLife = life;
        }

        private void OnDisable()
        {
            _enemyPath.isFollow = true;
            _enemyPath.currentPoint = 0;
            _enemyPath.RestoreSpeed();
        }


        public void Damage(float damage)
        {

            _currentLife -= damage;
            if (_currentLife <= 0)
            {
                Ondeath.Invoke(gameObject);
                gameObject.SetActive(false);
            }
            
        }
    }
}
