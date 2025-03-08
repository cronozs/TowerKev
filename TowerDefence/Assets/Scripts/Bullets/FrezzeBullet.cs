using UnityEngine;

namespace Tower.Bullets
{
    public class FrezzeBullet : Bullet
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            Move();
        }
        protected override void Effect()
        {
            Debug.Log("Efecto");
        }

    }
}
