using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteraction : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public GameObject continueButton;
    public GameObject characteristicsInputPanel;
    public GameObject gameManagerComponent;
    private GameManager gameManager;

    public string[] dialogue;
    private int index;
    public float wordSpeed;
    public bool playerIsClose;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Athlete"))
        {
            playerIsClose = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Athlete"))
        {
            playerIsClose = false;
            ZeroText();
        }
    }
    void Start()
    {
        gameManager = gameManagerComponent.GetComponent<GameManager>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if (dialoguePanel.activeInHierarchy)
            {
                ZeroText();
            }
            else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }
        if (dialogueText.text == dialogue[index])
        {
            continueButton.SetActive(true);
        }
        //if index == 
    }
    public void ZeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }
    public void NextLine()
    {
        continueButton.SetActive(false);
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else if (index == dialogue.Length - 1)
        {
            dialoguePanel.SetActive(false);
            characteristicsInputPanel.SetActive(true);
            //PlayerStats playerStats = new PlayerStats(70f, 100f, 100f, 1.80f, 30);
        }
    }
    public void PassInputsToGameManager()
    {
        var inputsFields = characteristicsInputPanel.GetComponentsInChildren<TMP_InputField>();
        gameManager.playerStats.Weight = Math.Abs(float.Parse(inputsFields[0].text));
        gameManager.playerStats.Height = Math.Abs(float.Parse(inputsFields[1].text));
        gameManager.playerStats.Age = Math.Abs(int.Parse(inputsFields[2].text));
        
        characteristicsInputPanel.SetActive(false);
        inputsFields[0].text = "";
        inputsFields[1].text = "";
        inputsFields[2].text = "";

        // print(gameManager.playerStats);
        // print(gameManager.CalculateBMI(gameManager.playerStats));

    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }
}
