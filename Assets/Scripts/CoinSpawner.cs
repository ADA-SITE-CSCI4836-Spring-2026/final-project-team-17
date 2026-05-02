using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject mazeObject;

    public int numberOfCoins = 20;
    public float coinY = 0.8f;

    public LayerMask wallLayer;
    public float wallCheckRadius = 0.3f;

    public float minDistanceBetweenCoins = 2f;
    public int maxAttempts = 3000;

    private List<Vector3> spawnedCoinPositions = new List<Vector3>();

    void Start()
    {
        Bounds bounds = GetMazeBounds();

        int spawned = 0;
        int attempts = 0;

        while (spawned < numberOfCoins && attempts < maxAttempts)
        {
            attempts++;

            float x = Random.Range(bounds.min.x, bounds.max.x);
            float z = Random.Range(bounds.min.z, bounds.max.z);

            Vector3 coinPos = new Vector3(x, coinY, z);

            bool touchingWall = Physics.CheckSphere(
                coinPos,
                wallCheckRadius,
                wallLayer
            );

            bool tooCloseToOtherCoin = IsTooCloseToOtherCoin(coinPos);

            if (!touchingWall && !tooCloseToOtherCoin)
            {
                Instantiate(coinPrefab, coinPos, Quaternion.identity);
                spawnedCoinPositions.Add(coinPos);
                spawned++;
            }
        }

        Debug.Log("Coins spawned: " + spawned);
    }

    bool IsTooCloseToOtherCoin(Vector3 position)
    {
        foreach (Vector3 existingPos in spawnedCoinPositions)
        {
            if (Vector3.Distance(position, existingPos) < minDistanceBetweenCoins)
            {
                return true;
            }
        }

        return false;
    }

    Bounds GetMazeBounds()
    {
        Renderer[] renderers = mazeObject.GetComponentsInChildren<Renderer>();

        if (renderers.Length == 0)
        {
            Debug.LogError("Maze Object has no Renderer!");
            return new Bounds(Vector3.zero, Vector3.one * 10);
        }

        Bounds bounds = renderers[0].bounds;

        foreach (Renderer r in renderers)
        {
            bounds.Encapsulate(r.bounds);
        }

        return bounds;
    }
}