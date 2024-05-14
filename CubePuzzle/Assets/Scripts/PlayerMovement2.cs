using System;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    [SerializeField] private float m_movementSpeed = 3f;

    private PlayerInput _playerInput;
    private CollisionDetection _collisionDetection;

    private Vector3 _targetPosition;
    private Vector3 _startPosition;
    private bool _isMoving;
    private bool _canMove;

    void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _collisionDetection = GetComponent<CollisionDetection>();
        _collisionDetection.OnObstacleHit += StopMovement;
    }

    private void StopMovement()
    {
        _canMove = false;
    }

    void Update()
    {
        if (_isMoving)
        {
            if (Vector3.Distance(_startPosition, transform.position) > 1f)
            {
                transform.position = _targetPosition;
                _isMoving = false;

                return;
            }

            transform.position += (_targetPosition - _startPosition) * m_movementSpeed * Time.deltaTime;
            return;
        }

        Vector3 horizontalDirection = new Vector3(_playerInput.HorizontalInput, 0f, 0f);
        Vector3 verticalDirection = new Vector3(0f, 0f, _playerInput.VerticalInput);

        if (horizontalDirection.x == -1f && _canMove == true)
        {
            _targetPosition = transform.position + Vector3.left;
            _startPosition = transform.position;
            _isMoving = true;
        }
        else if (verticalDirection.z == -1f && _canMove == true)
        {
            _targetPosition = transform.position + Vector3.back;
            _startPosition = transform.position;
            _isMoving = true;
        }
        else if (horizontalDirection.x == 1f && _canMove == true)
        {
            _targetPosition = transform.position + Vector3.right;
            _startPosition = transform.position;
            _isMoving = true;
        }
        else if (verticalDirection.z == 1f && _canMove == true)
        {
            _targetPosition = transform.position + Vector3.forward;
            _startPosition = transform.position;
            _isMoving = true;
        }

        _canMove = true;
    }
}
