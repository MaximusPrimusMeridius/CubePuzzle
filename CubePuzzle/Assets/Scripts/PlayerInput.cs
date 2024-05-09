using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private float _horizontalInput;
    private float _verticalInput;

    public float HorizontalInput { get { return _horizontalInput; } }
    public float VerticalInput { get { return _verticalInput; } }

    void Update()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");   
    }
}
