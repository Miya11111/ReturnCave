using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayPause : MonoBehaviour
{

    void Update()
    {
        //後にキー設定を変更
        if(Input.GetKey(KeyCode.Escape)){
            transform.Find("Pause").gameObject.SetActive(true);
        }
    }
}
