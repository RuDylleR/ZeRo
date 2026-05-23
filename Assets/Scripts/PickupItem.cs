using UnityEngine;

public class PickupItem : MonoBehaviour
{
    private bool playerInside;

    private void Update()
    {
        if (playerInside)
        {
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("ПРЕДМЕТ ПІДІБРАНО");

                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;

            Debug.Log("PLAYER INSIDE");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;

            Debug.Log("PLAYER EXIT");
        }
    }
}