using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        _animator.SetFloat(HashAnimationNames.Speed, 0);
        Run();
    }

    private void Run()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _animator.SetFloat(HashAnimationNames.Speed, Movement.Speed);
            _spriteRenderer.flipX = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _animator.SetFloat(HashAnimationNames.Speed, Movement.Speed);
            _spriteRenderer.flipX = true;
        }
    }
}
