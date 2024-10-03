using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JoinStage : MonoBehaviour
{
    
    private Text stageName;
    // Start is called before the first frame update
    void Start()
    {
        GameObject buttonText = transform.Find("StageText").gameObject;
        stageName = buttonText.GetComponent<Text>();
    }

    // Update is called once per frame
    public void OnClick(){
        SceneManager.LoadScene(stageName.text);
    }
}
