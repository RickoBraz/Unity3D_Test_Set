using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    private GameObject player;

    void Awake()
    {
        player = GameObject.Find("Player");
        
    }

    void Update()
    {
        if(player != null)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && player.transform.position.x != Constants.POSITION_RIGHT)
            {
                moveToRight();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && player.transform.position.x != Constants.POSITION_LEFT)
            {
                moveToLeft();
            }
        }
        
    }

    public void moveToRight()
    {
        if (player.transform.position.x == Constants.POSITION_LEFT)
        {
            player.transform.position = new Vector3(Constants.POSITION_MIDDLE, 0.5f, player.transform.position.z);
        }
        else if (player.transform.position.x == Constants.POSITION_MIDDLE)
        {
            player.transform.position = new Vector3(Constants.POSITION_RIGHT, 0.5f, player.transform.position.z);
        }
    }

    public void moveToLeft()
    {
        if (player.transform.position.x == Constants.POSITION_RIGHT)
        {
            player.transform.position = new Vector3(Constants.POSITION_MIDDLE, 0.5f, player.transform.position.z);
        }
        else if (player.transform.position.x == Constants.POSITION_MIDDLE)
        {
            player.transform.position = new Vector3(Constants.POSITION_LEFT, 0.5f, player.transform.position.z);
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Obstacles")
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}
}
