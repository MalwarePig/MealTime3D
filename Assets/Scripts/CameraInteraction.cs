using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInteraction : MonoBehaviour
{
    private new Transform camera;
    [SerializeField] private float rayDistance;
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
        if (Physics.Raycast(camera.position, camera.forward, out hit, rayDistance, LayerMask.GetMask("Interactable") )){
            Debug.Log(hit.transform.name);
        }
    }
}
