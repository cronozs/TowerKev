using System;
using Tower.Bullets;
using UnityEngine;

namespace Tower.Enemy
{
    [RequireComponent(typeof(EnemyPath), typeof(BoxCollider2D))]
    public class EnemyLife : MonoBehaviour, IDamagable
    {
        [SerializeField] private float _life;

        public static event Action<GameObject> Ondeath;
        private void OnEnable()
        {
            Bullet.OnCol += Damage;
        }

        private void OnDisable()
        {
            Bullet.OnCol -= Damage;
        }
        public void Damage(float damage)
        {
            _life -= damage;
            if(_life <=0)
            {
                Ondeath.Invoke(gameObject);
                gameObject.SetActive(false);
            }
        }
    }
}
