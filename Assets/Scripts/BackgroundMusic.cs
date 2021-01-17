using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public void stopmusic()
    {
        Destroy(gameObject);
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
