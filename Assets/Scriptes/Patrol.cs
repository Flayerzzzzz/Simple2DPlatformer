using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private float _speed;

    private float _distanceToGraund = 5f;
    private bool _movingLeft = true;

    private void Update()
    {
        RaycastHit2D isGround = Physics2D.Raycast(_groundChecker.position, Vector2.down, _distanceToGraund);

        if (isGround)
        {
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
        }
        else
        {
            if (_movingLeft == true)
            {
                _movingLeft = false;
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else
            {
                _movingLeft = true;
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
    }
}
