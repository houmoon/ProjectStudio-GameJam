using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Portal : Object
{
    public int stagenumber;
    public string nextstage;

    public void Start()
    {
        SetCallBack(GotoNextStage);
    }

    public void GotoNextStage()
    {
       StageManager.Instance.stages[stagenumber - 1].isCleared = true;
       StageManager.Instance.stages[stagenumber - 1].Index = stagenumber;
       StageManager.Instance.stages[stagenumber - 1].SceneName = SceneManager.GetActiveScene().name;
       SceneManager.LoadScene(nextstage);
    }
}
