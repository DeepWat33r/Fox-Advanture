using UnityEngine;

namespace Enemies
{
    public class Slime : MonoBehaviour
    {
        public float speed = 2f; // The speed at which the Slime moves
        public float jumpHeight = 3f; // The height of the Slime's jumps
        public float jumpDuration = 1f; // The duration of the Slime's jumps
        public float waitTimeMin = 2f; // The minimum time to wait before jumping again
        public float waitTimeMax = 4f; // The maximum time to wait before jumping again
        public float minArcAngle = 45f; 
        public float maxArcAngle = 135f;

        public Animator animator;
        private Rigidbody2D rb; // The Rigidbody2D component of the Slime
        private Vector2 jumpVelocity; // The velocity of the Slime's jump
        private bool isJumping = false; // Whether the Slime is currently jumping
        private float timeSinceLastJump = 0f; // The time since the Slime's last jump
        private float waitTime = 0f; // The time to wait before the Slime's next jump

        // Start is called before the first frame update
        void Start()
        {
            // Get the Rigidbody2D component
            rb = GetComponent<Rigidbody2D>();

            // Calculate the jump velocity based on the jump height and duration
            jumpVelocity = new Vector2(speed, jumpHeight) * Mathf.Sqrt(2f * Physics2D.gravity.magnitude * jumpDuration) / jumpDuration;

            // Set the initial wait time before the first jump
            waitTime = Random.Range(waitTimeMin, waitTimeMax);
        }

        // Update is called once per frame
        void Update()
        {
            // Update the time since the last jump
            timeSinceLastJump += Time.deltaTime;

            // If the Slime is not jumping and it's time for the next jump, initiate a jump
            if (!isJumping && timeSinceLastJump >= waitTime)
            {
                // Set the Slime as jumping
                isJumping = true;
                animator.SetBool("IsJumping",true);
                // Calculate the jump direction as a random angle
                float jumpAngle = Random.Range(minArcAngle, maxArcAngle);
                Vector2 jumpDirection = Quaternion.Euler(0f, 0f, jumpAngle) * Vector2.right;

                // Set the Slime's velocity to the jump velocity in the chosen direction
                rb.velocity = jumpVelocity * jumpDirection;
                if (rb.velocity.x < 0f)
                {
                    transform.localScale = new Vector3(5f, 5f, 5f);
                }
                else
                {
                    transform.localScale = new Vector3(-5f, 5f, 5f);
                }
                // Reset the time since the last jump and set the next wait time
                timeSinceLastJump = 0f;
                waitTime = Random.Range(waitTimeMin, waitTimeMax);
            }
        }

        // OnCollisionEnter2D is called when the Slime collides with another object
        void OnCollisionEnter2D(Collision2D collision)
        {
            // If the Slime is jumping and it collides with a surface, stop jumping and reset its velocity
            if (isJumping)
            {
                isJumping = false;
                animator.SetBool("IsJumping",false);
                rb.velocity = Vector2.zero;
            }
        }
    }
}
