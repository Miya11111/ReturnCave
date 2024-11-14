using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseUI : MonoBehaviour
{
    [SerializeField]
    private GameObject configObj;

    public void OnClick(){
        configObj.SetActive(false);
    }
}
