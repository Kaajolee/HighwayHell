using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
    // Start is called before the first frame update
    public static PointCounter instance;
    [SerializeField]
    public float totalPoints;
    Vector3 currentPos;
    public TextMeshProUGUI pointsText;
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        CountScore();
    }
    void CountScore()
    {
        if (transform.position.magnitude != 0)
        {
            pointsText.text = "Points: " + totalPoints++;
        }
    }
}
