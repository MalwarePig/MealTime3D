using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAjuste : MonoBehaviour
{
     
     private void OnCollisionEnter(Collision other) {
        Debug.Log(other.gameObject);
     }
}
