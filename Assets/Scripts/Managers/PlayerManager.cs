using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private GameObject GameController;
    private int screenMiddle;
    private GameManager GM;
    private PanelManager PM;
    private ScoreManager SM;

    void Awake()
    {
        screenMiddle = Screen.width / 2;
        GameController = GameObject.FindGameObjectWithTag("GameController");
        GM = GameController.GetComponent<GameManager>();
        PM = GameController.GetComponent<PanelManager>();
        SM = GameController.GetComponent<ScoreManager>();
    }

    void Update()
    {
        if(Input.touchCount > 0 && GM.GetInGame())
        {            
            Touch touch = Input.GetTouch(0);
            bool isTouchLeft = touch.position.x < screenMiddle;
            bool isTouchEnded = touch.phase == TouchPhase.Ended;
            
            if (!isTouchLeft && isTouchEnded && transform.position.x != Constants.POSITION_RIGHT)
            {
                moveToRight();
            }
            else if (isTouchLeft && isTouchEnded && transform.position.x != Constants.POSITION_LEFT)
            {
                moveToLeft();
            }
        }

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
            SM.CoinAdd(1);
        }
        else
        {
            this.gameObject.SetActive(false);
            GM.GameOver();
            PM.changePanel(2);
        }
    }
}
