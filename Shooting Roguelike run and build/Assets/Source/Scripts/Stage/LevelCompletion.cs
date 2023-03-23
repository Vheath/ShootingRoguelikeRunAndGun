using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletion : MonoBehaviour
{
    [SerializeField] float timeToCompleteLevel;
    PauseManager pauseManager;
    StageTime stageTime;
    GameWinPanel levelComletePanel;

    private void Start()
    {
        stageTime = GetComponent<StageTime>();
        pauseManager = FindObjectOfType<PauseManager>();
        levelComletePanel = FindObjectOfType<GameWinPanel>(true);
    }

    public void Update()
    {
        if (stageTime.time > timeToCompleteLevel)
        {
            pauseManager.PauseGame(true);
            levelComletePanel.gameObject.SetActive(true);
        }
    }
}
