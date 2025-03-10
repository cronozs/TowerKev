using UnityEngine;

namespace Tower.Tower
{
    public class TowerGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject towerPrefab;
        [SerializeField] private Transform positionReference;

        public void CreateTower()
        {
            Instantiate(towerPrefab, positionReference);
        }
    }
}
