using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if(GameManager.instance != null)
        {
            Destroy(gameObject);
            Destroy(player.gameObject);
            Destroy(floatingTextManager.gameObject);
            Destroy(ui);
            Destroy(menu);
            return;
        }

        //statok torlese
        PlayerPrefs.DeleteAll();
        

        instance = this;
        SceneManager.sceneLoaded += LoadState;
        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    
    public List<Sprite> playerSprites;
    public List<Sprite> survivorSprites;
    public Player player;
    public FloatingTextManager floatingTextManager;

    //public RectTransform hitpointBar;
    public int points;
    public int survivorsSaved;
    public int foodCollected;
    public Animator deathMenuAnim;
    public GameObject ui;
    public GameObject menu;

    //textek
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }


    //mentések

    //int preferedSkin
    //int points
    //int survivorsSaved

    //On scene loaded
    public void OnSceneLoaded(Scene s, LoadSceneMode mode)
    {
        player.transform.position = GameObject.Find("SpawnPoint").transform.position;
    }
    
    //Respawn
    public void Respawn()
    {
       UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
        player.Respawn();
    }

    public void OnHitpointChange()
    {
        float ratio = (float)player.hitpoint / (float)player.maxHitpoint;
        //hitpointBar.localScale = new Vector3(1, ratio, 1);

    }
    public void SaveState()
    {
        
        string s = "";

        s += "0" + "|";
        s += points.ToString() + "|";
        s += survivorsSaved.ToString() + "|";
        s += foodCollected.ToString();

        PlayerPrefs.SetString("SaveState", s);
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {

        SceneManager.sceneLoaded -= LoadState;

        Debug.Log("LoadState");
        if(!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        // skin csere majd

        points = int.Parse(data[1]);

        survivorsSaved = int.Parse(data[2]);

        foodCollected = int.Parse(data[3]);
    }
}
