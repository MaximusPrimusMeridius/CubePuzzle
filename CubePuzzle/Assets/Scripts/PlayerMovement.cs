using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float m_movementSpeed = 3f;

    private PlayerInput _playerInput;
    private CollisionDetection _collisionDetection;

    private Vector3 _targetPosition;
    private Vector3 _startPosition;

    private bool _canMove;
    private bool _isMoving;

    public bool IsMoving { get { return _isMoving; } }

    void OnEnable() => _collisionDetection.OnObstacleHit += StopMovement;

    void OnDisable() => _collisionDetection.OnObstacleHit -= StopMovement;

    void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _collisionDetection = GetComponent<CollisionDetection>();
    }

    void Start() => _startPosition = transform.position;

    void Update()
    {
        Vector3 horizontalDirection = new Vector3(_playerInput.HorizontalInput, 0f, 0f);
        Vector3 verticalDirection = new Vector3(0f, 0f, _playerInput.VerticalInput);

        if(Vector3.Distance(transform.position, _startPosition) == 0f 
            && _isMoving == false 
            && _canMove == false)
        {
            _targetPosition = _startPosition;

            if(horizontalDirection.x != 0)
            {
                _targetPosition = transform.position + horizontalDirection;
                _isMoving = true;
            }
            else
            {
                _targetPosition = transform.position + verticalDirection;
                _isMoving = true;
            }

            _startPosition = _targetPosition;
            _isMoving = false;
        }

        transform.position = Vector3.MoveTowards(transform.position, _startPosition, m_movementSpeed * Time.deltaTime);
        _canMove = false;
    }

    private void StopMovement() => _canMove = true;
}
