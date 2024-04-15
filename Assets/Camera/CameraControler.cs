using UnityEngine;

namespace Camera
{
    public class CameraControler : MonoBehaviour
    {
        [SerializeField] private float speed = 1f;
        [SerializeField] private float smoothing = 5f;
        [SerializeField] private Vector2 range = new(100, 100);

        private Vector3 _targetPosition;
        private Vector3 _input;

        private void Awake()
        {
            _targetPosition = transform.position;
        }


        private void HandleInput()
        {
            var x = Input.GetAxisRaw("Horizontal");
            var z = Input.GetAxisRaw("Vertical");

            var right = transform.right * x;
            var forward = transform.forward * z;

            _input = (forward + right).normalized;
        }

        private void Move()
        {
            var nextTargetPosition = _targetPosition + _input * speed;
            if (IsInBound(nextTargetPosition)) _targetPosition = nextTargetPosition;
            transform.position = Vector3.Lerp(transform.position, _targetPosition, Time.deltaTime * smoothing);
        }

        private bool IsInBound(Vector3 position)
        {
            return position.x > -range.x &&
                   position.x < range.x &&
                   position.z > -range.y &&
                   position.z < range.y;
        }

        private void Update()
        {
            HandleInput();
            Move();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position,5f);
            Gizmos.DrawWireCube(Vector3.zero, new Vector3(range.x*2f,5f,range.y*2f));
        }
    }
}
