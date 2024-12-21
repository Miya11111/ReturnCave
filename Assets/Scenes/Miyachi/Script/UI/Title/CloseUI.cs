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

        // [�����Ă�]�{�^���̃I�u�W�F�N�g��I��
        EventSystem.current.SetSelectedGameObject(gameObj);

        configObj.SetActive(false);
    }
}
