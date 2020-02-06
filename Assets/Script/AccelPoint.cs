using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelPoint : MonoBehaviour
{
    void OnTriggerEnter(Collider other) { 
    other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,10,30), ForceMode.VelocityChange);
        }
}
