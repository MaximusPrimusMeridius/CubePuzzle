using System;
using UnityEngine;
using UnityEngine.Events;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _rayCastLength = 1;
    private PlayerInput _playerInput;

    public event Action OnObstacleHit;
    public event Action<Transform> OnTrapHit;

    private void Awake() => _playerInput = GetComponent<PlayerInput>();

    void Update()
    {
        Vector3 inputDirection = new Vector3(_playerInput.HorizontalInput, 0f, _playerInput.VerticalInput);
        Ray ray = new Ray(transform.position, inputDirection);

        if(inputDirection != Vector3.zero)
        {
            if (Physics.Raycast(ray, out RaycastHit hitInfo, _rayCastLength, _layerMask))
            {
                switch (hitInfo.collider.gameObject.layer)
                {
                    case 6: OnObstacleHit?.Invoke(); break;
                    //case 7: OnPlayerCubeHit?.Invoke(); break;     //Unique event for Player collsion? Think about it.
                    case 8: OnTrapHit?.Invoke(hitInfo.transform); break;

                    default: break;
                }

                Debug.Log(hitInfo.collider.gameObject.layer);
            }
        }

        Debug.DrawLine(ray.origin, ray.origin + inputDirection, Color.red);
    }
}
