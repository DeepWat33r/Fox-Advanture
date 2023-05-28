using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class CharacterController2D : MonoBehaviour
    {
        // Configuration parameters
        [SerializeField] private float jumpForce = 400f;
        [Range(0, 1)] [SerializeField] private float crouchSpeed = .36f;
        [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;
        [SerializeField] private LayerMask ground;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private Transform ceilingCheck;
        [SerializeField] private Collider2D crouchDisableCollider;

        private const float GroundedRadius = .2f;
        private const float CeilingRadius = .25f;
        private bool _grounded;
        private Rigidbody2D _rb;
        private bool _facingRight = true;  
        private Vector3 _velocity = Vector3.zero;

        // Event setup
        [Header("Events")]
        [Space]
        public UnityEvent onLandEvent;
        [System.Serializable]
        public class BoolEvent : UnityEvent<bool> { }
        
        public BoolEvent onCrouchEvent;

        private bool _wasCrouching = false;

        private void Awake()
        {
            // Initialize the Rigidbody
            _rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            // Check if character is grounded
            bool wasGrounded = _grounded;
            _grounded = false;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, GroundedRadius, ground);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    _grounded = true;
                    if (!wasGrounded)
                    {
                        // Invoke landing event
                        onLandEvent.Invoke();
                    }
                }
            }
        }

        public void Move(float move, bool crouch, bool jump)
        {
            // Check if the character can stand up
            if (Physics2D.OverlapCircle(ceilingCheck.position, CeilingRadius, ground)) crouch = true;

            // Apply crouch settings
            if (crouch)
            {
                if (!_wasCrouching)
                {
                    _wasCrouching = true;
                    onCrouchEvent.Invoke(true);
                }

                move *= crouchSpeed;
                if (crouchDisableCollider != null) crouchDisableCollider.enabled = false;
            } 
            else
            {
                if (crouchDisableCollider != null) crouchDisableCollider.enabled = true;

                if (_wasCrouching)
                {
                    _wasCrouching = false;
                    onCrouchEvent.Invoke(false);
                }
            }

            // Apply movement
            Vector3 targetVelocity = new Vector2(move * 10f, _rb.velocity.y);
            _rb.velocity = Vector3.SmoothDamp(_rb.velocity, targetVelocity, ref _velocity, movementSmoothing);

            // Apply jump
            if (_grounded && jump)
            {
                _grounded = false;
                _rb.AddForce(new Vector2(0f, jumpForce));
            }

            // Flip character direction
            if (move > 0 && !_facingRight || move < 0 && _facingRight)
            {
                Flip();
            }
        }

        private void Flip()
        {
            // Flip the character's direction
            _facingRight = !_facingRight;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }
}
