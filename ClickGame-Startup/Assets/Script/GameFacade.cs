using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFacade : MonoBehaviour {

    private static GameFacade instance;
    public static GameFacade GetInsstance()
    {
        if (instance == null)
        {
            instance = GameObject.FindObjectOfType<GameFacade>();
            if (instance == null)
            {
                throw new System.Exception("GameFacade不存在於場景中,請在場鏡中添加");

            }
           
        }
        return instance;
    }

    public StageData[] stageDatas;

}
