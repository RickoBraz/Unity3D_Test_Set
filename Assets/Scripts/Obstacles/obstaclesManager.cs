using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaclesManager : MonoBehaviour
{
    public GameObject[] obstacles;
    private float interval, nextSpawn;

    void Awake()
    {
        interval = 1.5f;
        nextSpawn = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Time.timeScale = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time >= nextSpawn)
        {
            GameObject obstacle = obstacles[Random.Range(0, obstacles.Length)];
            Instantiate(obstacle);
            nextSpawn += interval;
        }
    }
}
