using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tower.Tower
{
    public class ValidateTower : MonoBehaviour
    {
        private CircleCollider2D col;
        private FollowTower followTower;
        [SerializeField] Tilemap tilemap;
        [SerializeField] TileBase targetTile;
        void Start()
        {
            col = GetComponent<CircleCollider2D>();
            followTower = GetComponent<FollowTower>();
            tilemap = GameObject.Find("ValidatePositions").GetComponent<Tilemap>();
        }

        void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3Int cellPos = tilemap.WorldToCell(mouseWorldPos);

                TileBase currentTile = tilemap.GetTile(cellPos);
                if(currentTile == targetTile)
                {
                    mouseWorldPos.z = 0;
                    followTower.enabled = false;
                    transform.position = mouseWorldPos;
                    col.enabled = true;
                    tilemap.SetTile(cellPos, null);
                    this.enabled = false;
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
