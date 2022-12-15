using UnityEngine;

public class TeleportToMap3 : Collidable
{
    protected override void OnCollide(Collider2D coll)
    {
        if(coll.name == "Player")
        {
            GameManager.instance.SaveState();
            UnityEngine.SceneManagement.SceneManager.LoadScene("ThirdMap");
        }
    }
}
