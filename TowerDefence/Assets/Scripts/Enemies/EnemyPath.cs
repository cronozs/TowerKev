using System.Collections.Generic;
using UnityEngine;

namespace Tower.Enemy
{
    public class EnemyPath : MonoBehaviour
    {
        [SerializeField] private List<Transform> path;
        [SerializeField, Range(3,6)] private float speed;

        private bool _isFollow = true;
        private Vector3 _direction;
        internal int currentPoint = 0;
      
        void Update()
        {
            _direction = (path[currentPoint].position - transform.position);
            if (_isFollow && _direction.magnitude > 0.2f)
            {
                transform.position += _direction.normalized * speed * Time.deltaTime;
            }
            else
            {
                currentPoint++;
                if (currentPoint > path.Count - 1)
                {
                    _isFollow = false;
                    currentPoint = 0;
                }
            }
        }
    }
}
