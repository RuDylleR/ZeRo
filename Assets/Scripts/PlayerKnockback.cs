using System.Collections;
using UnityEngine;

public class PlayerKnockback : MonoBehaviour
{
    private Rigidbody2D rb;
    private Player player;

    private bool isKnockedBack;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
    }

    public void Knockback(Vector2 direction, float force, float duration)
    {
        if (!isKnockedBack)
        {
            StartCoroutine(KnockbackCoroutine(direction, force, duration));
        }
    }

    private IEnumerator KnockbackCoroutine(Vector2 direction, float force, float duration)
    {
        isKnockedBack = true;

        player.SetKnockbackState(true);

        rb.linearVelocity = Vector2.zero;

        rb.AddForce(direction * force, ForceMode2D.Impulse);

        yield return new WaitForSeconds(duration);

        rb.linearVelocity = Vector2.zero;

        player.SetKnockbackState(false);

        isKnockedBack = false;
    }
}