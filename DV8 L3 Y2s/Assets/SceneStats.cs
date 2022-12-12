using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStats : MonoBehaviour
{
    public static bool created = false;
    private void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    
}
