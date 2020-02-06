using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpPoint : MonoBehaviour
{

    Rigidbody rb;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player1"))
        {
            
            other.gameObject.transform.position = new Vector3(-10, 15, 0);
            rb.velocity = Vector3.zero;
        }
        else if (other.gameObject.CompareTag("player2"))
        {
            other.gameObject.transform.position = new Vector3(10, 15, 0);
        }
    }
}
