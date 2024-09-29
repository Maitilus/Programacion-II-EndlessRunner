using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    #region Variables

    [SerializeField] private GameObject[] ObstaclePrefab;
    public float ObstacleSpawnTime;
    private float TimeUntilSpawn;
    public float ObstacleSpeed;
    public Score Score;

    #endregion

    private void Update()
    {
        if (Score.IsPlaying) {SpawnLoop();}
    }

    //Spawn Obstacles Constantly
    private void SpawnLoop()
    {
        TimeUntilSpawn += Time.deltaTime;

        if (TimeUntilSpawn >= ObstacleSpawnTime)
        {
            Spawn();
            TimeUntilSpawn = 0;
        }
    }

    private void Spawn()
    {
        //Select a random Obstacle
        GameObject ObstacleToSpawn = ObstaclePrefab[Random.Range(0, ObstaclePrefab.Length)];

        //Spawn The obstacle in the correct Position
        GameObject SpawnedObstacle = Instantiate(ObstacleToSpawn, transform.position, Quaternion.identity);

        //Destroy the Obstacle
        Destroy(SpawnedObstacle, 4);

        //Set Obstacle Movement
        Rigidbody2D ObstacleRB = SpawnedObstacle.GetComponent<Rigidbody2D>();
        ObstacleRB.velocity = Vector2.left * ObstacleSpeed;
    }
}
