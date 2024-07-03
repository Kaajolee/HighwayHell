using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButtonLogic : MonoBehaviour
{
    public void RestartPressed()
    {
        GlobalEvents.Instance.RestartGame();
        Destroy(gameObject);
    }
}
