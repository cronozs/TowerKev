using UnityEngine;

namespace Tower.Tower
{
    public class FollowTower : MonoBehaviour
    {
        private void Update()
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(mousePos);
            mousePos.z = 0;
            transform.position = mousePos;
        }

    }
}
