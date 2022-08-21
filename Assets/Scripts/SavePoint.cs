using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    private static SavePoint instance;
    public Vector2 lastCheckPointPos;
    
    public Vector2 startCheckPointPos = new Vector2(-7.0f,0.0f);

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
