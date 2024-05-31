using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _currentSpeed;
    [SerializeField] private float _forceJump;

    public float boost = 15;
    public float defaultSpeed = 10;

    private float _horizontalMove;
    private bool _isJump;
    private bool _isRight = true;
    private InputReader _inputReader;

    private int _speedHash = Animator.StringToHash("Speed");
    private int _jumpHash = Animator.StringToHash("Jump");

    private void Awake()
    {
        _inputReader = new InputReader();
        _currentSpeed = defaultSpeed;
    }

    private void Update()
    {
        _horizontalMove = _inputReader.GetHorizontalAxisInput();
        if (_inputReader.GetJumpInput())
            _isJump = true;
        SpeedUp();
    }

    private void FixedUpdate()
    {
        HorizontalMovement(_horizontalMove);
        Jump();
    }

    private void HorizontalMovement(float horizontalMove)
    {
        if (horizontalMove != 0)
        {
            Run(horizontalMove);

            if ((_isRight && horizontalMove < 0) || (_isRight == false && horizontalMove > 0))
                Flip();
        }

        if (horizontalMove == 0)
        {
            _animator.SetFloat(_speedHash, 0);
        }
    }

    private void Run(float horizontalMove)
    {
        _rigidbody2D.velocity = new Vector2(horizontalMove * _currentSpeed, _rigidbody2D.velocity.y);
        _animator.SetFloat(_speedHash, _currentSpeed);
    }

    private void Jump()
    {
        if (_isJump)
        {
            _rigidbody2D.AddForce(Vector2.up * _forceJump);
            _animator.SetTrigger(_jumpHash);
            _isJump = false;
        }
    }

    private void SpeedUp()
    {
        if (_inputReader.GetBoostInput())
        {
            _currentSpeed = boost;
        }
        else
        {
            _currentSpeed = defaultSpeed;
        }
    }

    private void Flip()
    {
        transform.Rotate(0f, 180f, 0f);

        _isRight = !_isRight;
    }
}
