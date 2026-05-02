using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotateSpeed = 120f;
    public int coinValue = 1;

    private void Update()
    {
        transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.Instance.AddScore(coinValue);
            Destroy(gameObject);
        }
    }
}