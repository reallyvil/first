using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class BackToMenu : UnityEngine.MonoBehaviour
{
    // Void for changing scenes
    public void ReturnToMenu(string MainMenu)
    {
        /* If the play button is clicked then 
         the user will load to the level*/
        SceneManager.LoadScene(MainMenu);
    }
}
