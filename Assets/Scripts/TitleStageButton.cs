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

    public void Start()
    {
        IndexText = transform.GetChild(0).GetComponent<Text>();
        IndexText.text = this.StageProperties.Index.ToString();
    }

    public void DebugProperties()
    {
        Debug.Log(this.StageProperties.Index + ", " + this.StageProperties.isCleared + ", " + this.StageProperties.SceneName);
    }


}
