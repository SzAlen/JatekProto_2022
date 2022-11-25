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
            return;
        }

        //statok torlese
        //PlayerPrefs.DeleteAll();
        

        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);

    }

    
    public List<Sprite> playerSprites;
    public List<Sprite> survivorSprites;
    public List<int> upgradePrices;
    public Player player;
    public FloatingTextManager floatingTextManager;
    public int points;
    public int survivorsSaved;

    //textek
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }


    //mentések

    //int preferedSkin
    //int points
    //int survivorsSaved


    public void SaveState()
    {
        
        string s = "";

        s += "0" + "|";
        s += points.ToString() + "|";
        s += survivorsSaved.ToString();

        PlayerPrefs.SetString("SaveState", s);
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if(!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        // skin csere majd

        points = int.Parse(data[1]);
        survivorsSaved = int.Parse(data[2]);

        Debug.Log("LoadState");
    }

}
