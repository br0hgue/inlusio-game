using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class end_trigger : trigger_scripts
{
    public Animator animator;
    void OnTriggerEnter(Collider other) {
       if(other.CompareTag("Player")){
           print("1");
           animator.Play("image_fade_out", 0);
       }
   }

   private void Update() {
       if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime >1 && !animator.IsInTransition(0) && animator.GetCurrentAnimatorStateInfo(0).IsName("image_fade_out")){
               SceneManager.LoadScene("scene 3");
           }
   }
}
