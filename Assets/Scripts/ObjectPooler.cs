using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    private List<GameObject> ListOfObjects = new List<GameObject>();
    private Vector2 Position;

    private void Awake()
    {
        Position = transform.position; // 오브젝트 풀러의 위치 불러옴.
        int count = transform.childCount; // 하이라키 상의 자식 오브젝트 개수 불러옴.
        for (int i = 0; i < count; i++)
        {
            ListOfObjects.Add(transform.GetChild(i).gameObject); // 하이라키 상의 자식 오브젝트를 불러와 ListOfObject[i]에 저장.
            ListOfObjects[i].SetActive(false);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < ListOfObjects.Count; i++)
        {
            if (!ListOfObjects[i].activeInHierarchy)
                return ListOfObjects[i];
                
        }
        return ListOfObjects[ListOfObjects.Count - 1];
    }
}