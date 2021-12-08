
using UnityEngine;
using UnityEngine.SceneManagement;
public class gameManager : MonoBehaviour
{
  // public PlayerManager manager;
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
    private void Start() {
        if(SceneManager.GetActiveScene().name == "scene 2"){
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        } else {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    private void Update() {
        if (!GameObject.Find("Player") && SceneManager.GetActiveScene().name != "scene 1"){
            Restart();
        }

        
    }
    public void WinGame()
    {
        Debug.Log("yay you win");
    }
    public void Restart(){
        SceneManager.LoadScene("scene 2");

    }
    public void MainMenu(){
        SceneManager.LoadScene("scene 1");
    }
    public void Quit(){
         Application.Quit();
     }
    
}
