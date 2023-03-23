using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
     Transform targetDestination;
    [SerializeField] float speed;
    [SerializeField] public int hp = 500;
    [SerializeField] int damage = 10;
    [SerializeField] int experienceReward = 400;
    Character targetCharacter;
    GameObject targetGameObject;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetTarget(GameObject target)
    {
        targetGameObject = target;
        targetDestination = target.transform;
    }
    private void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rb.velocity = direction * speed;
        ChangeLookDirection();
    }

    private void ChangeLookDirection()
    {
        
        if (targetDestination.transform.position.x > gameObject.transform.position.x ) gameObject.transform.localScale = new Vector3(1, 1, 1);
        else if (targetDestination.transform.position.x < gameObject.transform.position.x)  gameObject.transform.localScale = new Vector3(-1, 1, 1);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject == targetGameObject)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if(targetCharacter == null)
        {
            targetCharacter = targetGameObject.GetComponent<Character>();
        }

        targetCharacter.TakeDamage(damage);

    }
    public void TakeDamage(int damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            targetGameObject.GetComponent<Level>().AddExperience(experienceReward);
            GetComponent<DropOnDestroy>().CheckDrop();
            Destroy(gameObject);
        }
    }
}
