using System.IO;
using Newtonsoft.Json.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalHandler : MonoBehaviour
{
    private string filePath;
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            //クリアしたデータの保存
            filePath = Application.dataPath + "/SaveData/ClearData.json";
            if(File.Exists(filePath))
            {
                //Jsonファイルの読み込み
                string json = File.ReadAllText(filePath);
                JObject jsonObject = JObject.Parse(json);

                jsonObject["worldData"][WorldManager.worldIndex]["stageData"][WorldManager.stageIndex]["isClear"] = true;

                //Jsonファイルに書き込み
                File.WriteAllText(filePath, jsonObject.ToString());

                // ファイルを書き込んだ後にアセットをリフレッシュ　※これがないとクリアデータが即時反映されない
                File.WriteAllText(filePath, jsonObject.ToString());
                // AssetDatabase.Refresh(); // アセットのリフレッシュを強制 
            }

            //シーンの読み込み
            SceneManager.LoadScene("SelectScene");
        }
    }
}
