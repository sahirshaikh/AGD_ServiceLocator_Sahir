using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    private string Level1 = "Level1";
    public static LevelManager Instance{ get{ return instance; } }

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        } else
        {
            Destroy(gameObject);
        }
    }

        private void Start()
    {
        if(GetLevelStatus(Level1) == LevelStatus.Locked)
        {
            SetLevelStatus(Level1, LevelStatus.Unlocked);
        }
    }

        public LevelStatus GetLevelStatus(string levelName)
    {
        LevelStatus levelStatus = (LevelStatus) PlayerPrefs.GetInt(levelName);
        return levelStatus;
    }

    public void SetLevelStatus(string levelName, LevelStatus levelStatus)
    {
        Debug.Log( "This Level: "+ levelName+ " is "+ levelStatus);
        PlayerPrefs.SetInt(levelName, (int) levelStatus);
    }

    public void SetCurrentLevelComplete()
    {
        SetLevelStatus(SceneManager.GetActiveScene().name, LevelStatus.Completed);

    }


}
