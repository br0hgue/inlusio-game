using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class tutorial_script : MonoBehaviour
{

    public static tutorial_script instance;

    void Awake(){
        instance = this;
    }

    Animator animator;
    public int phase;
    public Camera cam;
    public Transform tutText;
    bool isMoved;

    private void Start() {
        isMoved = false;
        animator = tutText.GetComponentInChildren<Animator>();
       for (int i = 0; i < tutText.childCount; i++)
        {
            Transform child = tutText.GetChild(i + 2);
            child.GetComponent<TextMeshProUGUI>().enabled = false;
        }
    }

    private void Update() {
        phase =  animator.GetInteger("tut_phase");
        bool animTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime >1 && !animator.IsInTransition(0);
        //string animName = animator.GetCurrentAnimatorClipInfo(0)[0].clip.name;
        //print(animTime);
        if (animTime && animator.GetCurrentAnimatorStateInfo(0).IsName("animtest")){
            CheckText();
        }
        else if (animTime && animator.GetCurrentAnimatorStateInfo(0).IsName("wasd_anim")){
            animator.SetBool("phase_2", true);
            print(animator.GetBool("phase_2"));
            animator.SetInteger("tut_phase", 2);
            CheckText();
        }
        else if (animTime && animator.GetCurrentAnimatorStateInfo(0).IsName("item_anim")){
            animator.SetInteger("tut_phase", 3);
            CheckText();
        }
        else if (animTime && animator.GetCurrentAnimatorStateInfo(0).IsName("scroll_anim")){
            animator.SetInteger("tut_phase", 4);
            CheckText();
        }
        else if (animTime && animator.GetCurrentAnimatorStateInfo(0).IsName("damage_anim")){
            animator.SetInteger("tut_phase", 5);
            CheckText();
        }
        else if (animTime && animator.GetCurrentAnimatorStateInfo(0).IsName("attack_anim")){
            animator.SetInteger("tut_phase", 6);
            CheckText();
        }
        else if (animTime && animator.GetCurrentAnimatorStateInfo(0).IsName("use_anim")){
            animator.SetInteger("tut_phase", 7);
            CheckText();
        }

        

        /*bool Movething = Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0;
        if(!isMoved && Movething && phase == 1){
            isMoved = true;
            Ping();
            
        }*/
    }

    public void Ping(){
       phase =  animator.GetInteger("tut_phase");
       animator.SetInteger("tut_phase", phase + 1);
       CheckText();

       //Debug.Log(phase);
    }

    void CheckText(){
        print(phase);
        for (int i = 0; i < tutText.childCount; i++)
        {
            Transform child = tutText.GetChild(phase + 1);

            Transform oldChild = tutText.GetChild(phase);

            oldChild.GetComponent<TextMeshProUGUI>().enabled= false;
            child.GetComponent<TextMeshProUGUI>().enabled = true;
        }
    }
}
