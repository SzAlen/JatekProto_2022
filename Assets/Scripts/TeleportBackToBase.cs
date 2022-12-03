using UnityEngine;

public class TeleportBackToBase : Collidable
{
    protected override void OnCollide(Collider2D coll)
    {
        if(coll.name == "Player")
        {
            GameManager.instance.SaveState();
            UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
        }
    }
}
