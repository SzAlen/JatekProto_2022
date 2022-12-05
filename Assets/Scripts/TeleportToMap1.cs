using UnityEngine;

public class TeleportToMap1 : Collidable
{
    protected override void OnCollide(Collider2D coll)
    {
        if(coll.name == "Player")
        {
            GameManager.instance.SaveState();
            UnityEngine.SceneManagement.SceneManager.LoadScene("FirstMap");
        }
    }
}
