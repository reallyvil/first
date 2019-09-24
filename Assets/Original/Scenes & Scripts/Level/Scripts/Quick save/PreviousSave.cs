using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviousSave : MonoBehaviour
{

    /* This void is where it records the players position
    when they saved */
    void Update()
    {
        transform.position += new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("vertical"));
    }
    public void LoadTheGame()
    {
        //reloads the level but in the position the player last was
        SaveGame.Load();
        transform.position = SaveGame.Instance.PlayerPosition;
    }
    public void Save()
    {
        // saves the game and position the player is
        SaveGame.Instance.PlayerPosition = transform.position;
        SaveGame.Save();
    }
}
