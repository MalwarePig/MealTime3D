using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plato : MonoBehaviour
{
    GameObject estadoOcupado;

    private float alturaPlato;
    private float SegundaAltura; 


    private void Start()
    {
        estadoOcupado = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.transform.gameObject.tag);
        if (other.transform.gameObject.tag == "Comida") //si se detecta la comida
        {

            
            /* if(){//Comprobar si mano se queda vacia

            } */


            if (transform.childCount == 0)//Si plato esta vacio
            {
                estadoOcupado.GetComponent<CameraInteraction>().Ocupado = true; //Se declara que las manos estan desocupadas
                other.transform.SetParent(transform);//A comida se asigna como padre el plato  
                other.transform.position = transform.position + new Vector3(0, AlturaFinal(other.transform), 0); //se posiciona por encima del plato
                other.transform.GetComponent<Rigidbody>().useGravity = false; //Se retiran las fisicas
                other.transform.GetComponent<Rigidbody>().isKinematic = true;
            }else{//Plato con elementos
                //Obtener ultimo elemento
                Transform ultimoHijo = transform.GetChild(transform.childCount - 1);
                Debug.Log("Último hijo: " + ultimoHijo.name);
                estadoOcupado.GetComponent<CameraInteraction>().Ocupado = true; //Se declara que las manos estan desocupadas

                other.transform.SetParent(transform);//A comida se asigna como padre el plato  
                other.transform.position = ultimoHijo.position + new Vector3(0, ApilarComida(ultimoHijo.transform, other.transform), 0); //se posiciona por encima del plato
                other.transform.GetComponent<Rigidbody>().useGravity = false; //Se retiran las fisicas
                other.transform.GetComponent<Rigidbody>().isKinematic = true; 
            }
        }
        else if (other.transform.gameObject.tag == "Ventanilla")
        { //Si el plato ya se ha entregado
            estadoOcupado.GetComponent<CameraInteraction>().Ocupado = false; //Se declara que las manos estan desocupadas
            transform.SetParent(other.transform); //a plato se asigna como padre la ventanilla
            transform.position = other.transform.position + new Vector3(0, AlturaFinal(other.transform), 0); //se posiciona por encima de la mesa
            transform.GetComponent<Rigidbody>().useGravity = false; //Se retiran las fisicas
            transform.GetComponent<Rigidbody>().isKinematic = true;
            //GameObject.Destroy(gameObject);
        }
    }

    private float AlturaFinal(Transform SegundoElemento)
    {
        /*Calcular altura primero elemento*/
        Renderer rendererUno = gameObject.GetComponent<Renderer>(); // Obtén el componente Renderer del Plato
        Bounds boundsPlato = rendererUno.bounds; // Obtén los límites (Bounds) del Plato
        alturaPlato = boundsPlato.size.y / 2; // Obtén la altura del Plato

        /*Calcular altura segundo elemento*/

        Renderer rendererDos = SegundoElemento.GetComponent<Renderer>(); // Obtén el componente Renderer del Plato
        Bounds boundsDos = rendererDos.bounds; // Obtén los límites (Bounds) del objeto
        SegundaAltura = boundsDos.size.y / 2; // Obtén la altura del objeto

        return (alturaPlato + SegundaAltura);
    }

     private float ApilarComida(Transform PrimerElemento, Transform SegundoElemento)
    {
        /*Calcular altura primero elemento*/
        Renderer rendererUno = PrimerElemento.GetComponent<Renderer>(); // Obtén el componente Renderer del Alimento
        Bounds boundsAlimento = rendererUno.bounds; // Obtén los límites (Bounds) del Alimento
        float alturaAlimento = boundsAlimento.size.y / 2; // Obtén la altura del Alimento

        Debug.Log("Altura ultimo hijo: " + alturaAlimento);

        /*Calcular altura segundo elemento*/

        Renderer rendererDos = SegundoElemento.GetComponent<Renderer>(); // Obtén el componente Renderer del Plato
        Bounds boundsDos = rendererDos.bounds; // Obtén los límites (Bounds) del objeto
        float SegundaAltura = boundsDos.size.y / 2; // Obtén la altura del objeto
        Debug.Log("Altura apliada: " + (alturaAlimento + SegundaAltura));
        return (alturaAlimento + SegundaAltura);
    }
}
