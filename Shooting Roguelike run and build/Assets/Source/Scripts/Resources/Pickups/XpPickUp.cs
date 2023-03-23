using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XpPickUp : MonoBehaviour, IPickUpObject
{
    [SerializeField] int amountXp;
    public void OnPickUp(Character character)
    {
        character.level.AddExperience(amountXp);
    }
}
