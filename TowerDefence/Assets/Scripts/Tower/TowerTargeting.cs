using System.Collections.Generic;
using UnityEngine;

namespace Tower.Tower
{
    [RequireComponent(typeof (TowerPoolingh))]
    public class TowerTargeting : MonoBehaviour
    {
        [SerializeField] internal List<GameObject> targets = new List<GameObject>();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            targets.Add(collision.gameObject);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if(targets.Contains(collision.gameObject)) targets.Remove(collision.gameObject);
        }
    }
}
