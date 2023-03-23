using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpgradyType
{
    WeaponUpgrade,
    ItemmUpgrade,
    WeaponUnlock,
    ItemUnlock
}
[CreateAssetMenu]
public class UpgradesData : ScriptableObject
{
    public UpgradyType upgradyType;
    public string Name;
    public Sprite icon;

    public WeaponData weaponData;
    public WeaponStats weaponUpgradeStats;

    public Item item;
    public ItemStats itemStats;
}
