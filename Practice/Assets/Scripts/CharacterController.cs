using System.Diagnostics;
using UnityEngine;

namespace Practice
{
    public enum StatusFlags : ushort
    {
        None = 0 << 0,  // ... 00000000
        IsGrounded = 1 << 0, // ... 00000001
        IsJumping = 1 << 1, // ... 00000010
        IsRunning = 1 << 2, // ... 00000100
        IsAttacking = 1 << 3, // ... 00001000
    }

    public enum State
    {
        None,
        Move,
        Jump,
    }

    public class CharacterController : MonoBehaviour
    {
        public Vector3 Velocity { get; private set; }

        State _state;
        StatusFlags _statusFlags;
        StatusFlags _isGroundedMask = StatusFlags.IsGrounded;
        StatusFlags _isAttackingMask = StatusFlags.IsAttacking;
        [SerializeField] private float _speed = 2f;
        Animator _animator;
        Camera _camera;
        Vector3 _cameraOffset;
        [SerializeField] LayerMask _groundMask;

        void Awake()
        {
            _animator = GetComponent<Animator>();
            _state = State.Move;
            _camera = Camera.main;
            _cameraOffset = new Vector3(0f, 1.2f, -5f);
        }

        private void Update()
        {
            HandleInput();
            UpdateAnimationParameters();
        }

        private void LateUpdate()
        {
            UpdateCamera();
        }

        private void FixedUpdate()
        {
            Move();
            //Rotation();
        }

        void HandleInput()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; // 크기 1의 방향벡터로 정규화
            float speedGain = 0.5f + Input.GetAxis("SpeedGain") * 0.5f;
            Velocity = direction * _speed * speedGain;
        }

        void UpdateAnimationParameters()
        {
            _animator.SetFloat("VelocityX", Velocity.x);
            _animator.SetFloat("VelocityZ", Velocity.z);
        }

        void Move()
        {
            Vector3 deltaPosition = Velocity * Time.fixedDeltaTime;
            Vector3 expectedPosition = transform.position + deltaPosition;
            float deltaLength = Vector3.Distance(transform.position, expectedPosition);

            if (Physics.Raycast(expectedPosition + Vector3.up, Vector3.down, out RaycastHit hit, 2f, _groundMask))
            {
                Vector3 targetDirection = hit.point - transform.position;
                expectedPosition = transform.position + targetDirection * deltaLength;
                float tolerance = deltaLength * 0.1f;

                //if (Physics.Raycast(expectedPosition + Vector3.up * tolerance, Vector3.down, out hit, 2f * tolerance, _groundMask))
                {
                    transform.position = hit.point;
                }
            }
        }

        void Rotation()
        {
            if (Velocity.magnitude > 0)
            {
                transform.rotation = Quaternion.LookRotation(Velocity);
            }
        }

        public void ChangeState(State newState)
        {
            if (_state == newState)
                return;

            _state = newState;
            _animator.SetInteger("State", (int)_state);
        }

        void UpdateCamera()
        {
            _camera.transform.position = transform.position + _cameraOffset;
        }
    }
}