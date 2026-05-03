using UnityEngine;
using UnityEngine.UI;

public class PlayerCoinCollector : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    public AudioClip coinSound;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        UpdateScoreUI();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            score++;
            UpdateScoreUI();

			GameManager.Instance.timeLeft += 3f;

			audioSource.PlayOneShot(coinSound);

            Destroy(other.gameObject);
        }
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }
}