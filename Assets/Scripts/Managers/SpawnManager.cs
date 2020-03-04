using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] itens;
    public int current_score;
    [Range(0.0f,1.0f)]
    public float intervalReduction;
    private float interval, nextSpawn;
    private GameObject[] obstacles_actived;

    void Awake()
    {
        interval = 2.0f;
        nextSpawn = 0;
    }

    void FixedUpdate()
    {
        current_score = GetComponent<ScoreManager>().score / 10;

        if (Time.time >= nextSpawn)
        {
            GameObject obstacle = itens[Random.Range(0, itens.Length)];
            Instantiate(obstacle);
            nextSpawn += interval;
        }

        changeInterval();
    }

    public void changeInterval()
    {
        if (current_score > 200) interval = 2.0f - (1.5f * intervalReduction);
        else if (current_score > 100 && current_score < 150) interval = 2.0f - (1.0f* intervalReduction);
        else if (current_score > 50 && current_score < 100) interval = 2.0f - (0.5f * intervalReduction);
        else interval = 2.0f;
    }

    public void destroyAllObstacles()
    {
        obstacles_actived = GameObject.FindGameObjectsWithTag("Obstacles");
        foreach (GameObject o in obstacles_actived)
        {
            Destroy(o);
        }
    }
}
