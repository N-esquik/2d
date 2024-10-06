using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent (typeof(PlayerAnimation))]
[RequireComponent (typeof(Rotation))]

public class PlayerMovement : MonoBehaviour
{
    public const string Horizontal = "Horizontal";

    [SerializeField] private float _speedMove;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _groundCheck;

    private Rigidbody2D _rigidbody;
    private PlayerAnimation _playerAnimation;
    private Rotation _rotation;
    private KeyCode _keySpace = KeyCode.Space;

    private float _rayLength = 0.2f;
    private int _rotationLeft = 180;
    private int _rotationRight = 0;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        _rotation = GetComponent<Rotation>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float moveInput = Input.GetAxis(Horizontal);

        _rigidbody.velocity = new Vector2(moveInput * _speedMove, _rigidbody.velocity.y);
        _playerAnimation.Move(moveInput);

        Rotate();
    }

    private void Rotate()
    {
        _rotation.Rotate(Input.GetAxis(Horizontal),_rotationLeft,_rotationRight);
    }

    private void Jump()
    {
        RaycastHit2D isGround = Physics2D.Raycast(_groundCheck.position, Vector2.down, _rayLength, _groundLayer);

        if (Input.GetKeyDown(_keySpace) && isGround)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
        }
    }
}