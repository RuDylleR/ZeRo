using UnityEngine;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Vector2 GetMovementVector()
    {
        Vector2 inputVector = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
            inputVector.y = 1f;

        if (Input.GetKey(KeyCode.S))
            inputVector.y = -1f;

        if (Input.GetKey(KeyCode.A))
            inputVector.x = -1f;

        if (Input.GetKey(KeyCode.D))
            inputVector.x = 1f;

        return inputVector;
    }
}
