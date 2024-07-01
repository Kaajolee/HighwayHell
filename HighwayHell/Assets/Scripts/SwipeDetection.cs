using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 startTouchPos;
    public Vector2 endTouchPos;

    public delegate void SwipeDetectionEventHandler();
    public event SwipeDetectionEventHandler OnSwipedLeft;
    public event SwipeDetectionEventHandler OnSwipedRight;

    public float minSwipeDistance;

    private CarControl carControl;
    void Start()
    {
        carControl = GetComponent<CarControl>();
    }

    
    void Update()
    {
        DetectSwipe();
    }
    void DetectSwipe()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                startTouchPos = touch.position;
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                endTouchPos = touch.position;
                Vector2 delta = endTouchPos - startTouchPos;

                if(delta.magnitude > minSwipeDistance)
                {
                    if(Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
                    {
                        if(delta.x < 0)
                        {
                            Debug.Log("Swiped left");
                            carControl.DecrementIndex();
                        }
                        else if(delta.x > 0)
                        {
                            Debug.Log("Swiped right");
                            carControl.IncrementIndex();
                        }
                    }
                }
            }
        }

    }
}
