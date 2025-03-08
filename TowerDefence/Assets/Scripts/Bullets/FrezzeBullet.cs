using UnityEngine;
using Tower.Enemy;
using System.Collections;
using System;

namespace Tower.Bullets
{
    public class FrezzeBullet : Bullet
    {
        [SerializeField] private float effectDuration;
        void Update()
        {
            Move();
        }
        protected override void Effect(GameObject col)
        {
            EnemyPath currentEnemy = col.GetComponent<EnemyPath>();

            if (currentEnemy != null)
            {
                float speedMod = currentEnemy.Speed / 2;
                currentEnemy.Speed = speedMod;

                //  Ejecutamos la corrutina en el enemigo, NO en la bala
                currentEnemy.StartCoroutine(DelayToReturn(currentEnemy));
            }
        }

        private IEnumerator DelayToReturn(EnemyPath enemySpeed)
        {
            yield return new WaitForSeconds(effectDuration);
            enemySpeed.RestoreSpeed();
        }
    }
}
