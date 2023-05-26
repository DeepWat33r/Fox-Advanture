using UnityEngine;

namespace Player
{
    public class PlayerMovement2D : MonoBehaviour {

        public CharacterController2D controller;
        public Animator animator;

        public float runSpeed = 40f;

        private float _horizontalMove = 0f;
        private bool _jump = false;
        private bool _crouch = false;

        // Update is called once per frame
        void Update () {

            _horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            animator.SetFloat("Speed", Mathf.Abs(_horizontalMove));

            if (Input.GetButtonDown("Jump"))
            {
                _jump = true;
                animator.SetBool("IsJumping", true);
            }

            if (Input.GetButtonDown("Crouch"))
            {
                _crouch = true;
            } else if (Input.GetButtonUp("Crouch"))
            {
                _crouch = false;
            }

        }

        public void OnLanding ()
        {
            animator.SetBool("IsJumping", false);
        }

        public void OnCrouching (bool isCrouching)
        {
            animator.SetBool("IsCrouching", isCrouching);
        }

        void FixedUpdate ()
        {
            controller.Move(_horizontalMove * Time.fixedDeltaTime, _crouch, _jump);
            _jump = false;
        }
    }
}