using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Rigidbody carRb;

    [SerializeField]
    private float forwardSpeed;

    [SerializeField]
    private Transform[] lanePositions;

    public int currentLaneIndex;

    private bool isLerping = false;
    //private SwipeDetection swipeDetection;

    public float lerpSpeed;
    void Start()
    {
        //MoveCarForwards();
        //swipeDetection = GetComponent<SwipeDetection>();

        currentLaneIndex = 2;

        //swipeDetection.OnSwipedLeft += DecrementIndex;
        //swipeDetection.OnSwipedRight += IncrementIndex;

    }

    // Update is called once per frame
    void Update()
    {
        MoveCarForwards();
    }
    void MoveCarForwards()
    {
        carRb.velocity = Vector3.left * forwardSpeed * Time.deltaTime;
    }
    public void IncrementIndex()
    {
        if(currentLaneIndex < lanePositions.Length - 1)
        {
            currentLaneIndex++;
            LerpCar();
        }
    }
    public void DecrementIndex()
    {
        if (currentLaneIndex > 0)
        {
            currentLaneIndex--;
            LerpCar();
        }
    }
    void LerpCar()
    {
        if(!isLerping)
        StartCoroutine(MoveCar(currentLaneIndex));
    }
    IEnumerator MoveCar(int targetIndex)
    {
        isLerping = true;

        Vector3 currentPos = transform.position;
        Quaternion currentRot = transform.rotation;

        Vector3 targetPos = new Vector3 (transform.position.x,
                                         transform.position.y,
                                         lanePositions[targetIndex].position.z);
        Quaternion targetRot = lanePositions[targetIndex].rotation;

        float timeElapsed = 0;
        while (timeElapsed < 1)
        {
            transform.position = Vector3.Lerp(currentPos, targetPos, timeElapsed);
            transform.rotation = Quaternion.Lerp(currentRot, targetRot, timeElapsed);

            timeElapsed += Time.deltaTime * lerpSpeed;
            yield return null;
        }

        transform.position = targetPos;
        transform.rotation = targetRot;

        isLerping = false;
    }
}
