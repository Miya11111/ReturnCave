using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct StageList{
    public string name;
    public Sprite image;
}
public class ListStage : MonoBehaviour
{
    [SerializeField]
    private StageList[] stagelist;
    [SerializeField]
    private GameObject stageTemplete;
    [SerializeField]
    private float moveX;
    [SerializeField]
    private float moveY;
    void Start(){
        Vector2 buttonPos = this.transform.position;

        for(int i = 0; i < stagelist.Length; i++){
            GameObject stage = Instantiate(stageTemplete, this.transform.position, transform.rotation,this.transform ) as GameObject;
            stage.transform.position = buttonPos;
            StageProperty sProperty = stage.GetComponent<StageProperty>();
            sProperty.Create(stagelist[i].name,stagelist[i].image);
            
            buttonPos.x += moveX * Screen.width;
            //ボタンを3つ横に並べたら、一段下に移動
            if((i + 1) % 3 == 0){
                buttonPos.y += -moveY * Screen.height;
                buttonPos.x -= moveX * Screen.width * 3;
            }
            
        }
    }
}
