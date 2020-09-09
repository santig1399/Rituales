using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneDelete : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Phone")) {
            Destroy(other.gameObject);
        }
    }
}
