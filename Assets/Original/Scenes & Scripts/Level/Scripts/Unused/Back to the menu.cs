using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Backtothemenu : UnityEngine.MonoBehaviour
{
    // Start is called before the first frame update
    void Menu(string main_menu)
    {
        SceneManager.LoadScene(main_menu);
    }
}
