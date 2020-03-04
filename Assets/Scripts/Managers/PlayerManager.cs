using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private GameObject GameController;

    void Awake()
    {
        GameController = GameObject.FindGameObjectWithTag("GameController");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x != Constants.POSITION_RIGHT)
        {
            moveToRight();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x != Constants.POSITION_LEFT)
        {
            moveToLeft();
        }

    }

    public void moveToRight()
    {
        if (transform.position.x == Constants.POSITION_LEFT)
        {
            transform.position = new Vector3(Constants.POSITION_MIDDLE, 0.5f, transform.position.z);
        }
        else if (transform.position.x == Constants.POSITION_MIDDLE)
        {
            transform.position = new Vector3(Constants.POSITION_RIGHT, 0.5f, transform.position.z);
        }
    }

    public void moveToLeft()
    {
        if (transform.position.x == Constants.POSITION_RIGHT)
        {
            transform.position = new Vector3(Constants.POSITION_MIDDLE, 0.5f, transform.position.z);
        }
        else if (transform.position.x == Constants.POSITION_MIDDLE)
        {
            transform.position = new Vector3(Constants.POSITION_LEFT, 0.5f, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "money")
        {
            Destroy(other.gameObject);
            GameController.GetComponent<ScoreManager>().CoinAdd(1);
        }
        else
        {
            this.gameObject.SetActive(false);
            GameController.GetComponent<GameManager>().GameOver();
            GameController.GetComponent<PanelManager>().changePanel(2);
        }
    }
}
