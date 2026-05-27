using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int collectedItems = 0;

    public TextMeshProUGUI counterText;

    public GameObject exitDoor;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        counterText.text = "Предметів: 0/3";
    }

    public void AddItem()
    {
        collectedItems++;

        counterText.text = "Предметів: " + collectedItems + "/3";

        Debug.Log("TEXT UPDATED");

        if (collectedItems >= 3)
        {
            exitDoor.SetActive(false);

            Debug.Log("EXIT OPENED");
        }
    }
}