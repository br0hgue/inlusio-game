using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSpin : MonoBehaviour
{
    public Transform cam;
    [Range(0,1)]
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vector = new Vector3(0, speed, 0);
        cam.transform.Rotate(vector, Space.Self);
    }
}
