using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [Header("isGround")]
    [SerializeField] Transform checkGround;
    [SerializeField] float checkRadius;
    [SerializeField] LayerMask layerGround;

    readonly int numberOfBonusJump = 2;
    int _bonusJumps;
    float _horizontal;
    Rigidbody2D _rb;
    bool _facingRight = true;
    bool _isGrounded;
    void Start()
    {
        _bonusJumps = numberOfBonusJump;
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (_isGrounded)
            _bonusJumps = numberOfBonusJump;
    }

    private void FixedUpdate()
    {
        _isGrounded = Physics2D.OverlapCircle(checkGround.position, checkRadius, layerGround);

        _horizontal = Input.GetAxis("Horizontal2") * speed * Time.deltaTime;
        _rb.velocity = new Vector2(_horizontal, _rb.velocity.y);

        CheckFlip();

        if ((Input.GetButtonDown("Jump2") && (_isGrounded || _bonusJumps > 0)) || Input.GetButton("Jump2") && _isGrounded)
        {
            _rb.velocity = Vector2.up * jumpForce * Time.deltaTime;
            _bonusJumps -= 1;
        }
    }

    private void CheckFlip()
    {
        if ((!_facingRight && _horizontal > 0) || (_facingRight && _horizontal < 0))
            Flip();
    }
    private void Flip()
    {
        _facingRight = !_facingRight;
        transform.Rotate(0, 180, 0);
    }
}
