using UnityEngine;

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
    private ChickenRotation _rotation;

    private bool _isTriggerTarget = false;
    private bool _isRight;

    private void Awake()
    {
        _chickenAnimation = GetComponent<ChickenAnimation>();
        _currentWaypoint = _pointA;
        _rotation = GetComponent<ChickenRotation>();
    }

    private void Update()
    {

        if (IsTriggerDistance())
        {
            TriggerTarget();
        }
        else if(IsTriggerDistance() && !IsTriggerMaxDistance())
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
        _rotation.Rotate(direction.x);

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

        if(Vector2.Distance(transform.position,_currentWaypoint.position) < 0.1f)
        {
            _isTriggerTarget = false;
        }
    }

    private void TriggerTarget()
    {
        Vector2 direction = _target.position - transform.position;
        _rotation.Rotate(direction.x);

        transform.position = Vector2.MoveTowards(transform.position, _target.position, _speedMove * Time.deltaTime);
        _isTriggerTarget = true;
    }

    private bool IsTriggerDistance()
    {
        return Vector2.Distance(transform.position, _target.position) <= _triggerDistance;
    }

    private bool IsTriggerMaxDistance()
    {
        return Vector2.Distance(transform.position, _target.position) <= _maxTriggerDistance;
    }
}