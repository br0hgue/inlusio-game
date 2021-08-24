
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public Rigidbody rb;
    public float forwardForce = 200f;
    public int forces = 200;

    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(0, 0, 200);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce( 0,0, forwardForce * Time.deltaTime);

        if (Input.GetMouseButton(1))
        {
            rb.AddForce(500 * Time.deltaTime,0 , 0);
        }
        if (Input.GetMouseButton(0))
        {
            rb.AddForce(-500 * Time.deltaTime,0, 0);
        }

        if (Input.GetKey("w")){
            rb.AddForce(0,0,forces * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a")){
            rb.AddForce(-forces * Time.deltaTime,0,0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("s")){
            rb.AddForce(0,0,-forces * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (Input.GetKey("d")){
            rb.AddForce(forces * Time.deltaTime,0,0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("q")){
            rb.AddForce(0,-forces * Time.deltaTime,0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("e")){
            rb.AddForce(0,forces * Time.deltaTime,0, ForceMode.VelocityChange);
        }

        
    }
}
