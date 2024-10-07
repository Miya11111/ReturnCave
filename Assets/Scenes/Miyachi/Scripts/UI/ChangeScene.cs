using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    private String sceneName;
    // Start is called before the first frame update
    public void OnClick()
    {
        SceneManager.LoadScene(sceneName);
    }
}
