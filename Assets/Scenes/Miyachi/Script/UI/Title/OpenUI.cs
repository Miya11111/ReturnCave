using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenUI : MonoBehaviour
{
    [SerializeField]
    private GameObject configObj;

    [SerializeField]
    GameObject gameObj;

    public void OnClick(){
    configObj.SetActive(true);

        // [�ɂق�]�{�^���̃I�u�W�F�N�g��I��
        EventSystem.current.SetSelectedGameObject(gameObj);
    }
}
