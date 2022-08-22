using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("More than one GameManager in scene");
        }
    }

    private void Start()
    {
        //if unity editor,then enable debug logs,else disable debug logs for better performance
#if UNITY_EDITOR
        Debug.unityLogger.logEnabled = true;
#else
        Debug.unityLogger.logEnabled = false;
#endif
    }

    public void OnQuitButtonClicked()
    {
        Application.Quit();
    }

}
