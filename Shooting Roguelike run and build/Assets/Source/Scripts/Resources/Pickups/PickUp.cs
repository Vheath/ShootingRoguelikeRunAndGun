using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Character character = other.GetComponent<Character>();
        if(character != null)
        {
            GetComponent<IPickUpObject>().OnPickUp(character);
            Destroy(gameObject);
        }
    }
}
