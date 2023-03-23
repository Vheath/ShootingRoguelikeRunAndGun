using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemStats
{
    public int armor;


    internal void Sum(ItemStats stats)
    {
        armor += stats.armor;
    }
}
[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string Name;
    public ItemStats stats;
    public List<UpgradesData> upgrades;
    public void Init(string Name)
    {
        this.Name = Name;
        stats = new ItemStats();
        upgrades = new List<UpgradesData>();
    }

    public void Equip(Character character)
    {
        character.armor += stats.armor;
    }

    internal void UnEquip(Character character)
    {
        character.armor -= stats.armor;
    }
}
