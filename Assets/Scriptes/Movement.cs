using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody2D;

    private float _distanceToGround = 0.1f;

    public static float Speed { get; private set; }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        Speed = _speed;
    }

    private void Update()
    {
        Run();
        Jump();
    }

    private void Run()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, _distanceToGround);
            if (hit == true)
            {
                _rigidbody2D.AddForce(Vector2.up * _jumpForce);
            }
        }
    }
}
