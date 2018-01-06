using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFacade : MonoBehaviour
{
    private static GameFacade instance;
    public static GameFacade GetInstance()
    {
        if (instance == null)
        {
            instance = GameObject.FindObjectOfType<GameFacade>();
            if(instance == null)
            {
                throw new System.Exception("GameFacade不存在於場景中，請在場景中添加");
            }
            instance.Initialize();
        }
        return instance;
    }

    public StageData[] stageDatas;
    public LevelData leveldata;
    public PlayerData playerData;

    private void Initialize()
    {
        playerData = new PlayerData();

    }
    private void Awake()
    {
        GetInstance();
    }

}
