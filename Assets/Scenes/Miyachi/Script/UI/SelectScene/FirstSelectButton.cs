using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FirstSelectButton : MonoBehaviour
{
    public GameObject selectedParentButton;
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(SetButton), 0.1f);
    }

    // Update is called once per frame
    void SetButton()
    {
        GameObject selectedButton = selectedParentButton.transform.GetChild(0).gameObject;
        if(selectedButton != null){
            EventSystem.current.SetSelectedGameObject(selectedButton);
            Debug.Log("select:" + selectedButton.name);
        }
    }
}
