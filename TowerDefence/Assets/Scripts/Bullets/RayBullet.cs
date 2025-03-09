using System.Collections;
using UnityEngine;
using Tower.Enemy;

namespace Tower.Bullets
{
    public class RayBullet : Bullet
    {
        [SerializeField] private float freezeDuration = 3f;  
        [SerializeField] private float damage = 5f;   
        [SerializeField] private float damageTimes = 1f;  


        private void Update()
        {
            Move();
        }
        protected override void Effect(GameObject col)
        {
            EnemyLife enemyLife = col.GetComponent<EnemyLife>();
            EnemyPath enemyPath = col.GetComponent<EnemyPath>();

            if (enemyLife != null && enemyPath != null)
            {
                enemyPath.Speed = enemyPath.Speed / 1.5f;
                CorrutineRunner.Instance.RunCoroutine(ApplyPoisonEffect(enemyLife));
                CorrutineRunner.Instance.RunCoroutine(UnfreezeEnemy(enemyPath));
            }
            ReturnToPool();
        }

        private IEnumerator ApplyPoisonEffect(EnemyLife enemy)
        {
            float elapsed = 0;

            while (elapsed < effectDuration)
            {
                yield return new WaitForSeconds(damageTimes);

                if (enemy == null || !enemy.gameObject.activeInHierarchy)
                    yield break;

                enemy.Damage(damage);
                elapsed += damageTimes;
            }
        }

        private IEnumerator UnfreezeEnemy(EnemyPath enemyPath)
        {
            yield return new WaitForSeconds(freezeDuration);

            if (enemyPath != null && enemyPath.gameObject.activeInHierarchy)
            {
                enemyPath.RestoreSpeed();
            }
        }
    }
}