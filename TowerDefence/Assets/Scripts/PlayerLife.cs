using UnityEngine;
using Tower.Enemy;
using System.Collections.Generic;
using System.Collections;
using System;

namespace Tower
{
    public class PlayerLife : MonoBehaviour
    {
        [SerializeField] private float life = 20f;
        [SerializeField] private float timeToDamage;
        private List<GameObject> enemiesRiched = new List<GameObject>();

        public static event Action PlayerOnnDeath;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("chocan");
            StopAllCoroutines();
            enemiesRiched.Add(collision.gameObject);
            StartCoroutine(DamagePerEnemy());
        }

        IEnumerator DamagePerEnemy()
        {
            yield return new WaitForSeconds(timeToDamage);
            for (int i = 0; i < enemiesRiched.Count -1; i++)
            {
                EnemyLife currenEnemy = enemiesRiched[i].GetComponent<EnemyLife>();
                life -= currenEnemy.damage;
                if(life <= 0)
                {
                    PlayerOnnDeath?.Invoke();
                }
            }
            StartCoroutine(DamagePerEnemy());
        }
    }
}
