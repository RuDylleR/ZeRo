using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private Animator animator;

    private const string MOVE_X = "MoveX";
    private const string MOVE_Y = "MoveY";
    private const string SPEED = "Speed";
    private const string LAST_MOVE_X = "LastMoveX";
    private const string LAST_MOVE_Y = "LastMoveY";

    private Vector2 lastMoveDirection = new Vector2(0, -1);

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector2 movementVector = Player.Instance.GetMovementVector();

        animator.SetFloat(MOVE_X, movementVector.x);
        animator.SetFloat(MOVE_Y, movementVector.y);
        animator.SetFloat(SPEED, movementVector.sqrMagnitude);

        if (movementVector != Vector2.zero)
        {
            lastMoveDirection = movementVector;

            animator.SetFloat(LAST_MOVE_X, lastMoveDirection.x);
            animator.SetFloat(LAST_MOVE_Y, lastMoveDirection.y);
        }
    }
}

