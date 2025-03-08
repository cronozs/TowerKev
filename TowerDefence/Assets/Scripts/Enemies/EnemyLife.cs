using System;
using Tower.Bullets;
using UnityEngine;

namespace Tower.Enemy
{
    [RequireComponent(typeof(EnemyPath), typeof(BoxCollider2D))]
    public class EnemyLife : MonoBehaviour, IDamagable
    {
        [SerializeField] private float life;
        private float _currentLife;
        private EnemyPath _enemyPath;

        public static event Action<GameObject> Ondeath;

        private void Start()
        {
            _enemyPath = GetComponent<EnemyPath>();
            _currentLife = life;
        }

        private void OnEnable()
        {
            Bullet.OnCol += Damage;
            _currentLife = life;
        }

        private void OnDisable()
        {
            Bullet.OnCol -= Damage;
            _enemyPath.currentPoint = 0;
        }
        public void Damage(float damage)
        {
            _currentLife -= damage;
            if(_currentLife <= 0)
            {
                Ondeath.Invoke(gameObject);
                gameObject.SetActive(false);
            }
        }
    }
}
