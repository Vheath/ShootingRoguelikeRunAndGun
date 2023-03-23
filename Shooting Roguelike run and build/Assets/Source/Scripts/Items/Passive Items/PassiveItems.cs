using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveItems : MonoBehaviour
{
    [SerializeField] List<Item> items;
    Character character;

    private void Awake()
    {
        character = GetComponent<Character>();
    }
    private void Start()
    {
        items = new List<Item>();
    }
    public void Equip(Item itemToEquip)
    {
        if (items == null)
        {
            items = new List<Item>();
        }
        Item newItemInstance = new Item();
        newItemInstance.Init(itemToEquip.name);
        newItemInstance.stats.Sum(itemToEquip.stats);
        items.Add(itemToEquip);
        itemToEquip.Equip(character);
    }
    public void UnEquip(Item itemToUnEquip)
    {

    }

    internal void UpgradeItem(UpgradesData upgradeData)
    {
        Item itemToUpgrade = items.Find(id => id.Name == upgradeData.item.Name);
        itemToUpgrade.UnEquip(character);
        itemToUpgrade.stats.Sum(upgradeData.itemStats);
        itemToUpgrade.Equip(character);
    }
}
