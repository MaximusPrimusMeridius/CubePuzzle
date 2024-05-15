using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float m_movementSpeed = 3f;
    [SerializeField] private Transform m_targetPosition;

    private PlayerInput _playerInput;
    private CollisionDetection _collisionDetection;

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
            && _canMove == true)
        {
            if(horizontalDirection.x != 0)
            {
                m_targetPosition.position = transform.position + horizontalDirection;
                _isMoving = true;
            }
            else
            {
                m_targetPosition.position = transform.position + verticalDirection;
                _isMoving = true;
            }

            _startPosition = m_targetPosition.position;
            _isMoving = false;
        }
        
        m_targetPosition.position = _startPosition;
        transform.position = Vector3.MoveTowards(transform.position, _startPosition, m_movementSpeed * Time.deltaTime);
        _canMove = true;
    }

    private void StopMovement() => _canMove = false;
}
