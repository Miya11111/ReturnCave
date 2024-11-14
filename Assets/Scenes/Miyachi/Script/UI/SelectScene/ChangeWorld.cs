using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWorld : MonoBehaviour
{
    [SerializeField]
    private bool isRightButton = true;
    private WorldManager worldManager;
    private GameObject nextWorld;
    private float newWorldPosX;
    private float moveSpeedX;

    void Start(){
        //インスタンス化
        this.worldManager = FindObjectOfType<WorldManager>();

        if(isRightButton == true){
            newWorldPosX = 1000 * (Screen.width / 800);
            moveSpeedX = -10 * (Screen.width / 800);
        }
        else{
            newWorldPosX = -1000 * (Screen.width / 800);
            moveSpeedX = 10 * (Screen.width / 800);
        }
    }

    public void OnClick(){
        //移動した分のworldListの添え字を変更
        if(this.isRightButton == true) {
            if(WorldManager.worldIndex + 1 < worldManager.worldList.Length && worldManager.clearCount >= 2) {
                WorldManager.worldIndex++;
            } else {
                Debug.Log("ワールドの移動範囲外です！");
                return;
            }
        } else {
            if(WorldManager.worldIndex - 1 >= 0) {
                WorldManager.worldIndex--;
            } else {
                Debug.Log("ワールドの移動範囲外です！");
                return;
            }
        }

        //クリアしたステージ数を確認
        worldManager.CheckClearCount();

        //新しいワールドのインスタンスを生成
        GameObject nextWorldObj = worldManager.worldList[WorldManager.worldIndex];
        nextWorld = Instantiate(nextWorldObj, new Vector3(Screen.width / 2 + newWorldPosX,Screen.height / 2,0), transform.rotation,this.transform.root);

        //ワールド画面を移動させるためのコルーチン
        StartCoroutine("MoveWorld");
    }

    IEnumerator MoveWorld(){
        GameObject nowWorld = transform.parent.gameObject;
        for(int i = 0; i < 100; i++){
            nowWorld.transform.Translate(moveSpeedX ,0,0);
            nextWorld.transform.Translate(moveSpeedX ,0,0);
            yield return new WaitForSeconds(0.0005f);
        }

        Destroy(nowWorld);
        
    }
}
