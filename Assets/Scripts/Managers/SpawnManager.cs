using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] itens;
    private int currentScore;
    [Range(0.0f,1.0f), SerializeField]
    private float intervalReduction;
    private float interval, nextSpawn;
    private GameObject[] obstaclesActived;
    private ScoreManager SM;

    void Awake()
    {
        interval = 2.0f;
        nextSpawn = 0;
        SM = GetComponent<ScoreManager>();
    }

    void FixedUpdate()
    {
        currentScore = SM.GetScore();

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
        if (currentScore > 200) interval = 2.0f - (1.5f * intervalReduction);
        else if (currentScore > 100 && currentScore < 150) interval = 2.0f - (1.0f* intervalReduction);
        else if (currentScore > 50 && currentScore < 100) interval = 2.0f - (0.5f * intervalReduction);
        else interval = 2.0f;
    }

    public void destroyAllObstacles()
    {
        obstaclesActived = GameObject.FindGameObjectsWithTag("Obstacles");
        foreach (GameObject o in obstaclesActived)
        {
            Destroy(o);
        }
    }
}
