using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform[] lanesTransform;

    [SerializeField]
    private GameObject carPrefabs;

    [SerializeField]
    private GameObject playerCar;

    [SerializeField]
    private float offset;
    void Start()
    {
        StartCoroutine(InstantiateCars());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            //InstantiateCar();
        }
    }
    void InstantiateCar()
    {
        int index = Random.Range(0, 4);
        GameObject clonedCar;
        Vector3 pos = new Vector3(playerCar.transform.position.x - offset, playerCar.transform.position.y, lanesTransform[index].position.z);

        if (index <= 1)
        {
            clonedCar = Instantiate(carPrefabs, pos, Quaternion.identity);
            clonedCar.transform.Rotate(new Vector3(0, 90, 0));
            AddComponents(clonedCar, true);
        }
        else if (index >= 2)
        {
            clonedCar = Instantiate(carPrefabs, pos, Quaternion.identity);
            clonedCar.transform.Rotate(new Vector3(0, -90, 0));
            AddComponents(clonedCar, false);
        }

    }
    void AddComponents(GameObject carClone, bool isGoingTowardsPlayer)
    {
        carClone.AddComponent<Rigidbody>();
        TrafficCarMovement speed = carClone.AddComponent<TrafficCarMovement>();
        speed.isGoingTowardsPlayer = isGoingTowardsPlayer;
        speed.speed = Random.Range(500,1100);
    }
    IEnumerator InstantiateCars()
    {
        while (true)
        {
            InstantiateCar();
            yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
        }
    }
}
