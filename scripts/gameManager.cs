
using UnityEngine;
using UnityEngine.SceneManagement;
public class gameManager : MonoBehaviour
{

    //we probably wont use any of this but for testing its nice
   
    bool gameIsOn = true;
    // Start is called before the first frame update
    public void EndGame()
    
    {
        if (gameIsOn == true){
        gameIsOn = false;
        Debug.Log("Game Over");
        }
        Restart();
    }
    public void WinGame()
    {
        Debug.Log("yay you win");
    }
    public void Restart(){
        SceneManager.LoadScene("scene 1");

    }
    
}
