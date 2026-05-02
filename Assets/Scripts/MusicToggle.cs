using UnityEngine;
using UnityEngine.UI;

public class MusicToggle : MonoBehaviour
{
    public static MusicToggle Instance;

    public AudioSource musicSource;
    public Text musicButtonText;

    private bool musicOn = true;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        if (musicSource != null && !musicSource.isPlaying)
            musicSource.Play();

        UpdateButtonText();
    }

    public void ToggleMusic()
    {
        musicOn = !musicOn;

        if (musicOn)
            musicSource.Play();
        else
            musicSource.Pause();

        UpdateButtonText();
    }

    void UpdateButtonText()
    {
        if (musicButtonText != null)
            musicButtonText.text = musicOn ? "Music: On" : "Music: Off";
    }
}