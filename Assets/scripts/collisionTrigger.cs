
using UnityEngine;

public class collisionTrigger : MonoBehaviour
{
    
    void OnCollisionEnter(Collision collisionInfo) {
        
        if (collisionInfo.collider.tag == "lose") 
        {
            FindObjectOfType<gameManager>().EndGame();            
        } 
        if (collisionInfo.collider.tag == "win")
        {
            FindObjectOfType<gameManager>().WinGame();
            
        } 
        
    }
}
