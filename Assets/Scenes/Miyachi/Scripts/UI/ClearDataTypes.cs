
[System.Serializable]
public class SaveData{
    public WorldData[] worldData;
}

[System.Serializable]
public class WorldData{
    public StageData[] stageData;

    public WorldData(int stageCount)
    {
        stageData = new StageData[stageCount];
    }
}

[System.Serializable]
public class StageData{
    public bool isClear;
}
