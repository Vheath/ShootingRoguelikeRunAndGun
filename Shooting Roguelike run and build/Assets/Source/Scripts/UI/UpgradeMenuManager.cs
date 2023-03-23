using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenuManager : MonoBehaviour
{
    [SerializeField] GameObject panel;
    PauseManager pauseManager;
    [SerializeField] List<UpgradeButton> upgradeButtons;
    private void Awake()
    {
        pauseManager = GetComponent<PauseManager>();
    }
    private void Start()
    {
        HideButtons();
    }
    public void Upgrade(int pressedButton)
    {
        GameManager.instance.playerTransform.GetComponent<Level>().Upgrade(pressedButton);
        ClosePanel();
    }
    public void Clean()
    {
        for (int i = 0; i < upgradeButtons.Count; i++)
        {
            upgradeButtons[i].Clean();
        }
    }
    public void ClosePanel()
    {
        HideButtons();

        pauseManager.PauseGame(false);
        panel.SetActive(false);
    }

    public void HideButtons()
    {
        for (int i = 0; i < upgradeButtons.Count; i++)
        {
            upgradeButtons[i].gameObject.SetActive(false);
        }
    }

    public void OpenPanel(List<UpgradesData> upgradesDatas)
    {
        Clean();
        pauseManager.PauseGame(true);
        panel.SetActive(true);

        for (int i = 0; i < upgradesDatas.Count; i++)
        {
            upgradeButtons[i].gameObject.SetActive(true);
            upgradeButtons[i].Set(upgradesDatas[i]);
        }
    }
}
