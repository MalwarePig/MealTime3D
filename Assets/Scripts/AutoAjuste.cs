using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAjuste : MonoBehaviour
{
    GameObject estadoOcupado;

    private void Start()
    {
        estadoOcupado = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.gameObject.tag);
        if (other.transform.gameObject.tag == "Mueble")
        {
            if (other.transform.childCount == 0)
            {
                estadoOcupado.GetComponent<CameraInteraction>().Ocupado = false; //Se declara que las manos estan desocupadas
                transform.SetParent(other.transform);
                transform.position = other.transform.position + new Vector3(0, 0.7f, 0); //se posiciona por encima de la mesa
                transform.GetComponent<Rigidbody>().useGravity = false; //Se retiran las fisicas
                transform.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }

    private void Update() { }
}
