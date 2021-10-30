using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_scripts : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject responder;
    void Start()
    {
        responder = GameObject.Find(responder.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
