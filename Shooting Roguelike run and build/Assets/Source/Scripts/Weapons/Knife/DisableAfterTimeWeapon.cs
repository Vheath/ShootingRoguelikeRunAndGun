using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterTimeWeapon : MonoBehaviour
{
    private float areaScale;
    private int damage;
    private void OnEnable()
    {
        damage = GetComponentInParent<KnifeWeapon>().weaponStats.damage;
        areaScale = GetComponentInParent<KnifeWeapon>().weaponStats.areaScale;
        IEnumerator coroutine = SlowScale();
        StartCoroutine(coroutine);
    }
    private void OnTriggerEnter2D(Collider2D collision) //deal damage if the enemy is collision
    {

        IDamageable e = collision.gameObject.GetComponent<IDamageable>();
        if (e != null)
        {
            GetComponentInParent<KnifeWeapon>().PostMessage(damage, collision.transform.position);
            e.TakeDamage(damage);
        }
    }
    IEnumerator SlowScale() //use ienumerator for straight slow scaling animation out attack
    {
        if (transform.localScale.x > 0)
        {
            for (float q = 0.1f * areaScale; q < areaScale; q += 0.1f * areaScale)
            {
                transform.localScale = new Vector3(q, q, q); //slow scale
                yield return new WaitForSeconds(.02f);
            }
        }
        else
        {
            for (float q = -0.1f * areaScale; q > -1f * areaScale; q -= 0.1f * areaScale)
            {
                transform.localScale = new Vector3(q, -q, -q);
                yield return new WaitForSeconds(.02f);
            }
        }
        gameObject.SetActive(false);
    }

}
