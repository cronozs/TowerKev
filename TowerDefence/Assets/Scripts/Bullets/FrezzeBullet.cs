using System.Collections;
using UnityEngine;
using Tower.Enemy;

namespace Tower.Bullets
{
    public class FreezeBullet : Bullet
    {
        [SerializeField] private float freezeDuration = 3f;  
        [SerializeField] private float damage = 10f;  


        private void Update()
        {
            Move();
        }

        protected override void Effect(GameObject col)
        {
            if (!col.activeInHierarchy)
            {
                ReturnToPool();
                return;
            }

            EnemyLife enemyLife = col.GetComponent<EnemyLife>();
            if (enemyLife != null)
            {
                enemyLife.Damage(damage);
            }

            EnemyPath enemyPath = col.GetComponent<EnemyPath>();
            if (enemyPath != null)
            {
                enemyPath.Speed = 0f;

                if (col.activeInHierarchy)
                {
                    CorrutineRunner.Instance.RunCoroutine(DelayToReturn(enemyPath));
                }
            }

            ReturnToPool();
        }

        private IEnumerator DelayToReturn(EnemyPath enemyPath)
        {
            yield return new WaitForSeconds(freezeDuration);
            if (enemyPath != null && enemyPath.gameObject.activeInHierarchy) 
            {
                enemyPath.RestoreSpeed();  
            }
        }
    }
}