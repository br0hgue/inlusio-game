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
    public int phase = 1;
    public Transform tutText;
    Inventory inventory;
    bool isMoved;
    bool pickedItem;

    private void Start() {
        inventory = Inventory.instance;
        isMoved = false;
        pickedItem = false;
        animator = tutText.GetComponentInChildren<Animator>(); 
        inventory.onItemChangedCallback += AdquiredItem;
       for (int i = 0; i < tutText.childCount; i++)
        {
            //Transform child = tutText.GetChild(i + 2);
            //child.GetComponent<TextMeshProUGUI>().enabled = false;
        }
    }

    private void Update(){

            bool animTime= animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0) && animator.GetCurrentAnimatorStateInfo(0).IsName("animtest");
            if(animTime && phase < 1){
                phase +=1;
            }

            print(animTime);
            //Debug.Log(phase);
            
            if(Input.GetAxisRaw("Vertical") != 0|| Input.GetAxisRaw("Horizontal") !=0){
                isMoved = true;
            }
            //Debug.Log(animTime);

            //print(isMoved);

            if(animTime){
                switch (phase)
            {
                case 1:
                if(isMoved){
                    phase+=1;
                    break;
                }

                tutText.GetComponentInChildren<TextMeshProUGUI>().text = "use <sprite index= 1> to move";
                animator.Play("animtest", 0, 0f);
                //print("1");
                break;

                case 2:
                tutText.GetComponentInChildren<TextMeshProUGUI>().text = "move to the item to pick it up";
                animator.Play("animtest", 0,0f);
                break;

                case 3:
                tutText.GetComponentInChildren<TextMeshProUGUI>().text = "use the Mouse Scroll Wheel <sprite index= 3> to chose an item in the hotbar";
                animator.Play("animtest", 0,0f);
                phase+=1;
                break;

                case 4:
                tutText.GetComponentInChildren<TextMeshProUGUI>().text = "use the rock <sprite index= 5> to deal more damage";
                animator.Play("animtest", 0,0f);
                phase+=1;
                break; 

                case 5:
                tutText.GetComponentInChildren<TextMeshProUGUI>().text = null;
                break;

                case 6:
                tutText.GetComponentInChildren<TextMeshProUGUI>().text = "Press Left Mouse Button <sprite index= 4> to attack";
                phase +=1;
                break;

                case 7:
                tutText.GetComponentInChildren<TextMeshProUGUI>().text = null;
                break;
            }
        }

            //if(animTime && Input.anyKeyDown){
              //  phase +=1;
            //}

        }

    void AdquiredItem(){
            if(!pickedItem){
                phase+=1;
                pickedItem = true;
            }
        }
    
}
      
