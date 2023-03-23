using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] ExperienceBar experienceBar;
    [SerializeField] UpgradeMenuManager upgradeMenuManager;
    [SerializeField] List<UpgradesData> upgrades;
    [SerializeField] List<UpgradesData> acquiredUpgrades;
    [SerializeField] List<UpgradesData> upgradeAvailableOnStart;
    List<UpgradesData> selectedUpgrades;

    WeaponManager weaponManager;
    PassiveItems passiveItems;
    int level = 1;
    int experience = 0;

    private void Awake()
    {
        weaponManager = GetComponent<WeaponManager>();
        passiveItems = GetComponent<PassiveItems>();
    }
    private void Start()
    {
        experienceBar.UpdateExperienceSlider(experience, ToLevelUp);
        experienceBar.SetLevelText(level);
        AddUpgradesToAvailableListUgrades(upgradeAvailableOnStart);
    }
    int ToLevelUp
    {
        get
        {
            return level * 1000;
        }
    }
    public void AddExperience(int amount)
    {
        experience += amount;
        CheckLevelUp();
        experienceBar.UpdateExperienceSlider(experience, ToLevelUp);
    }

    public void CheckLevelUp()
    {
        if (experience >= ToLevelUp)
        {
            LevelUp();
        }
    }
    private void LevelUp()
    {
        if (selectedUpgrades == null) { selectedUpgrades = new List<UpgradesData>(4); }
        selectedUpgrades.Clear();
        selectedUpgrades.AddRange(GetUpgrades(4));

        upgradeMenuManager.OpenPanel(selectedUpgrades);
        experience -= ToLevelUp;
        level += 1;
        experienceBar.SetLevelText(level);
    }
    public List<UpgradesData> GetUpgrades(int count)
    {
        List<UpgradesData> upgradeList = new List<UpgradesData>();
        if (count > upgrades.Count)
        {
            count = upgrades.Count;
        }
        for (int i = 0; i < count; i++)
        {
            upgradeList.Add(upgrades[Random.Range(0, upgrades.Count)]);
        }

        return upgradeList;
    }

    public void Upgrade(int selectedUpgradeID)
    {
        UpgradesData upgradeData = selectedUpgrades[selectedUpgradeID];
        if (acquiredUpgrades == null) { acquiredUpgrades = new List<UpgradesData>(); }
        switch (upgradeData.upgradyType)
        {
            case UpgradyType.WeaponUpgrade:
                {
                    weaponManager.UpgradeWeapon(upgradeData);
                    break;
                }
            case UpgradyType.WeaponUnlock:
                {
                    weaponManager.AddWeapon(upgradeData.weaponData);
                    break;
                }
            case UpgradyType.ItemmUpgrade:
                {
                    passiveItems.UpgradeItem(upgradeData);
                    break;
                }
            case UpgradyType.ItemUnlock:
                {
                    passiveItems.Equip(upgradeData.item);
                    AddUpgradesToAvailableListUgrades(upgradeData.item.upgrades);
                    break;
                }
        }
        acquiredUpgrades.Add(upgradeData);
        upgrades.Remove(upgradeData);
    }

    internal void AddUpgradesToAvailableListUgrades(List<UpgradesData> upgradesToAdd)
    {
        if (upgradesToAdd == null) { return; }
        this.upgrades.AddRange(upgradesToAdd);
    }
}
