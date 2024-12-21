using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CloseUI : MonoBehaviour
{
    [SerializeField]
    private GameObject configObj;

    [SerializeField]
    GameObject gameObj;

    public void OnClick(){

        // [せってい]ボタンのオブジェクトを選択
        EventSystem.current.SetSelectedGameObject(gameObj);

        configObj.SetActive(false);
    }
}
