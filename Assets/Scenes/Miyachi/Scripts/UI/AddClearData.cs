using System.IO;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class AddClaerData : MonoBehaviour
{
    private string filePath;
    //たぶん使わない.テスト用
    void Start()
    {

        Debug.Log(WorldManager.worldIndex + "-" + WorldManager.stageIndex);

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
        }
        //クリアしたデータの保存
        // SaveData save = new SaveData();
        // save.worldData = new WorldData[3];
        // save.worldData[WorldManager.worldIndex] = new WorldData(9);
        // save.worldData[WorldManager.worldIndex].stageData[WorldManager.stageIndex] = new StageData
        // {
        //     isClear = true
        // };

        

        // string json = JsonUtility.ToJson(save, true);
        // StreamWriter streamWriter = new StreamWriter(detaPath);
        // streamWriter.Write(json);
        // streamWriter.Flush();
        // streamWriter.Close();
    }
}
