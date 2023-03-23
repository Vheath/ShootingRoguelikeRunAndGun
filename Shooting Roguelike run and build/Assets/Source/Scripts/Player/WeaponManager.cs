using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] Transform weaponObjectsContainer;
    [SerializeField] WeaponData startingWeapon;
    List<WeaponBase> weaponsOnChar;

    private void Awake() {
        weaponsOnChar = new List<WeaponBase>();
    }
    private void Start()
    {
        AddWeapon(startingWeapon);
    }
    public void AddWeapon(WeaponData weaponData)
    {
        GameObject weaponGameObject = Instantiate(weaponData.weaponBasePrefab, weaponObjectsContainer);

        WeaponBase weaponBase = weaponGameObject.GetComponent<WeaponBase>();

        weaponBase.SetData(weaponData);
        weaponsOnChar.Add(weaponBase);
        weaponGameObject.GetComponent<WeaponBase>().SetData(weaponData);
        Level level = GetComponent<Level>();
        if (level != null)
        {
            level.AddUpgradesToAvailableListUgrades(weaponData.upgrades);
        }
    }

    public void UpgradeWeapon(UpgradesData upgradeData)
    {
        WeaponBase weaponToUpgrade = weaponsOnChar.Find(wd => wd.weaponData == upgradeData.weaponData);
        weaponToUpgrade.Upgrade(upgradeData);
    }
}
