using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ChangeScene : UnityEngine.MonoBehaviour
{
    // Void for changing scenes
    void Load()
    {
        // if user clicks the play button
        if (UnityEngine.Input.GetMouseButtonDown(0))
            SceneManager.LoadScene("Level");
    }
}
