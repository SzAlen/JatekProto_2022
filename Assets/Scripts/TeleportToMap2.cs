using UnityEngine;

public class TeleportToMap2 : Collidable
{
    protected override void OnCollide(Collider2D coll)
    {
        if(coll.name == "Player")
        {
            GameManager.instance.SaveState();
            UnityEngine.SceneManagement.SceneManager.LoadScene("SecondMap");
        }
    }
}
