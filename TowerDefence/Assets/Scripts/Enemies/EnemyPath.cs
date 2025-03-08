using System.Collections.Generic;
using UnityEngine;

namespace Tower.Enemy
{
    public class EnemyPath : MonoBehaviour
    {
        [SerializeField] private List<Transform> path;
        [Range(3,10)] public float speed;
        private float _currentSpeed;
        private int _maxSpeed = 10;
        private int _minSpeed = 3;

        public float Speed
        {
            get => _currentSpeed;
            set
            {
                if(value > _maxSpeed) _currentSpeed = _maxSpeed;
                else if (value < _minSpeed) _currentSpeed = _minSpeed;
                else _currentSpeed = value;
            }
        }

        internal bool isFollow = true;
        private Vector3 _direction;
        internal int currentPoint = 0;

        private void Start()
        {
            RestoreSpeed();
        }

        void Update()
        {
            _direction = (path[currentPoint].position - transform.position);
            if (isFollow && _direction.magnitude > 0.2f)
            {
                transform.position += _direction.normalized * _currentSpeed * Time.deltaTime;
            }
            else
            {
                currentPoint++;
                if (currentPoint > path.Count - 1)
                {
                    isFollow = false;
                    currentPoint = 0;
                }
            }
        }

        public void RestoreSpeed()
        {
            _currentSpeed = speed;
        }

    }
}
