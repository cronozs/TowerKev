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
        private int _currentPoint = 0;
      
        void Update()
        {
            _direction = (path[_currentPoint].position - transform.position);
            if (_isFollow && _direction.magnitude > 0.2f)
            {
                transform.position += _direction.normalized * speed * Time.deltaTime;
            }
            else
            {
                _currentPoint++;
                if (_currentPoint > path.Count - 1)
                {
                    _isFollow = false;
                    _currentPoint = 0;
                }
            }
        }
    }
}
