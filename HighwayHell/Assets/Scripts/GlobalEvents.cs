using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEvents : MonoBehaviour
{
    // Start is called before the first frame update
    public static GlobalEvents Instance { get; private set; }

    public delegate void GlobalEventHandler();
    public static event GlobalEventHandler OnGameRestarted;
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        Debug.Log("Game restarted");
        OnGameRestarted.Invoke();
    }
}
