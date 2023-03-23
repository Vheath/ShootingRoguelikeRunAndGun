using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WeaponStats
{
    public int damage;
    public float timeToAttack;
    public float areaScale = 1f;
    public int numberOfAttack;
    public WeaponStats(int damage, float timeToAttack, float areaScale, int numberOfAttack)
    {
        this.damage = damage;
        this.timeToAttack = timeToAttack;
        this.areaScale = areaScale;
        this.numberOfAttack = numberOfAttack;
    }

    internal void Sum(WeaponStats weaponUpgradeStats)
    {
        this.damage += weaponUpgradeStats.damage;
        this.timeToAttack -= weaponUpgradeStats.timeToAttack;
        this.areaScale += weaponUpgradeStats.areaScale;
        this.numberOfAttack += weaponUpgradeStats.numberOfAttack;
    }
}
[CreateAssetMenu]
public class WeaponData : ScriptableObject
{
    public string Name;
    public WeaponStats stats;
    public GameObject weaponBasePrefab;
    public List<UpgradesData> upgrades;
}
