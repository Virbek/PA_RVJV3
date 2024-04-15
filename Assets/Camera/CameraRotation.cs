using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Camera
{
    public class CameraRotation : MonoBehaviour
    {
        [SerializeField] private float speed = 15f;
        [SerializeField] private float smoothing = 5f;

        private float _targetAngle;
        private float _currentAngle;

        private void Awake()
        {
            _targetAngle = transform.eulerAngles.y;
            _currentAngle = _targetAngle;
        }

        private void HandleInput()
        {
            if (Input.GetKey(KeyCode.Q))
            {
                _targetAngle -= speed;
            }

            if (Input.GetKey(KeyCode.E))
            {
                _targetAngle += speed;
            }
                

        }

        private void Rotate()
        {
            _currentAngle = Mathf.Lerp(_currentAngle, _targetAngle, Time.deltaTime * smoothing);
            transform.rotation = Quaternion.AngleAxis(_currentAngle, Vector3.up);
        }

        // Update is called once per frame
        void Update()
        {
             HandleInput();
             Rotate();
        }
    }
}
