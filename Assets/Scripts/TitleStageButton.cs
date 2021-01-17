using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleStageButton : MonoBehaviour
{
    [SerializeField]
    Text IndexText;

    [SerializeField]
    Stage StageProperties;

    public void OnEnable()
    {
        if(StageManager.Instance.stages[0].Index == 0)
        StageManager.Instance.stages[StageProperties.Index - 1] = StageProperties;
        else
        StageProperties = StageManager.Instance.stages[StageProperties.Index - 1];
        
        IndexText = transform.GetChild(0).GetComponent<Text>();
        IndexText.text = this.StageProperties.Index.ToString();
    }

    public void DebugProperties()
    {
        SceneManager.LoadScene(this.StageProperties.SceneName);
    }


}
