using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficCarMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public bool isGoingTowardsPlayer = false;
    Rigidbody rb;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        MoveCar();
    }
    void MoveCar()
    {
        if(isGoingTowardsPlayer)
            rb.velocity = new Vector3(1,0,0) * speed * Time.deltaTime;
        else
            rb.velocity = new Vector3(-1, 0, 0) * speed * Time.deltaTime;
    }
}
