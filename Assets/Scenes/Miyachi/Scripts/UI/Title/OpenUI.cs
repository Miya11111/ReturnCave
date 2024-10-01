using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUI : MonoBehaviour
{
    [SerializeField]
    private GameObject configObj;
 public void OnClick(){
    configObj.SetActive(true);
 }
}
