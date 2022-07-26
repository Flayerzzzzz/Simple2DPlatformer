using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _animator.SetFloat("Speed", 0);
        Run();
        Jump();
    }

    private void Run()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            _animator.SetFloat("Speed", _speed);
            _spriteRenderer.flipX = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
            _animator.SetFloat("Speed", _speed);
            _spriteRenderer.flipX = true;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
            if (hit == true)
            {
                _rigidbody2D.AddForce(Vector2.up * _jumpForce);
            }
        }
    }
}
