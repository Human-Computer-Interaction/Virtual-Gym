using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NPCInteraction : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;

    public string[] dialogue;
    private int index;
    public float wordSpeed;
    public bool playerIsClose;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "NPC")
        {
            playerIsClose = true;
        }
    }
    void Update()
    {
        
    }
}
