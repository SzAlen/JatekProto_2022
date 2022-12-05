using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public Player player;
    
    //public void Retry()
    //{
    //    SceneManager.LoadScene("Main");
    //    player.Respawn();
    //}
    public void RageQuit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
