using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class obstacle : MonoBehaviour
{
    [SerializeField]
    private List<Vector3> positions = new List<Vector3>();
    private float velocity;

    private void Awake()
    {
        positions.Add(new Vector3(Constants.POSITION_LEFT, 0.5f, 100));
        positions.Add(new Vector3(Constants.POSITION_MIDDLE, 0.5f, 100));
        positions.Add(new Vector3(Constants.POSITION_RIGHT, 0.5f, 100));
    }

    void Start()
    {
        velocity = -60;
        GetComponent<Transform>().position = positions[Random.Range(0, positions.Count)];
    }


    void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, velocity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Destroy_Itens")
       {
            Destroy(this.gameObject);
       }else if (other.gameObject.tag == "Player")
        {
            if (this.gameObject.tag == "money")
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<scoreManager>().CoinAdd(1);
                Destroy(this.gameObject);
            }
            else
            {
                other.gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("GameController").GetComponent<gameManager>().GameOver();
                GameObject.FindGameObjectWithTag("GameController").GetComponent<panelManager>().changePanel(2);
            }
        }
    }
}
