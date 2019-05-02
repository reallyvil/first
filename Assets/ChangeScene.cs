using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ChangeScene : UnityEngine.MonoBehaviour
{
    /* if the user clicks the play 
    with the 0 mouse button which is right click*/

    // Void for changing scenes
    public void LoadTheNextScene(string level)
    {
        SceneManager.LoadScene(level);
    }
}
