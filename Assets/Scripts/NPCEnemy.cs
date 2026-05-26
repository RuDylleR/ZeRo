using UnityEngine;

public class NPCEnemy : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private float wanderSpeed = 1.5f;
    [SerializeField] private float chaseSpeed = 3.5f;
    [SerializeField] private float detectionRadius = 4f;
    [SerializeField] private float changeDirectionTime = 2f;

    [Header("Knockback")]
    [SerializeField] private float knockbackForce = 8f;
    [SerializeField] private float knockbackTime = 0.2f;

    private Rigidbody2D rb;
    private Transform player;

    private Vector2 moveDirection;
    private float timer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }

        ChooseRandomDirection();
    }

    private void FixedUpdate()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRadius)
        {
            ChasePlayer();
        }
        else
        {
            Wander();
        }
            
            FlipSprite();   
    }

    private void Wander()
    {
        timer -= Time.fixedDeltaTime;

        if (timer <= 0)
        {
            ChooseRandomDirection();
        }

        rb.MovePosition(rb.position + moveDirection * wanderSpeed * Time.fixedDeltaTime);
    }

    private void ChasePlayer()
    {
        Vector2 directionToPlayer = ((Vector2)player.position - rb.position).normalized;
        rb.MovePosition(rb.position + directionToPlayer * chaseSpeed * Time.fixedDeltaTime);
    }

    private void ChooseRandomDirection()
    {
        moveDirection = Random.insideUnitCircle.normalized;
        timer = changeDirectionTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerKnockback playerKnockback = collision.GetComponent<PlayerKnockback>();

            if (playerKnockback != null)
            {
                Vector2 knockbackDirection =
                    (collision.transform.position - transform.position).normalized;

                playerKnockback.Knockback(knockbackDirection, knockbackForce, knockbackTime);
            }
        }
    }

    private void FlipSprite()
    {
        if (moveDirection.x > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveDirection.x < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }

}
