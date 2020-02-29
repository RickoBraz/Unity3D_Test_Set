using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    [SerializeField]
    private string position;

    // Start is called before the first frame update
    void Start()
    {
        position = "middle";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow) && position != "right")
        {
            if (position == "left")
            {
                transform.position = new Vector3(Constants.POSITION_MIDDLE, 0.4f, transform.position.z);
                position = "middle";
            }
            else if (position == "middle")
            {
                transform.position = new Vector3(Constants.POSITION_RIGHT, 0.4f, transform.position.z);
                position = "right";
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && position != "left")
        {
            if (position == "right")
            {
                transform.position = new Vector3(Constants.POSITION_MIDDLE, 0.4f, transform.position.z);
                position = "middle";
            }
            else if (position == "middle")
            {
                transform.position = new Vector3(Constants.POSITION_LEFT, 0.4f, transform.position.z);
                position = "left";
            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacles")
        {
            Destroy(this.gameObject);
        }
    }
}
