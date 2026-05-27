using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string nextSceneName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Хтось зайшов у портал");

        if (other.CompareTag("Player"))
        {
            Debug.Log("PLAYER DETECTED");

            SceneManager.LoadScene(nextSceneName);
        }
    }
}