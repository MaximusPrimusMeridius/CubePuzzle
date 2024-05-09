using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _moveToPoint;
    [SerializeField] private float _movementSpeed = 3f;
    [SerializeField] private float _moveToPointDistance = 1f;

    private PlayerInput _playerInput;
    private CollisionDetection _collisionDetection;
    private Vector3 _nextPosition;
    private bool _stoppedMovement;

    void OnEnable()
    {
        _collisionDetection.OnObstacleHit += StopMovement;
    }

    private void OnDisable()
    {
        _collisionDetection.OnObstacleHit -= StopMovement;
    }

    void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _collisionDetection = GetComponent<CollisionDetection>();
    }

    void Start()
    {
        _nextPosition = transform.position;
    }

    void Update()
    {
        Vector3 horizontalMovement = new Vector3(_playerInput.HorizontalInput, 0f, 0f);
        Vector3 verticalMovement = new Vector3(0f, 0f, _playerInput.VerticalInput);


        if (Vector3.Distance(transform.position, _nextPosition) == 0f && _stoppedMovement == false)
        {
            if (_playerInput.HorizontalInput != 0f)
            {
                _moveToPoint.localPosition = horizontalMovement * _moveToPointDistance;
            }
            else
            {
                _moveToPoint.localPosition = verticalMovement * _moveToPointDistance;
            }

            _nextPosition = _moveToPoint.position;
        }
        
        transform.position = Vector3.MoveTowards(transform.position, _nextPosition, _movementSpeed * Time.deltaTime);
        _stoppedMovement = false;
    }

    private void StopMovement() => _stoppedMovement = true;
}
