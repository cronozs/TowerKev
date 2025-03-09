using System.Collections.Generic;
using UnityEngine;

namespace Tower.Enemy
{
    public class DamageManager : MonoBehaviour
    {
        private HashSet<GameObject> _damagedEnemies = new HashSet<GameObject>();

        public void ApplyDamage(GameObject enemy, float damage)
        {
            if (!_damagedEnemies.Contains(enemy))
            {
                enemy.GetComponent<EnemyLife>().Damage(damage);
                _damagedEnemies.Add(enemy);
            }
        }

        public void ResetDamageTracking()
        {
            _damagedEnemies.Clear();
        }
    }
}
