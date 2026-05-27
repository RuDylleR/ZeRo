using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderUI : MonoBehaviour
{
    private Slider slider;
    private bool canChangeVolume = false;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        canChangeVolume = false;

        float savedVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);

        slider.onValueChanged.RemoveAllListeners();

        slider.SetValueWithoutNotify(savedVolume);

        if (MusicManager.instance != null)
        {
            MusicManager.instance.SetVolume(savedVolume);
        }

        slider.onValueChanged.AddListener(ChangeVolume);

        canChangeVolume = true;
    }

    private void ChangeVolume(float value)
    {
        if (!canChangeVolume) return;

        if (MusicManager.instance != null)
        {
            MusicManager.instance.SetVolume(value);
        }
    }
}