using UnityEngine;

public class FadeInUI : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float speed = 1.5f;

    void Start()
    {
        canvasGroup.alpha = 0;
    }

    void Update()
    {
        if (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime * speed;
        }
    }
}