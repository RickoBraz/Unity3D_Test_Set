using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    public GameObject player;
    private AudioSource source;
    public AudioClip menuSound, gameSound;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        Menu();
    }
    
    public void Menu()
    {
        source.clip = menuSound;
        source.Play();
        Time.timeScale = 0;
    }

    public void PlayTheGame()
    {
        player.transform.position = new Vector3(Constants.POSITION_MIDDLE, 0.5f, -60);
        player.SetActive(true);
        GetComponent<ScoreManager>().score = 0;
        GetComponent<ScoreManager>().coin = 0;
        source.clip = gameSound;
        source.Play();
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        GetComponent<SpawnManager>().destroyAllObstacles();
    }

    public void CloseApplication()
    {
        Application.Quit();
    }
}
