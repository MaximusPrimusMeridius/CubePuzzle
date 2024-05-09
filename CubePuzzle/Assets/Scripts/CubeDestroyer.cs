using UnityEngine;

public class CubeDestroyer : MonoBehaviour
{
    private CollisionDetection _collisionDetection;

    void OnEnable()
    {
        _collisionDetection.OnTrapHit += DestroySelf;
    }

    void OnDisable()
    {
        _collisionDetection.OnTrapHit -= DestroySelf;
    }

    private void Awake()
    {
        _collisionDetection = GetComponent<CollisionDetection>();
    }

    private void DestroySelf(Transform trapPosition)
    {
        Destroy(gameObject, 0.4f);
    }
}
