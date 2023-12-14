using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Playgame()
    {
        //makes the scene go foward
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update is called once per frame
  public void Quitgame()
    {
        //if the quit button gets hit it says quit
        Debug.Log("quit");
        //closes the game
        Application.Quit();
    }
}
