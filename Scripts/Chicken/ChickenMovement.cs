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

    private bool _isTriggerTarget = false;
    private bool _isRight;

    private int _rotate;

    private void Awake()
    {
        _chickenAnimation = GetComponent<ChickenAnimation>();
        _currentWaypoint = _pointA;
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
        transform.position = Vector2.MoveTowards(transform.position, _currentWaypoint.position, _speedMove * Time.deltaTime);

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

        Rotate();
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
        RotateTowardsTarget();
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

    private void Rotate()
    {
        if (transform.position.x > _currentWaypoint.position.x)
        {
            _rotate = 0;
            SetRotate(_rotate);
        }

        if (transform.position.x < _currentWaypoint.position.x)
        {
            _rotate = 180;
            SetRotate(_rotate);
        }
    }

    private void RotateTowardsTarget()
    {
        if(_target.position.x > transform.position.x)
        {
            _rotate = 180;
            SetRotate(_rotate);
        }
        else if(_target.position.x < transform.position.x)
        {
            _rotate = 0;
            SetRotate(_rotate) ;
        }
    }

    private void SetRotate(int number)
    {
        Quaternion rotate = transform.rotation;
        rotate.y = number;
        transform.rotation = rotate;
    }
}