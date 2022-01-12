using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructalbeEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Die()
    {
        gameObject.SendMessage("DestroyMesh", null, SendMessageOptions.DontRequireReceiver);
    }
}
