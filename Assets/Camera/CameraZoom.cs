using System;
using UnityEngine;

namespace Camera
{
    public class CameraZoom : MonoBehaviour
    {
        [SerializeField] private float speed = 25f;
        [SerializeField] private float smoothing = 5f;
        [SerializeField] private Vector2 range = new(30f, 70f);
        [SerializeField] private Transform cameraHolder;

        private Vector3 CameraDirection => transform.InverseTransformDirection(cameraHolder.forward);
        private Vector3 _targetPosition;
        private float _input;

        private void Awake()
        {
            _targetPosition = cameraHolder.localPosition;
        }

        private void HandleInput()
        {
            _input = Input.GetAxisRaw("Mouse ScrollWheel");
        }

        private void Zoom()
        {
            var nextTargetPosition = _targetPosition + CameraDirection * (_input * speed);
            if (IsInBool(nextTargetPosition)) _targetPosition = nextTargetPosition;
            cameraHolder.localPosition = Vector3.Lerp(cameraHolder.localPosition, _targetPosition, Time.deltaTime * smoothing);
        }

        private bool IsInBool(Vector3 position)
        {
            return position.magnitude > range.x && position.magnitude < range.y;
        }

        // Update is called once per frame
        void Update()
        {
            HandleInput();
            Zoom();
        }
    }
}
