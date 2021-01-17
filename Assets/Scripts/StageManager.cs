using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager
{
    public Stage[] stages = new Stage[15];

    static StageManager instance = null;
    public static StageManager Instance
    {
        get
        {
            if(instance == null)
                instance = new StageManager();
                
            return instance;
        }

        set { instance = value; }
    }

    public StageManager()
    {
        for(int i=0;i<15;i++)
        {
            stages[i] = new Stage();
        }
        stages[0].isCleared = true;
        stages[0].Index = 1;
        stages[0].SceneName = "Stage1_1";
    }

}
