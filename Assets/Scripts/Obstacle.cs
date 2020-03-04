using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class Obstacle : MonoBehaviour, IGameobjectDestroy
{
    [SerializeField]
    private List<Vector3> positions = new List<Vector3>();
    private Rigidbody rb;
    private float velocity;
    

    private void Awake()
    {
        positions.Add(new Vector3(Constants.POSITION_LEFT, 0.5f, 100));
        positions.Add(new Vector3(Constants.POSITION_MIDDLE, 0.5f, 100));
        positions.Add(new Vector3(Constants.POSITION_RIGHT, 0.5f, 100));
        rb = GetComponent<Rigidbody>();        
        velocity = -60;
    }

    void Start()
    {        
        GetComponent<Transform>().position = positions[Random.Range(0, positions.Count)];
    }


    void FixedUpdate()
    {
        rb.velocity = new Vector3(0, 0, velocity);
    }

    public void DestroyGameobject()
    {
        Destroy(this.gameObject);
    }
}
