using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _speed;
    [SerializeField] private float _forceJump;

    private bool _isRight = true;
    private int _movementToRight = 1;

    private void Update()
    {
        HorizontalMovement();
        Jump();
    }

    private void HorizontalMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Run(-_movementToRight);

            if (_isRight)
                Flip();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Run(_movementToRight);

            if (_isRight == false)
                Flip();
        }
        else
        {
            _animator.SetFloat("Speed", 0);
        }

    }

    private void Run(int direction)
    {
        transform.Translate(_speed * Time.deltaTime * direction, 0, 0);
        _animator.SetFloat("Speed", _speed);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _rigidbody2D.AddForce(Vector2.up * _forceJump);
            _animator.SetTrigger("Jump");
        }
    }

    private void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;

        _isRight = !_isRight;
    }
}
