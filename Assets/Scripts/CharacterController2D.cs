using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private float jumpForce = 400f;							// Amount of force added when the player jumps.
	[Range(0, 1)] [SerializeField] private float crouchSpeed = .36f;			// Amount of maxSpeed applied to crouching movement. 1 = 100%
	[Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;	// How much to smooth out the movement		
	[SerializeField] private LayerMask ground;									// A mask determining what is ground to the character
	[SerializeField] private Transform groundCheck;							// A position marking where to check if the player is grounded.
	[SerializeField] private Transform ceilingCheck;							// A position marking where to check for ceilings
	[SerializeField] private Collider2D crouchDisableCollider;				// A collider that will be disabled when crouching

	private const float GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool _grounded;            // Whether or not the player is grounded.
	private const float CeilingRadius = .25f; // Radius of the overlap circle to determine if the player can stand up
	private Rigidbody2D _rb;
	private bool _facingRight = true; 
	private Vector3 _velocity = Vector3.zero;
	
	[Header("Events")]
	[Space]

	public UnityEvent onLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	public BoolEvent onCrouchEvent;
	private bool _wasCrouching = false;

	private void Awake()
	{
		_rb = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		var wasGrounded = _grounded;
		_grounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		var colliders = Physics2D.OverlapCircleAll(groundCheck.position, GroundedRadius, ground);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject) _grounded = true;
				if (!wasGrounded) onLandEvent.Invoke();
		}
	}
	
	public void Move(float move, bool crouch, bool jump)
	{
		// If the character has a ceiling preventing them from standing up, keep them crouching
		if (Physics2D.OverlapCircle(ceilingCheck.position, CeilingRadius, ground))
			crouch = true;
		// If crouching
		if (crouch)
		{
			if (!_wasCrouching)
			{
				_wasCrouching = true;
				onCrouchEvent.Invoke(true);
			}
			move *= crouchSpeed; 								// Reduce the speed by the crouchSpeed multiplier
			if (crouchDisableCollider != null)					// Disable one of the colliders when crouching
				crouchDisableCollider.enabled = false;
		} else
		{
			if (crouchDisableCollider != null)					// Enable the collider when not crouching
				crouchDisableCollider.enabled = true;
			if (_wasCrouching)
			{
				_wasCrouching = false;
				onCrouchEvent.Invoke(false);
			}
		}
		// Move the character by finding the target velocity
		Vector3 targetVelocity = new Vector2(move * 10f, _rb.velocity.y);
		// And then smoothing it out and applying it to the character
		_rb.velocity = Vector3.SmoothDamp(_rb.velocity, targetVelocity, ref _velocity, movementSmoothing);
		// If the player should jump...
		if (_grounded && jump)
		{
			// Add a vertical force to the player.
			_grounded = false;
			_rb.AddForce(new Vector2(0f, jumpForce));
		}
		if (move > 0 && !_facingRight)
		{
			Flip();
		}
		else if (move < 0 && _facingRight)
		{
			Flip();
		}
	}
	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		_facingRight = !_facingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

}