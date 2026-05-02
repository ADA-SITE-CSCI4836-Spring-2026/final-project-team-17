using UnityEngine;
using TMPro;

public class MusicToggle : MonoBehaviour
{
    public AudioSource music;
    public TextMeshProUGUI buttonText;

    private bool isOn = true;

    public void ToggleMusic()
    {
        isOn = !isOn;

        music.mute = !isOn;

        buttonText.text = isOn ? "Music: On" : "Music: Off";
    }
}
