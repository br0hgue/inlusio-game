using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_start : trigger_scripts
{
   //public GameObject enemy;
   bool has_entered;
//bool hasEntered;
  
   void Start()
   {
       has_entered = false;
   }

private void Update() {
   }


void OnTriggerEnter(Collider other) {
       if(other.CompareTag("Player") && !has_entered){
        has_entered = true;
        print("1");
         tutorial_script.instance.NextPhase();
       }
       
    }

}
