using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MessageSystem : MonoBehaviour
{
    [SerializeField] GameObject damageMessage;
    List<TMPro.TextMeshPro> messagePool;
    public static MessageSystem instance;
    private int damageMessageCount = 25;
    private int damageMessageNumber;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        messagePool = new List<TMPro.TextMeshPro>();
        for (int i = 0; i < damageMessageCount; i++)
        {
            Populate();
        }
    }
    public void Populate()
    {
        GameObject go = Instantiate(damageMessage, transform);
        messagePool.Add(go.GetComponent<TMPro.TextMeshPro>());
        go.SetActive(false);
    }
    public void PostMessage(string text, Vector3 worldPosition)
    {
        messagePool[damageMessageNumber].gameObject.SetActive(true);
        messagePool[damageMessageNumber].transform.position = worldPosition;
        messagePool[damageMessageNumber].text = text;
        damageMessageNumber += 1;
        if (damageMessageNumber >= damageMessageCount)
        {
            damageMessageNumber = 0;
        }
    }
}

