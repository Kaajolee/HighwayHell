using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{

    // Start is called before the first frame update
    public delegate void CollisionEventHandler();
    public event CollisionEventHandler OnCollided;

    public GameObject restartButtonPrefab;
    public Canvas canvas;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Traffic")
        {
            Debug.Log("Car collided with " + collision.gameObject.name);
            Instantiate(restartButtonPrefab, canvas.transform);
            OnCollided?.Invoke();

        }
    }
}
