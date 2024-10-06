using UnityEngine;

[RequireComponent (typeof(ChickenAnimation))]
[RequireComponent(typeof(Rotation))]

public class ChickenMovement : MonoBehaviour
{
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    [SerializeField] private Transform _target;
    [SerializeField] private float _speedMove;
    [SerializeField] private float _triggerDistance = 0.5f;
    [SerializeField] private float _maxTriggerDistance = 2f;

    private Transform _currentWaypoint;
    private ChickenAnimation _chickenAnimation;
    private Rotation _rotation;

    private bool _isRight;
    private int _rotationLeft = 0;
    private int _rotationRight = 180;

    private void Awake()
    {
        _chickenAnimation = GetComponent<ChickenAnimation>();
        _currentWaypoint = _pointA;
        _rotation = GetComponent<Rotation>();
    }

    private void Update()
    {
        if (IsTriggerDistance())
        {
            FollowTheTarget();
        }
        else if(IsTriggerDistance())
        {
            ReturnPatrol();
        }
        else
        {
            Patrol();
        }
    }

    private void Patrol()
    {
        Vector2 direction = _currentWaypoint.position - transform.position;
        transform.position = Vector2.MoveTowards(transform.position, _currentWaypoint.position, _speedMove * Time.deltaTime);
        _rotation.Rotate(direction.x,_rotationLeft,_rotationRight);

        _chickenAnimation.Move(_speedMove);

        if (Vector2.Distance(transform.position, _currentWaypoint.position) < 0.1f)
        {
            if (_isRight)
            {
                _currentWaypoint = _pointB;
                _isRight = false;
            }
            else
            {
                _currentWaypoint = _pointA;
                _isRight = true;
            }
        }
    }

    private void ReturnPatrol()
    {
        if (Vector2.Distance(transform.position, _pointA.position) < Vector2.Distance(transform.position, _pointB.position))
        {
            _currentWaypoint = _pointA;
        }
        else
        {
            _currentWaypoint = _pointB;
        }

        transform.position = Vector2.MoveTowards(transform.position, _currentWaypoint.position, _speedMove * Time.deltaTime);
    }

    private void FollowTheTarget()
    {
        Vector2 direction = _target.position - transform.position;
        _rotation.Rotate(direction.x, _rotationLeft, _rotationRight);

        transform.position = Vector2.MoveTowards(transform.position, _target.position, _speedMove * Time.deltaTime);
    }

    private bool IsTriggerDistance()
    {
        return Vector2.Distance(transform.position, _target.position) <= _triggerDistance && Vector2.Distance(transform.position,_target.position) <= _maxTriggerDistance;
    }
}