using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;

public class StageProperty : MonoBehaviour
{
    public int sIndex;
    public void Create(string stageName, Sprite stageImage, int index ){
        GameObject buttonText = transform.Find("StageText").gameObject;
        //ステージ画像変更
        Image buttonImg = this.GetComponent<Image>();
        buttonImg.sprite = stageImage;
        //ステージ名変更
        buttonText.GetComponent<UnityEngine.UI.Text>().text = stageName;
        //ステージ番号の取得
        sIndex = index;
    }
}
