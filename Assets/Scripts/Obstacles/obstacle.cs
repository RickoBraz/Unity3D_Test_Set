using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class obstacle : MonoBehaviour
{
    [SerializeField]
    private List<Vector3> positions = new List<Vector3>();
    public float velocity;
    private Text ui_score;
    private float score;

    private void Awake()
    {
        positions.Add(new Vector3(Constants.POSITION_LEFT, 0.4f, 100));
        positions.Add(new Vector3(Constants.POSITION_MIDDLE, 0.4f, 100));
        positions.Add(new Vector3(Constants.POSITION_RIGHT, 0.4f, 100));
    }

    // Start is called before the first frame update
    void Start()
    {
        //ui_score = GameObject.Find("Score").GetComponent<Text>();
        //score = float.Parse(ui_score.text);
        velocity = -60 - ((score + 2) / 100);
        GetComponent<Transform>().position = positions[Random.Range(0, positions.Count)];
    }

    //void FixedUpdate()
    //{
    //    Debug.Log("FixedUpdate time :" + Time.deltaTime);
    //}


    void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, velocity);
        //if (GetComponent<Rigidbody>().transform.position.z < -180)
        //{
        //    if (score > 20)
        //    {
        //        Instantiate(obstacles[Random.Range(0, obstacles.Length)]);
        //    }
        //    else if (score > 40)
        //    {
        //        Instantiate(obstacles[Random.Range(0, obstacles.Length)]);
        //        Instantiate(obstacles[Random.Range(0, obstacles.Length)]);
        //    }
        //    Instantiate(obstacles[Random.Range(0, obstacles.Length)]);
        //    Destroy(transform.parent.gameObject);
        //}
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Mortais")
    //    {
    //        Destroy(gameObject);
    //    }
    //    if (collision.gameObject.tag == "money")
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Destroy_Itens")
       {
            Destroy(this.gameObject);
       }
    }
}
