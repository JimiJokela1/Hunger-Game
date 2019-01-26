using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private void Awake()
    {
        //  Bad
        if(SceneManager.GetActiveScene().name == "Main")
            SceneManager.LoadScene("UI", LoadSceneMode.Additive);
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

}
