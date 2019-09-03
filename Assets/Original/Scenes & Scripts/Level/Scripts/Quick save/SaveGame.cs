using UnityEngine;

public class SaveGame
{
    /* This script isn't mine is from this video
    https://www.youtube.com/watch?v=51y8kU_nEvc */

    //serialized
    public string PlayerName = "Player";
    public int XP = 0;
    public Vector3 PlayerPosition = Vector3.zero;

    private static string _gameDataFileName = "data.json";

    private static SaveGame _instance;
    public static SaveGame Instance
    {
        get
        {
            if (_instance == null)
                Load();
            return _instance;
        }

    }

    public static void Save()
    {
        FileManager.Save(_gameDataFileName, _instance);
    }

    public static void Load()
    {
        _instance = FileManager.Load<SaveGame>(_gameDataFileName);
    }

}