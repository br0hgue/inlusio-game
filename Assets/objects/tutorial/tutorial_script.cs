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

    public Animator animator;
    public int phase;
    public Camera cam;
    public Transform tutText;


    private void Start() {
       phase =  animator.GetInteger("tut_phase");
       for (int i = 0; i < tutText.childCount; i++)
        {
            Transform child = tutText.GetChild(i + 2);
            child.GetComponent<TextMeshProUGUI>().enabled = false;
        }
    }

    private void Update() {
        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0){
            if(phase == 1){
                Ping();
            }
        }
    }

    public void Ping(){
       phase += 1;
       CheckText();
       Debug.Log(phase);
    }

    void CheckText(){
        for (int i = 0; i < tutText.childCount; i++)
        {
            Transform child = tutText.GetChild(phase + 2);

            Transform oldChild = tutText.GetChild(phase +1);

            oldChild.GetComponent<TextMeshProUGUI>().enabled= false;
            child.GetComponent<TextMeshProUGUI>().enabled = true;
        }
    }
}
