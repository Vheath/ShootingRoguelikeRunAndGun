using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] TextMeshProUGUI upgradeText;

    public void Set(UpgradesData upgradesData)
    {
        icon.sprite = upgradesData.icon;
        upgradeText.text = upgradesData.Name;
        if(upgradesData.upgradyType == UpgradyType.WeaponUnlock) upgradeText.color = Color.yellow;
    }

    internal void Clean()
    {
        icon.sprite = null;
        upgradeText.text = null;
        upgradeText.color = Color.black;
    }
}
