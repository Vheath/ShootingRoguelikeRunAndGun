using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    public WeaponStats weaponStats;
    public WeaponData weaponData;
    public float timeToAttack = 1f;
    private float timer;
    public void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            Attack();
            timer = weaponStats.timeToAttack;
        }
    }
    public virtual void SetData(WeaponData wd)
    {
        weaponData = wd;

        weaponStats = new WeaponStats(wd.stats.damage, wd.stats.timeToAttack, wd.stats.areaScale, wd.stats.numberOfAttack);
    }

    public abstract void Attack();

    public virtual void PostMessage(int damage, Vector3 targetPosition)
    {
        MessageSystem.instance.PostMessage(damage.ToString(), targetPosition);
    }

    public void Upgrade(UpgradesData upgradeData)
    {
        weaponStats.Sum(upgradeData.weaponUpgradeStats);
    }
}
