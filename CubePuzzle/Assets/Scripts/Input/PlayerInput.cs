using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private float _horizontalInput;
    private float _verticalInput;
    private InputMap _inputMap;

    public float HorizontalInput { get { return _horizontalInput; } }
    public float VerticalInput { get { return _verticalInput; } }

    void Awake()
    {
        _inputMap = new InputMap();
        _inputMap.Gameplay.Enable();
    }

    void Update()
    {
        float inputValueX = (float)Mathf.RoundToInt(_inputMap.Gameplay.Movement.ReadValue<Vector2>().x);
        float inputValueY = (float)Mathf.RoundToInt(_inputMap.Gameplay.Movement.ReadValue<Vector2>().y);

        _horizontalInput = inputValueX;
        _verticalInput = inputValueY;
    }
}
