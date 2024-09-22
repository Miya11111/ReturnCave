using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public GameObject[] worldList;    //後に[SerializeField] privateに変更
    //プロパティ
    [field: SerializeField]           //後に削除
    public GameObject[] enableWorldList {get; set;}
    public int worldListIndex {get; set;}

    //ゲームクリアを管理するbool配列(clearList)
    //clearListが2つ以上trueになったらenableWorldListに次のワールドを挿入
}


