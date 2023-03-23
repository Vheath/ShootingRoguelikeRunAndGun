using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PistolWeapon : WeaponBase
{
    [SerializeField] GameObject BulletPrefab;
    private int damage;
    GameObject enemiesParent;
    GameObject firedBullet;
    Transform attackTarget;
    List<GameObject> bullets;
    private void Start()
    {
        enemiesParent = GameObject.Find("EnemiesSpawn");
        bullets = new List<GameObject>();
    }
    Transform GetClosestEnemy(GameObject enemies) //Return nearest enemy position
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (Transform child in enemies.transform)
        {
            Vector3 directionToTarget = child.position - currentPosition;
            float directionToTargetSqr = directionToTarget.sqrMagnitude;
            if (directionToTargetSqr < closestDistanceSqr)
            {
                closestDistanceSqr = directionToTargetSqr;
                bestTarget = child;
            }
        }
        return bestTarget;
    }
    private void Shoot()
    {
        StartCoroutine(Waiter());
    }
    public override void Attack() //spawn bullet within 0.01 sec for a generation
    {
        if (enemiesParent.transform.childCount > 0)
        {
            damage = weaponStats.damage;
            for (int i = 0; i < weaponStats.numberOfAttack; i++)
            {
                firedBullet = Instantiate(BulletPrefab);
                firedBullet.transform.position = transform.position;
                bullets.Add(firedBullet);
            }
            Invoke("Shoot", 0.02f);
        }
    }
    IEnumerator Waiter()
    {
        foreach (var item in bullets)
        {
            item.GetComponent<FiredBullet>().Attack(GetClosestEnemy(enemiesParent), damage);
            yield return new WaitForSeconds(0.08f);
        }
        bullets.Clear();
    }
}
