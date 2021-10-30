using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_start : trigger_scripts
{
   public GameObject enemy;
   bool has_entered;
//bool hasEntered;
  
   void Start()
   {
       has_entered = false;
   }

   private void OnTriggerEnter(Collider other) {
       if(other.CompareTag("Player") && !has_entered){
           //Vector3 vector = 3*Vector3.back;
           enemy.transform.position = new Vector3(-73f, 6.7f, 7f);
           has_entered = true;
       //Debug.Log("entered trigger");
       }
       
   }
}
