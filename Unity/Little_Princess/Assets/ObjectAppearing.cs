using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAppearing : MonoBehaviour
{
    public GameObject[] objetosAAparecer;

    public void ActivarObjetos()
    {
        foreach (GameObject objeto in objetosAAparecer)
        {
            if(objeto != null)
            {
                objeto.SetActive(true);
            }
        
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ActivarObjetos();
        }
    }
}
