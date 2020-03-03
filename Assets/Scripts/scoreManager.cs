using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    public int score = 0, coin = 0;
    public Text score_text, coin_text;

    // Update is called once per frame
    void FixedUpdate()
    {
        ScoreAdd(1);
        score_text.text = (score/10).ToString() + " m";
        coin_text.text = coin.ToString();
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
