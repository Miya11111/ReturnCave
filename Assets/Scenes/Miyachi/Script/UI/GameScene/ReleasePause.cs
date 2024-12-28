using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ReleasePause : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private GameObject configObj;

    public void OnClick(){
        configObj.SetActive(false);
        GameObject.Find("InputManager").gameObject.GetComponent<PlayerInput>().enabled = true;
        Time.timeScale = 1;
        audioSource.UnPause();
    }
}
