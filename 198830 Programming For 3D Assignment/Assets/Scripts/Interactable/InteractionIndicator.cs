using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionIndicator : MonoBehaviour
{

    [SerializeField] Material positiveColor;
    [SerializeField] Material negativeColor;
    [SerializeField] MeshRenderer[] indicators;
    bool inRange;
    private void Update()
    {
        if (inRange)
        {
            foreach (MeshRenderer m in indicators)
            {
                m.material = positiveColor;
            }
        }
        else
        {
            foreach (MeshRenderer m in indicators)
            {
                m.material = negativeColor;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}
