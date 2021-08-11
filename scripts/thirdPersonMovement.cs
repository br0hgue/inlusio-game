using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdPersonMovement : MonoBehaviour
{
    //declaring variables
    
    public CharacterController controller;
    public float speed = 6f;
    public float TurnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public Transform cam;

    void Update()
    {
        //getting inputs, method may be deprecated but whatever
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1)
        {
            // i have no ideia what any of this is but it works so im not moving it 
            
            float TargetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, TargetAngle, ref turnSmoothVelocity, TurnSmoothTime);
             
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirec = Quaternion.Euler(0f, TargetAngle, 0f) * Vector3.forward;

            controller.Move(moveDirec.normalized * speed * Time.deltaTime);
        }
    }
}
