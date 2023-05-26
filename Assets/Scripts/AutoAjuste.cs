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
        //Debug.Log(other.transform.gameObject.tag);
        if (other.transform.gameObject.tag == "Mueble")
        {
            if (other.transform.childCount == 0)
            {
                estadoOcupado.GetComponent<CameraInteraction>().Ocupado = false; //Se declara que las manos estan desocupadas
                transform.SetParent(other.transform); 
               
                transform.position = other.transform.position + new Vector3(0, AlturaFinal(other.transform), 0); //se posiciona por encima de la mesa
                transform.GetComponent<Rigidbody>().useGravity = false; //Se retiran las fisicas
                transform.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }

    private float AlturaFinal(Transform SegundoElemento)
    {
        /*Calcular altura primero elemento*/
        Renderer rendererUno = gameObject.GetComponent<Renderer>(); // Obtén el componente Renderer del Alimento
        Bounds boundsAlimento = rendererUno.bounds; // Obtén los límites (Bounds) del Alimento
        float alturaAlimento = boundsAlimento.size.y / 2; // Obtén la altura del Alimento

        /*Calcular altura segundo elemento*/

        Renderer rendererDos = SegundoElemento.GetComponent<Renderer>(); // Obtén el componente Renderer del Plato
        Bounds boundsDos = rendererDos.bounds; // Obtén los límites (Bounds) del objeto
        float SegundaAltura = boundsDos.size.y / 2; // Obtén la altura del objeto

        return (alturaAlimento + SegundaAltura);
    }
 
}
