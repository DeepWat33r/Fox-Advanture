using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask groundLayer;
    //[SerializeField] private Animator animator;

    private Rigidbody2D _rb;
    private Vector2 _movingForce;
    private bool _isTouchingGround;
    // Start is called before the first frame update
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        _movingForce.x = Input.GetAxis("Horizontal") * speed;
        //animator.SetFloat("Speed", Mathf.Abs(_movingForce.x));
        _isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (_isTouchingGround && Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            //animator.SetBool("IsJumping", true);
        }
        if (!Mathf.Approximately(_movingForce.x, 0))
        {
            transform.localScale = new Vector3(Mathf.Sign(_movingForce.x) * 5, 5, 1);
        }
    }
    private void FixedUpdate()
    {
        transform.Translate(Time.fixedDeltaTime * _movingForce);
    }
}
