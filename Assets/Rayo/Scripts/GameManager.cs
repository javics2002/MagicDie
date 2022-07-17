using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton pattern
    private static GameManager instance;

    public static GameManager getInstance()
    {
        return instance;
    }

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }
    //

    [SerializeField]
    private float cameraSensX;
    [SerializeField]
    private float cameraSensY;

    public void UpdateCameraInfo(float newSensX, float newSensY)
    {
        cameraSensX = newSensX;
        cameraSensY = newSensY;
    }

    public Vector2 GetCameraInfo()
    {
        return new Vector2(cameraSensX, cameraSensY);
    }
}
