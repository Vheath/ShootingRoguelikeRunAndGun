using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEventManager : MonoBehaviour
{
    [SerializeField] StageData stageData;
    [SerializeField] EnemiesManager enemiesManager;
    StageTime stageTime;
    int eventIndexer = 0;
    private void Awake()
    {
        stageTime = GetComponent<StageTime>();
    }

    private void Update()
    {
        if (eventIndexer >= stageData.stageEvents.Count) { return; }

        if (stageTime.time > stageData.stageEvents[eventIndexer].time)
        {
            Debug.Log(stageData.stageEvents[eventIndexer].message);

            for (int i = 0; i < stageData.stageEvents[eventIndexer].countEnemy; i++)
            {
                enemiesManager.SpawnEnemy();
            }


            eventIndexer += 1;
        }
    }
}
