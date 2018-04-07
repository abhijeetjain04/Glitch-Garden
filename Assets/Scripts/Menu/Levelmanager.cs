using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levelmanager : MonoBehaviour
{
    public float autoLoadNextLevelAuto;

    private void Start()
    {
        if(autoLoadNextLevelAuto != 0 && autoLoadNextLevelAuto >= 0)
        Invoke("LoadNextLevel", autoLoadNextLevelAuto);
    }

    public void loadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void LoadNextLevel()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //SceneManager.LoadScene(Application.loadedLevel + 1);
    }

    public void QuitApplication()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}
