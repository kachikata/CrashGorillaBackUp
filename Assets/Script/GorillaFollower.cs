using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GorillaFollower : MonoBehaviour
{

    public GameObject Gorilla;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Gorilla.transform.position;

    }
}
