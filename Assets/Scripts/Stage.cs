using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stage
{
    //이 클래스는 모노비헤이비어 자식 클래스가 아니라서 오브젝트에 넣어주려면 새 클래스를 만들어서 넣어주세요

    public int Index = 0;
    public bool isCleared = false;
    public string SceneName;

}
