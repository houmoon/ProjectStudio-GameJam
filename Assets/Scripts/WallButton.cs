using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallButton : Object
{
    public List<Wall> Walls;

    private void Start()
    {
        Interactable = true;
        SetCallBack(Toggle);
    }

    public void Toggle()
    {
        for(int i =0; i<Walls.Count; i ++)
        {
            Walls[i].Toggle();
        }
    }
}
