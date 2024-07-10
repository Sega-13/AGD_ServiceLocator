using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    private static MapManager instance;
    public static MapManager Instance {  get { return instance; } }
    [SerializeField] private string[] maps;
    int index = 0;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    private void Start()
    {
        if (GetMapSatus(maps[0]) == MapStatus.Locked)
        {
            SetMapStatus(maps[0], MapStatus.UnLocked); 
        }
    }
    public MapStatus GetMapSatus(string maps)
    {
        MapStatus mapStatus = (MapStatus)PlayerPrefs.GetInt(maps,0);
        return mapStatus;
    }
    private void SetMapStatus(string maps, MapStatus mapStatus)
    {
        PlayerPrefs.SetInt(maps,(int)mapStatus);
    }
    public void MarkMapCompleted()
    {
        SetMapStatus(maps[index], MapStatus.Completed);
        index++;
        if(maps.Length > index)
        {
            SetMapStatus(maps[index], MapStatus.UnLocked);
        }
    }
}
