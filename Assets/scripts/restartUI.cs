using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restartUI : MonoBehaviour
{
    // Start is called before the first frame update
   public void restart(){
       Debug.Log ("restarted game");
       FindObjectOfType<gameManager>().Restart();
   }
    public void quit()
    {
        Debug.Log("Quit game");
        Application.Quit();

    }
}
