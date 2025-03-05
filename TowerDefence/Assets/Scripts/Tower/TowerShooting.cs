using UnityEngine;

namespace Tower.Tower
{
    [RequireComponent(typeof(CircleCollider2D), typeof(Rigidbody2D), typeof(TowerTargeting))]
    public class TowerShooting : MonoBehaviour
    {
        private TowerTargeting towerTargeting;

        private void Start()
        {
            towerTargeting = GetComponent<TowerTargeting>();
        }

        private void Shoot()
        {

        }
    }
}
