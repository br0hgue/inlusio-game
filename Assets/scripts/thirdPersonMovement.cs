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
    Vector3 moveDirec;
    Vector3 velocity;
    private bool GroundedPlayer;
    private bool FallingPlayer;
    public float jumpHeight = 2.0f;
    public  float gravity = -9.81f;
    public Transform cam;
    public Camera _camera;
    public Transform groundcheck;
    public LayerMask groundlayer;
    public float grounddistance;

    Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        _camera.fieldOfView = 30f;
        
    }
    void FixedUpdate()
    {
        
        if(!EventSystem.current.IsPointerOverGameObject()){
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
	//Don't forget to add an isMoving bool inside your Animator
        animator.SetBool("isMoving", isWalking);

        GroundedPlayer = Physics.CheckSphere(groundcheck.position, grounddistance, groundlayer) && velocity.y < 0;

        FallingPlayer = Physics.CheckSphere(groundcheck.position, grounddistance + 0.2f, groundlayer);
        

        Vector3 direction = new Vector3(horizontal, 0f , vertical).normalized;

        
        if (GroundedPlayer && velocity.y < 0)
        {
            velocity.y = 0f;
            
        }

        if (direction.magnitude >= 0.1)
        {
            
            
            float TargetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            //smoothing the motion

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, TargetAngle, ref turnSmoothVelocity, TurnSmoothTime);

            //the rotation of the player
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            //make a vector
            moveDirec = Quaternion.Euler(0f, TargetAngle, 0f) * Vector3.forward;



            //actually move 
            controller.Move(moveDirec.normalized * speed * Time.deltaTime);

            
            
        } else if (direction.magnitude < 0.1){
            animator.SetBool("isMoving", false);
        }


        //dear god it took so long to make this
        if (Input.GetButtonDown("Jump") && GroundedPlayer)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
            
            animator.SetBool("isJumping", true);}

        /*if (animator.GetBool("isJumping") && FallingPlayer && !Input.GetButtonDown("Jump")){
            Debug.Log("play falling animation");
        } */

        if (FallingPlayer && !GroundedPlayer && !Input.GetButtonDown("Jump") && velocity.y <= 0f)
        {
          animator.SetBool("isJumping", false);
          animator.SetBool("isFalling", true);
            //Debug.Log("falling ");
        } else animator.SetBool("isFalling", false);

        velocity.y += gravity * Time.deltaTime;
         //if (velocity.y > 0f)
             //{Debug.Log(velocity.y);}

        controller.Move(velocity * Time.deltaTime);
    }

    }
}
