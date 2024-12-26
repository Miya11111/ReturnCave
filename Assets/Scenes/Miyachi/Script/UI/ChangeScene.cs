using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    [SerializeField]
    private String sceneName;
    [SerializeField]
    private bool isReleasePause;


    public void OnClick()
    {

        if (isReleasePause){
            Time.timeScale = 1;
        }
        SceneManager.LoadScene(sceneName);
    }
}
