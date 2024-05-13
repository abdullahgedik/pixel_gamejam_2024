using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    [SerializeField] private GameObject FishPrefab;

    [SerializeField] private float minimumSpawnTime;

    [SerializeField] private float maximumSpawnTime;

    [SerializeField] private float spawnAmount;

    private float timeUntilSpawn;
    void Awake()
    {
        SetTimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;
        if (spawnAmount > 0)
        {
            if (timeUntilSpawn <= 0)
            {
                GameObject Fish = Instantiate(FishPrefab, transform.position, Quaternion.identity);
                SetTimeUntilSpawn();
                spawnAmount--;
            }
        }
    }

    private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minimumSpawnTime, maximumSpawnTime);
    }
}
