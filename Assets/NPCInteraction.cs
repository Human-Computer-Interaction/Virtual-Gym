using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public GameObject continueButton;
    public GameObject characteristicsInputPanel;
    public GameObject gameManagerComponent;
    private GameManager gameManager;
    private GameObject playerCameraRotation;
    private GameObject playerCamera;

    private List<string> dialogue;
    private int index;
    public float wordSpeed;
    public bool playerIsClose;
    private bool hasCharacteristics = false;
    private bool hasCompleted = false;
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

        dialogue = new List<string>
        {
            "Welcome to PADA Gym!",
            "Next, you're going to sign up your characteristics form.",
        };
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
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
        if (dialogueText.text == dialogue[index])
        {
            continueButton.SetActive(true);
        }

        if (hasCompleted == false)
        {
            if (gameManager.equipmentUse.MatUse != -1 &&
                gameManager.equipmentUse.DumbellsUse != -1 &&
                gameManager.equipmentUse.BarUse != -1 &&

                gameManager.equipmentUse.LegExtensionUse != -1 &&
                gameManager.equipmentUse.TreadmillUse != -1 &&
                gameManager.equipmentUse.BikeUse != -1)
            {
                if (gameManager.exerciseComplited(ref gameManager.equipmentTimers.MatTimer, gameManager.equipmentUse.MatUse) &&
                    gameManager.exerciseComplited(ref gameManager.equipmentTimers.DumbellsTimer, gameManager.equipmentUse.DumbellsUse) &&
                    gameManager.exerciseComplited(ref gameManager.equipmentTimers.BarTimer, gameManager.equipmentUse.BarUse) &&

                    gameManager.exerciseComplited(ref gameManager.equipmentTimers.LegExtensionTimer, gameManager.equipmentUse.LegExtensionUse) &&
                    gameManager.exerciseComplited(ref gameManager.equipmentTimers.TreadmillTimer, gameManager.equipmentUse.TreadmillUse) &&
                    gameManager.exerciseComplited(ref gameManager.equipmentTimers.BikeTimer, gameManager.equipmentUse.BikeUse))
                {
                    dialogue = new List<string>
                {
                    "You have finished your exercise. Good Job!",
                    "Now you have to eat some food. Ask the nutritionist for more info about the food.",
                    "Good luck!",
                };
                    hasCompleted = true;

                }
            }
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
        if (index < dialogue.Count - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else if (index == dialogue.Count - 1)
        {
            dialoguePanel.SetActive(false);
            if (!hasCharacteristics)
                characteristicsInputPanel.SetActive(true);
            playerIsClose = false;
        }
    }
    public void PassInputsToGameManager()
    {
        var inputsFields = characteristicsInputPanel.GetComponentsInChildren<TMP_InputField>();
        gameManager.playerStats.Weight = Math.Abs(float.Parse(inputsFields[0].text));
        gameManager.playerStats.Age = Math.Abs(int.Parse(inputsFields[1].text));
        gameManager.playerStats.Height = Math.Abs(float.Parse(inputsFields[2].text)) / 100f;
        gameManager.InitStats();
        gameManager.ActivatePanel();
        characteristicsInputPanel.SetActive(false);
        inputsFields[0].text = "";
        inputsFields[1].text = "";
        inputsFields[2].text = "";
        hasCharacteristics = true;
        GymPlanBasedOnBMI();
        gameManager.hasSpokenToNpc = true;
    }

    public void GymPlanBasedOnBMI()
    {
        dialogue.Clear();
        gameManager.CalculateBMI(gameManager.playerStats);
        string BodyType = gameManager.BodyTypeBasedOnBmi();
        print(BodyType);
        switch (BodyType)
        {
            case "Underweight":
                {
                    gameManager.physicalCondition = "Underweight";
                    dialogue.Add("You are 'Underweight' so I created a gym program for you.");
                    dialogue.Add("This program will help you gain muscle, but you will have to eat more.");
                    dialogue.Add("Ask the nutritionist for more information about your food program.");
                    dialogue.Add("Your personalized plan is ready.");
                    dialogue.Add("10' of Treadmill, 20' Bar, 10' of Squats, 10' of Leg Extensions, 10' of Dumbells.");
                    dialogue.Add("Good luck!");
                    gameManager.equipmentUse.TreadmillUse = 10f;
                    gameManager.equipmentUse.BarUse = 20f;

                    gameManager.equipmentUse.LegExtensionUse = 10f;
                    gameManager.equipmentUse.DumbellsUse = 10f;
                    gameManager.equipmentUse.BikeUse = 0f;
                    gameManager.equipmentUse.MatUse = 0f;
                    break;
                }
            case "Normal":
                {
                    gameManager.physicalCondition = "Normal";
                    dialogue.Add("Your physical characteristics are 'Normal'.");
                    dialogue.Add("This program will help you maintain your weight.");
                    dialogue.Add("Ask the nutritionist for more information about your food program.");
                    dialogue.Add("Your personalized plan is ready.");
                    dialogue.Add("10' of Treadmill, 10' Bicycle, 20' Bar, 10' of Squats, 10' of Leg Extensions.");
                    dialogue.Add("Good luck!");
                    gameManager.equipmentUse.TreadmillUse = 10f;
                    gameManager.equipmentUse.BikeUse = 10f;
                    gameManager.equipmentUse.BarUse = 20f;

                    gameManager.equipmentUse.LegExtensionUse = 10f;
                    gameManager.equipmentUse.DumbellsUse = 0f;
                    gameManager.equipmentUse.MatUse = 0f;
                    break;
                }
            case "Overweight":
                {
                    gameManager.physicalCondition = "Overweight";
                    dialogue.Add("You are 'Overweight' so I created a gym program for you.");
                    dialogue.Add("This program will help you to lose weight, but you will have to eat less.");
                    dialogue.Add("Ask the nutritionist for more information about your food program.");
                    dialogue.Add("Your personalized plan is ready.");
                    dialogue.Add("20' of Treadmill, 20' Bycicle, 20' Bar, 10' of Squats, 10' of Leg Extensions.");
                    dialogue.Add("Good luck!");
                    gameManager.equipmentUse.TreadmillUse = 20f;
                    gameManager.equipmentUse.BikeUse = 20f;
                    gameManager.equipmentUse.BarUse = 20f;

                    gameManager.equipmentUse.LegExtensionUse = 10f;
                    gameManager.equipmentUse.DumbellsUse = 0f;
                    gameManager.equipmentUse.MatUse = 0f;
                    break;
                }
            case "Obese":
                {
                    gameManager.physicalCondition = "Obese";
                    dialogue.Add("You are 'Obese' so I created a gym program for you.");
                    dialogue.Add("This program will help you lose weight, but you will have to eat less.");
                    dialogue.Add("Ask the nutritionist for more information about your food program.");
                    dialogue.Add("Your personalized plan is ready.");
                    dialogue.Add("20' of Treadmill, 20' Bycicle, 20' Bar, 10' of Squats, 10' of Leg Extensions, 10 Dumbells.");
                    dialogue.Add("Good luck");
                    gameManager.equipmentUse.TreadmillUse = 20f;
                    gameManager.equipmentUse.BikeUse = 20f;
                    gameManager.equipmentUse.BarUse = 20f;

                    gameManager.equipmentUse.LegExtensionUse = 10f;
                    gameManager.equipmentUse.DumbellsUse = 10f;
                    gameManager.equipmentUse.MatUse = 10f;

                    break;
                }


        }
        dialogueText.text = dialogue[0];
        dialoguePanel.SetActive(true);
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
