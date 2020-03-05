using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int score = 0, coin = 0;
    [SerializeField]
    private Text scoreText, coinText;

    public int GetScore() => score/10;
    public int GetCoin() => coin;
    public void SetScore(int newScore) => score = newScore;
    public void SetCoin(int newCoin) => coin = newCoin;

    void FixedUpdate()
    {
        ScoreAdd(1);
        scoreText.text = (score/10).ToString() + " m";
        coinText.text = coin.ToString();
    }

    public void ScoreAdd(int i)
    {
        score += i;
    }

    public void CoinAdd(int c)
    {
        coin += c;
    }
}
