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
    public float lerpSpeed;
    private float current;
    private float target;

    [SerializeField]
    private Transform[] lanePositions;

    public int currentLaneIndex;

    private bool isLerping = false;
    private bool isCarCrashed = false;
    //private SwipeDetection swipeDetection;
    public CollisionDetection collisionDetection;

    void Start()
    {
        //MoveCarForwards();
        //swipeDetection = GetComponent<SwipeDetection>();
        collisionDetection.OnCollided += CarCrashed;
        GlobalEvents.OnGameRestarted += RestartCar;
        currentLaneIndex = 2;

        //swipeDetection.OnSwipedLeft += DecrementIndex;
        //swipeDetection.OnSwipedRight += IncrementIndex;

    }

    // Update is called once per frame
    void Update()
    {
        if(!isCarCrashed)
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
        if (!isLerping)
        {
            target = target == 0 ? 0 : 1;
            StartCoroutine(MoveCar());
        }
            
    }
    IEnumerator MoveCar()
    {
        
        isLerping = true;

        Vector3 currentPos = transform.position;
        //Quaternion currentRot = transform.rotation;

        Vector3 targetPos = new Vector3 (transform.position.x,
                                         transform.position.y,
                                         lanePositions[currentLaneIndex].position.z);
        /*Quaternion targetRot = lanePositions[targetIndex].rotation;

        float timeElapsed = 0;
        while (timeElapsed < 1)
        {
            transform.position = Vector3.Lerp(currentPos, targetPos, timeElapsed);
            transform.rotation = Quaternion.Lerp(currentRot, targetRot, timeElapsed);
            //twee
            timeElapsed += Time.deltaTime * lerpSpeed;
            yield return null;
        }
        */
        //transform.position = targetPos;
        //transform.rotation = targetRot;
        current = Mathf.MoveTowards(current, target, lerpSpeed * Time.deltaTime);
        transform.position = Vector3.Lerp(currentPos, targetPos, current);
        yield return null;
        isLerping = false;
    }
    void CarCrashed()
    {
        isCarCrashed = true;
        //carRb.ResetInertiaTensor();
        Time.timeScale = 0f;
    }
    void RestartCar()
    {
        transform.position = lanePositions[2].position;
        carRb.position = transform.position;
        carRb.ResetInertiaTensor();
        isCarCrashed = false;
    }
}
