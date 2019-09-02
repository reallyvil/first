using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GoToHelp : UnityEngine.MonoBehaviour
{
    // Void for changing scenes
    public void GettingHelp(string HowToPlay)
    {
        /* If the play button is clicked then 
         the user will load to the help scene*/
        SceneManager.LoadScene(HowToPlay);
    }
}

