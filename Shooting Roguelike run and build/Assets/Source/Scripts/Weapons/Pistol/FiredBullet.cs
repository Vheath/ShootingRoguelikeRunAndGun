using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiredBullet : MonoBehaviour
{
    [SerializeField] float speed;
    MessageSystem message;
    private int damage;
    PistolWeapon parent;
    Rigidbody2D rb;
    Vector3 direction;
    Vector2 moveDirection;
    float timeToLeave = 4f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Attack(Transform target, int damage) //directs bullet to target
    {
        this.damage = damage;
        moveDirection = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, timeToLeave);
    }
    private void OnTriggerEnter2D(Collider2D collision) //On trigger with other collider2d add damage to it
    {
        IDamageable e = collision.gameObject.GetComponent<IDamageable>();
        if (e != null)
        {         
            e.TakeDamage(damage);
            Destroy(gameObject);
            MessageSystem.instance.PostMessage(damage.ToString(), collision.transform.position);
        }
    }
}
