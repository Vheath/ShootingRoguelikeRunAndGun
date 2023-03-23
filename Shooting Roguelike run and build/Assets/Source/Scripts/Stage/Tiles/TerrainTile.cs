using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TerrainTile : MonoBehaviour
{
    [SerializeField] Vector2Int tilePosition;
    [SerializeField] List<SpawnObject> spawnObjects;
    WorldScrolling worldScrolling;


    void Start()
    {
        worldScrolling = GetComponentInParent<WorldScrolling>();
        worldScrolling.Add(gameObject, tilePosition);

    }

    public void Spawn()
    {
        for(int i = 0; i <spawnObjects.Count; i++)
        {
            spawnObjects[i].Spawn();
        }
    }

}
