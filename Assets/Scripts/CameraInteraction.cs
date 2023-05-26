using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInteraction : MonoBehaviour
{
    public Transform Manos;
    private new Transform camera;

    [SerializeField]
    private float rayDistance;

    [SerializeField]
    private Transform ObjetoEnMano;

    public bool Ocupado = false;

    // Start is called before the first frame update
    void Start()
    {
        camera = transform.Find("CameraPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(camera.position, camera.forward * rayDistance, Color.red);
        RaycastHit hit;
        if (
            Physics.Raycast(
                camera.position,
                camera.forward,
                out hit,
                rayDistance,
                LayerMask.GetMask("Interactable")
            )
        )
        {
            Debug.Log(hit.transform.name);
            if (Input.GetKeyDown(KeyCode.E) && Ocupado == false)
            {
                ObjetoEnMano = hit.transform;
                ObjetoEnMano.SetParent(Manos); //Se adhiere a padre (manos)
                ObjetoEnMano.position = Manos.position; //se coloca en zona de agarre (manos)
                ObjetoEnMano.GetComponent<Rigidbody>().useGravity = false; //Se retiran las fisicas
                ObjetoEnMano.GetComponent<Rigidbody>().isKinematic = true;
                ObjetoEnMano.GetComponent<BoxCollider>().isTrigger = true; //detectar collisiones
                Ocupado = true; //Objeto en mano
            }
            if (Input.GetKeyDown(KeyCode.Q) && Ocupado == true)
            {
                Ocupado = false;
                ObjetoEnMano.SetParent(null); //Se adhiere a padre (manos)
                ObjetoEnMano.GetComponent<Rigidbody>().useGravity = true; //Se retiran las fisicas
                ObjetoEnMano.GetComponent<Rigidbody>().isKinematic = false;
                ObjetoEnMano.GetComponent<BoxCollider>().isTrigger = false; //detectar collisiones
            }
        }

        ComprobarEstado();
    }

    private void ComprobarEstado() //Comprueba el estado ocuapdo constantemente
    {
        Debug.Log("En manos: " + Manos.childCount);
        if (Manos.childCount > 0)
        {
            Ocupado = true;
        }
        else
        {
            Ocupado = false;
        }
    }
}
