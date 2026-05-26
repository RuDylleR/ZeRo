using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] private float movingSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 inputVector;
    private bool isRunning;
    private bool isKnockedBack;

    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {

        if (isKnockedBack)
        {
            return;
        }

        inputVector = GameInput.Instance.GetMovementVector();
        inputVector = inputVector.normalized;

        rb.MovePosition(rb.position + inputVector * movingSpeed * Time.fixedDeltaTime);

        isRunning = inputVector != Vector2.zero;
    }

    public bool IsRunning()
    {
        return isRunning;
    }

    public Vector2 GetMovementVector()
    {
        return inputVector;
    }

    public void SetKnockbackState(bool state)
    {
        isKnockedBack = state;
    }

}
