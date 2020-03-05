using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
        if (GM.GetInGame())
        {
            if (GM.GetIsIA())
            {
                Ray rayMiddle = new Ray(new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), new Vector3(0, 0, 21));
                Ray rayLeft = new Ray(new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), new Vector3(45, 0, 21));
                Ray rayRight = new Ray(new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), new Vector3(-45, 0, 21));
                RaycastHit hitMiddle;
                RaycastHit hitLeft;
                RaycastHit hitRight;

                bool RayLeft = Physics.Raycast(rayLeft, out hitLeft, 25.0f, LayerMask.GetMask("Obstacles"));
                bool RayMiddle = Physics.Raycast(rayMiddle, out hitMiddle, 25.0f, LayerMask.GetMask("Obstacles"));
                bool RayRight = Physics.Raycast(rayRight, out hitRight, 25.0f, LayerMask.GetMask("Obstacles"));

                if (RayMiddle)
                {
                    if (!RayLeft)
                    {
                        Debug.Log("Raycast Left");
                        MoveToLeft();
                    }
                    else if (!RayRight)
                    {
                        Debug.Log("Raycast Right");
                        MoveToRight();
                    }
                }
            }
            else
            {
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    bool isTouchLeft = touch.position.x < screenMiddle;
                    bool isTouchEnded = touch.phase == TouchPhase.Ended;

                    if (!isTouchLeft && isTouchEnded && transform.position.x != Constants.POSITION_RIGHT)
                    {
                        MoveToRight();
                    }
                    else if (isTouchLeft && isTouchEnded && transform.position.x != Constants.POSITION_LEFT)
                    {
                        MoveToLeft();
                    }
                }
            }
        }

    }

    public void MoveToRight()
    {
        Debug.Log("MOVE RIGHT");
        if (transform.position.x == Constants.POSITION_LEFT)
        {
            transform.position = new Vector3(Constants.POSITION_MIDDLE, 0.5f, transform.position.z);
        }
        else if (transform.position.x == Constants.POSITION_MIDDLE)
        {
            transform.position = new Vector3(Constants.POSITION_RIGHT, 0.5f, transform.position.z);
        }
    }

    public void MoveToLeft()
    {
        Debug.Log("MOVE LEFT");
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
