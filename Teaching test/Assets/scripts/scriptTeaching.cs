using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptTeaching : MonoBehaviour
{
    void Start()
    {
        
        int i = 0;
        while(i < 10)
        {
            Debug.Log(i);
            i = i + 1;
        }

        if(7 > 3)
        {
            Debug.Log("7 is bigger than 3");
        }
        else
        {
            Debug.Log("false");
        }
        


    }
}
