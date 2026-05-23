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

    public void AddItem()
    {
        collectedItems++;

        counterText.text = "Предметів: " + collectedItems + "/3";

        if (collectedItems >= 3)
        {
            exitDoor.SetActive(false);
        }
    }
}