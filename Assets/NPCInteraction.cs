using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NPCInteraction : MonoBehaviour
{
    private GameObject dialoguePanel;
    private Text dialogueText;

    public string[] dialogue;
    private int index;
    public float wordSpeed;
    public bool playerIsClose = false;
    void Start()
    {
        dialoguePanel = GameObject.Find("DialoguePanel");
        dialoguePanel.SetActive(false);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Athlete"))
        {
            dialoguePanel.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Athlete"))
        {
            dialoguePanel.SetActive(false);
        }
    }
}
