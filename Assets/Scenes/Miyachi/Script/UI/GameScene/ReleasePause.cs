using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleasePause : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private GameObject configObj;

    public void OnClick(){
        configObj.SetActive(false);
        Time.timeScale = 1;
        audioSource.UnPause();
    }
}
