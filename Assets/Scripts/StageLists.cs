using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageLists : MonoBehaviour
{
    public List<TitleStageButton> buttons;
    public int startnum;

    private void Awake()
    {
        for(int i=startnum; i<buttons.Count; i++)
        {
            if(StageManager.Instance.stages[i].isCleared)
                buttons[i].gameObject.SetActive(true);
        }
    }

}
