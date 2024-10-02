using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    public const string Horizontal = "Horizontal";

    [SerializeField] private float _speedMove;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _groundCheck;

    private Rigidbody2D _rigidbody;
    private PlayerAnimation _playerAnimation;
    private KeyCode _keySpace = KeyCode.Space;

    private float _rayLength = 0.2f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerAnimation = GetComponent<PlayerAnimation>();
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
        if (Input.GetAxis(Horizontal) > 0)
        {
            Quaternion rotate = transform.rotation;

            rotate.y = 0;
            transform.rotation = rotate;
        }

        if (Input.GetAxis(Horizontal) < 0)
        {
            Quaternion rotate = transform.rotation;
            rotate.y = 180;
            transform.rotation = rotate;
        }
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