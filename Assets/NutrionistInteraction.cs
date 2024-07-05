using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class NutrionistInteraction : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public GameObject continueButton;
    public GameObject gameManagerComponent;
    private GameManager gameManager;
    private GameObject playerCameraRotation;
    private GameObject playerCamera;

    public GameObject getProgramButton;
    private List<string> dialogue;
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
        playerCameraRotation = GameObject.Find("Athlete");
        playerCamera = GameObject.Find("Camera");
        gameManager = gameManagerComponent.GetComponent<GameManager>();

        if (gameManager == null)
        {
            Debug.LogError("GameManager component is not assigned!");
            return;
        }
        InitializeDialogue();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            HandleInteraction();
        }
        if (dialogueText.text == dialogue[index])
        {
            continueButton.SetActive(true);
        }
    }

    private void HandleInteraction()
    {
        playerCameraRotation.GetComponentInChildren<MouseLook>().enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        playerCamera.transform.rotation = Quaternion.Euler(new Vector3(12f, 88f, 0f));

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

    private void InitializeDialogue()
    {
        if (gameManager.physicalCondition == "Unknown")
        {
            dialogue = new List<string>
            {
                "Welcome to PADA Gym!",
                "You should talk to the fitness instructor to check your physical condition."
            };
        }
    }

    public void ZeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
        playerCameraRotation.GetComponentInChildren<MouseLook>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void NextLine()
    {
        continueButton.SetActive(false);
        if (gameManager.hasSpokenToNpc)
        {
            PassInputsToGameManager();
        }
        if (index < dialogue.Count - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else if (index == dialogue.Count - 1)
        {
            dialoguePanel.SetActive(false);
            playerIsClose = false;
        }
    }

    public void PassInputsToGameManager()
    {
        Debug.Log("Calling PassInputsToGameManager");
        gameManager.ActivatePanel();
        FoodProgramBasedOnPhysicalCondition();
    }

    public void FoodProgramBasedOnPhysicalCondition()
    {
        dialogue.Clear();
        Debug.Log("Physical Condition: " + gameManager.physicalCondition);

        switch (gameManager.physicalCondition)
        {
            case "Underweight":
                dialogue.Add("You are 'Underweight' so I created a food program for you.");
                dialogue.Add("The fitness instructor gave you a program that will help you gain muscle, but you will have to eat more.");
                dialogue.Add("Let me show you what to buy from the vending machine.");
                dialogue.Add("Your food program is ready.");
                dialogue.Add("1 protein, 1 creatine, 1 dipping zone");
                dialogue.Add("Goal: Significant weight gain and stamina improvement.");
                dialogue.Add("It will cost you 75$.");
                
                break;

            case "Normal":
                dialogue.Add("You are 'Normal' so I created a food program for you.");
                dialogue.Add("The fitness instructor gave you a program that will help you maintain your weight.");
                dialogue.Add("Let me show you what to buy from the vending machine.");
                dialogue.Add("Your food program is ready.");
                dialogue.Add("1 energy drink, 1 protein, 1 pair of gloves");
                dialogue.Add("Goal: Moderate weight gain and stamina improvement.");
                dialogue.Add("It will cost you 35$.");
                break;

            case "Overweight":
                dialogue.Add("You are 'Overweight' so I created a food program for you.");
                dialogue.Add("The fitness instructor gave you a program that will help you to lose weight, but you will have to eat less.");
                dialogue.Add("Let me show you what to buy from the vending machine.");
                dialogue.Add("Your food program is ready.");
                dialogue.Add("2 energy drinks, 1 pair of gloves");
                dialogue.Add("Goal: Minimal weight gain but significant stamina improvement.");
                dialogue.Add("It will cost you 20$.");
                break;

            case "Obese":
                dialogue.Add("You are 'Obese' so I created a food program for you.");
                dialogue.Add("The fitness instructor gave you a program that will help you to lose weight, but you will have to eat less.");
                dialogue.Add("Let me show you what to buy from the vending machine.");
                dialogue.Add("Your food program is ready.");
                dialogue.Add("1 energy drink, 1 pair of gloves");
                dialogue.Add("Goal: Minimal weight gain and minimal stamina improvement.");
                dialogue.Add("It will cost you 15$.");
                break;

            default:
                dialogue.Add("You need to check your physical condition with the fitness instructor first.");
                break;
        }
        gameManager.hasSpokenToNpc = false;
        dialogueText.text = dialogue[0];
        continueButton.SetActive(true);
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }
    public void AthleteHasInteractedWithNpc()
    {
        if (gameManager.hasSpokenToNpc == true)
        {
            getProgramButton.SetActive(true);
            continueButton.SetActive(false);
        }
    }
}
