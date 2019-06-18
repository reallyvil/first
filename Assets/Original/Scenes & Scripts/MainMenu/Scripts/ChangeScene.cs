using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ChangeScene : UnityEngine.MonoBehaviour
{
    // Void for changing scenes
    public void LoadTheNextScene(string level)
    {
        /* If the play button is clicked then 
         the user will load to the level*/
        SceneManager.LoadScene(level);
    }
}
