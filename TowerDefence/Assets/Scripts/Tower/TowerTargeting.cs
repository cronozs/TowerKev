using System.Collections.Generic;
using UnityEngine;
using Tower.Enemy;

namespace Tower.Tower
{
    [RequireComponent(typeof (TowerPoolingh))]
    public class TowerTargeting : MonoBehaviour
    {
        [SerializeField, Tooltip("los targets de la torreta")] internal List<GameObject> targets = new List<GameObject>();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            targets.Add(collision.gameObject);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if(targets.Contains(collision.gameObject)) targets.Remove(collision.gameObject);
        }

        private void OnEnable()
        {
            EnemyLife.Ondeath += RemoveTarget;
        }

        private void OnDisable()
        {
            EnemyLife.Ondeath -= RemoveTarget;
        }

        private void RemoveTarget(GameObject obj)
        {
            if (targets.Contains(obj)) targets.Remove(obj);
        }
    }
}
