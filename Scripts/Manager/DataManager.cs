using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance = null;

    public List<bool> stageComplete;
    public List<Stage> stages;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        // 저장한 스테이지 클리어 상태 로드
        stageComplete.Add(true);
        stageComplete.Add(false);
        stageComplete.Add(false);
        stageComplete.Add(false);
        stageComplete.Add(false);

        for (int i = 0; i < stages.Count; i++)
        {
            stages[i].Complete = stageComplete[i];
        }
    }

    public bool StageContains(string name)
    {
        int index = stages.FindIndex(i => i.Name == name);
        if (index != -1)
            return true;
        else
            return false;
    }

    public Stage GetStage(string name)
    {
        return stages[stages.FindIndex(i => i.Name == name)];
    }
}
