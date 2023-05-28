using UnityEngine;

namespace Player
{
    public class PlayerMovement2D : MonoBehaviour 
    {
        // Component references
        public CharacterController2D controller;
        public Animator animator;

        // Movement speed
        public float runSpeed = 40f;

        // Private variables to store input
        private float _horizontalInput = 0f;
        private bool _isJumping = false;
        private bool _isCrouching = false;

        // Update is called once per frame
        void Update () 
        {
            // Get horizontal input
            _horizontalInput = Input.GetAxisRaw("Horizontal") * runSpeed;
            animator.SetFloat("Speed", Mathf.Abs(_horizontalInput));

            // Get jump input
            if (Input.GetButtonDown("Jump"))
            {
                _isJumping = true;
                animator.SetBool("IsJumping", true);
            }

            // Get crouch input
            if (Input.GetButtonDown("Crouch"))
            {
                _isCrouching = true;
            } 
            else if (Input.GetButtonUp("Crouch"))
            {
                _isCrouching = false;
            }
        }

        // This function is called when the character lands
        public void OnLanding ()
        {
            animator.SetBool("IsJumping", false);
        }

        // This function is called when the character crouches
        public void OnCrouching (bool isCrouching)
        {
            animator.SetBool("IsCrouching", isCrouching);
        }

        // FixedUpdate is called at a fixed interval and is independent of frame rate
        void FixedUpdate ()
        {
            // Move the character
            controller.Move(_horizontalInput * Time.fixedDeltaTime, _isCrouching, _isJumping);
            _isJumping = false;
        }
    }
}