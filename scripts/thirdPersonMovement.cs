using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class thirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 6f;
    public float TurnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    Vector3 velocity;
    private bool GroundedPlayer;
    public float jumpHeight = 2.0f;
    //gravity MUST be a negative number for the player to fall down
    public  float gravity = -9.81f;
    public Transform cam;
    

    void Update()
    {
        //get the inputs as WASD
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        GroundedPlayer = controller.isGrounded;
        

        Vector3 direction = new Vector3(horizontal, 0f , vertical).normalized;

        
        if (GroundedPlayer && velocity.y < 0)
        {
            velocity.y = 0f;
            
        }
        // if we're moving
        if (direction.magnitude >= 0.1)
        {
            // get the direction of movement with a tangent and add the angle of the camera
            float TargetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            //smoothing the motion, basically an interpolation
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, TargetAngle, ref turnSmoothVelocity, TurnSmoothTime);
            //the rotation of the player
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            //make a vector
            Vector3 moveDirec = Quaternion.Euler(0f, TargetAngle, 0f) * Vector3.forward;
            //actually move 
            controller.Move(moveDirec.normalized * speed * Time.deltaTime);

            
            
        }

        //dear god it took so long to make this
        if (Input.GetButtonDown("Jump") && GroundedPlayer)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
            print(velocity.y);
        }
        // apply gravity
        velocity.y += gravity * Time.deltaTime;
        // move upwards
        controller.Move(velocity * Time.deltaTime);
    }
}
