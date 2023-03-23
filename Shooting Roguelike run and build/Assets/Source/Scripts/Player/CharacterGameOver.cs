using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGameOver : MonoBehaviour
{
    [SerializeField] GameObject weaponParent;
    public GameObject gameOverPanel;
    public void GameOver()
    {
        Debug.Log("Game Over");   
        GetComponent<Collider2D>().isTrigger = true;
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        gameOverPanel.SetActive(true);
        weaponParent.SetActive(false);
    }
}
