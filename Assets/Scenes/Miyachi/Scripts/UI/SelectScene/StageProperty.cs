using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageProperty : MonoBehaviour
{
    public void Create(string stageName, Sprite stageImage){
        GameObject buttonText = transform.Find("StageText").gameObject;
        //ステージ画像変更
        Image buttonImg = this.GetComponent<Image>();
        buttonImg.sprite = stageImage;
        //ステージ名変更
        buttonText.GetComponent<UnityEngine.UI.Text>().text = stageName;
    }
}
