using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_menu : MonoBehaviour
{
    // Start is called before the first frame update
    public int gameStartScene;

    // Update is called once per frame
    public void StartGame()
    {
        SceneManager.LoadScene(gameStartScene);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    //public void ContextualMenu()
    //{
    //    GameObject.SetActive();
    //}
    
}
