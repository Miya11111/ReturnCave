using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class displayPause : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    void Update()
    {
        //後にキー設定を変更
        if(Input.GetKey(KeyCode.Escape)){
            transform.Find("Pause").gameObject.SetActive(true);
            GameObject.Find("InputManager").gameObject.GetComponent<PlayerInput>().enabled = false;
                Time.timeScale = 0;
                audioSource.Pause();
        }
    }
}
