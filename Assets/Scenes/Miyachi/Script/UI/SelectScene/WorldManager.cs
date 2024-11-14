using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    [field:SerializeField]
    public GameObject[] worldList {get; set;}
    //現在いるワールド
    public static int worldIndex;
    //現在いるステージ
    public static int stageIndex;

    public int clearCount { get; set; }

    public TextAsset saveData;
    private ListStage listStage;
    

  
    void Start(){
        Instantiate(worldList[worldIndex],this.transform.position, transform.rotation,this.transform.root);
        CheckClearCount();
    }

    //クリアしたステージ数を調べる関数(2ステージ以上で次のステージに進める)
    public void CheckClearCount(){
        //インスタンス化
        this.listStage = FindObjectOfType<ListStage>();
        //初期化
        clearCount = 0;

        //jsonファイルのデータを取得
        string jsonText = saveData.ToString();
        SaveData save = JsonUtility.FromJson<SaveData>(jsonText);

        //クリアしたステージ数を確認
        for(int i = 0; i < listStage.stagelist.Length; i++){
            if(save.worldData[worldIndex].stageData[i].isClear == true){
                clearCount++;
            }
        }
        Debug.Log(clearCount);
    }
}


