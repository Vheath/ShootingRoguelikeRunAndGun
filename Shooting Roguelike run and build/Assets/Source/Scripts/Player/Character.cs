using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] HealthBar hpBar;
    [HideInInspector] public Level level;
    [HideInInspector] public Coins coins;
    public int maxHp = 1000;
    public int currentHp = 1000;
    private float hpRegenerationRate = 1f;
    private float hpRegenerationTimer;
    private bool isDead;
    public int armor = 0;

    private void Awake()
    {
        level = GetComponent<Level>();
        coins = GetComponent<Coins>();
    }
    private void Start()
    {
        hpBar.SetState(currentHp, maxHp);
    }
    private void Update()
    {
        hpRegenerationTimer += Time.deltaTime * hpRegenerationRate;
        if (hpRegenerationTimer > 1f)
        {
            Heal(1);
            hpRegenerationTimer -= 1f;
        }
    }
    public void TakeDamage(int takenDamage)
    {
        if (isDead == true) { return; }
        currentHp -= takenDamage - armor > 0 ? takenDamage - armor : 0;

        if (currentHp <= 0)
        {
            GetComponent<CharacterGameOver>().GameOver();
            isDead = true;
        }

        hpBar.SetState(currentHp, maxHp);
    }

    public void Heal(int amount)
    {
        if (currentHp <= 0) { return; }
        currentHp += amount;
        if (currentHp > maxHp)
        {
            currentHp = maxHp;
        }
        hpBar.SetState(currentHp, maxHp);
    }
}
