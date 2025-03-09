using System.Collections;
using UnityEngine;
using Tower.Enemy;

namespace Tower.Bullets
{
    public class PoisonBullet : Bullet
    {
        [SerializeField] private float damagePoison; 
        [SerializeField] private float damageTimes;   
        private bool _isEffectActive = false;        

        private void Update()
        {
            Move();
        }

        protected override void Effect(GameObject col)
        {
            EnemyLife currentEnemy = col.GetComponent<EnemyLife>();

            if (currentEnemy != null)
            {
                currentEnemy.Damage(damagePoison);

                if (!_isEffectActive)
                {
                    _isEffectActive = true;
                    CorrutineRunner.Instance.RunCoroutine(ApplyPoisonEffect(currentEnemy));
                }
            }

            ReturnToPool();
        }

        private IEnumerator ApplyPoisonEffect(EnemyLife enemy)
        {
            float interval = effectDuration / damageTimes;  
            float elapsed = 0;

            while (elapsed < effectDuration)
            {
                yield return new WaitForSeconds(interval);

                if (enemy == null || !enemy.gameObject.activeInHierarchy)
                    yield break;

                enemy.Damage(damagePoison);
                elapsed += interval;
            }

            _isEffectActive = false;  
        }

        private void OnDisable()
        {
            _isEffectActive = false;  
        }
    }
}