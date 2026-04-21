using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private GameObject objectToSpawn;     // Drag your prefab here in Inspector
    [SerializeField] private float spawnRate = 0.5f;       // How often to spawn (seconds)
    [SerializeField] private float spawnOffset = 1f;       // Distance in front of the spawner


    private float nextSpawnTime;

    private void Start()
    {
        nextSpawnTime = Time.time + spawnRate;
    }

    private void Update()
    {
        // === SPAWNING ===
        if (Time.time >= nextSpawnTime)
        {
            SpawnObject();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    private void SpawnObject()
    {
        if (objectToSpawn == null) return;

        // Spawn in front of the object so it doesn't collide with the spawner
        Vector3 spawnPosition = transform.position + transform.forward * spawnOffset;
        
        Instantiate(objectToSpawn, spawnPosition, transform.rotation);
    }
}