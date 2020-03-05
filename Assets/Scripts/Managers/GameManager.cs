using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private AudioClip menuSound, gameSound;
    private AudioSource source;
    private bool inGame, isIA;

    public bool GetInGame() => inGame;
    public bool GetIsIA() => isIA;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        Menu();
    }
    
    public void Menu()
    {
        inGame = false;
        source.clip = menuSound;
        source.Play();
        Time.timeScale = 0;
    }

    public void PlayTheGame(bool IA)
    {
        isIA = IA;
        player.transform.position = new Vector3(Constants.POSITION_MIDDLE, 0.5f, player.transform.position.z);
        player.SetActive(true);
        GetComponent<ScoreManager>().SetScore(0);
        GetComponent<ScoreManager>().SetCoin(0);
        source.clip = gameSound;
        source.Play();
        inGame = true;
        Time.timeScale = 1;        
    }

    public void GameOver()
    {
        inGame = false;
        Time.timeScale = 0;
        GetComponent<SpawnManager>().destroyAllObstacles();
    }

    public void RestartGame()
    {
        PlayTheGame(GetIsIA());
    }

    public void CloseApplication()
    {
        Application.Quit();
    }
}
