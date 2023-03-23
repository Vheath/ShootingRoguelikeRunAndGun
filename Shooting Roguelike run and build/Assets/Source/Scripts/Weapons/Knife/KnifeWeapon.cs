using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeWeapon : WeaponBase
{
    [SerializeField] private GameObject KnifeLeft;
    [SerializeField] private GameObject knifeRight;
    public float areaScale = 1f;
    PlayerMovement playerMove;
    private void Awake()
    {
        playerMove = GetComponentInParent<PlayerMovement>();
        knifeRight.SetActive(false);
        KnifeLeft.SetActive(false);
    }

    public override void Attack()
    {
        StartCoroutine(AttackProcess());
    }
    IEnumerator AttackProcess()
    {
        for (int i = 0; i < weaponStats.numberOfAttack; i++)
        {
            if (playerMove.lastHorizontalVector > 0)
            {
                knifeRight.SetActive(true);
            }
            else
            {
                KnifeLeft.SetActive(true);
            }
            yield return new WaitForSeconds(0.3f);
        }
    }
}
