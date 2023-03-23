using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour, IDamageable
{
    [SerializeField] bool NeedAnimator;
    private Animator animator;
    private void Start()
    {
        if (NeedAnimator) animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        if (NeedAnimator)
            animator.SetBool("Destroy", true);
        else Destroy();
    }
    private void Destroy()
    {
        GetComponent<DropOnDestroy>().CheckDrop();
        Destroy(gameObject);
    }
}
