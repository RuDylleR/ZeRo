using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem; 
using UnityEngine;


public class GameInput : MonoBehaviour
{
    public Vector3 GetMousePosition() {

        return Mouse.current.position.ReadValue();
    }

    public static GameInput Instance { get; private set; }


    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        Instance = this;

        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();
    }

    public Vector2 GetMovementVector()
    {
        Vector2 InputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        return InputVector;
    }

    public Vector3 getMousePosition()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        return mousePos;
    }

}
