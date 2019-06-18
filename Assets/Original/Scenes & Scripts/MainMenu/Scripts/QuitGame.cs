using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    // void for closing the app
    public void LeaveGame()
    {
        /* when the user clicks the quit
         the application will close and 
         I added the debug log to check
         that it worked*/
        Debug.Log ("You left the game");
        Application.Quit();
    }
}
