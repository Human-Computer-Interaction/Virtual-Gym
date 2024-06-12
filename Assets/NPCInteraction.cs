using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    private List<string> dialogue;
    private int index;
    public float wordSpeed;
    public bool playerIsClose;
    private bool hasCharacteristics = false;
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
        dialogue = new List<string>
        {
            "Καλώς ήρθατε στο Γυμναστήριο!",
            "Στην συνέχεια θα πρέπει να συμπληρώσετε μια φόρμα με τα χαρατκηριστιακα σας."
        };
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
        if (index < dialogue.Count - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else if (index == dialogue.Count - 1)
        {
            dialoguePanel.SetActive(false);
            if(!hasCharacteristics)
                characteristicsInputPanel.SetActive(true);
            //PlayerStats playerStats = new PlayerStats(70f, 100f, 100f, 1.80f, 30);
        }
    }
    public void PassInputsToGameManager()
    {
        var inputsFields = characteristicsInputPanel.GetComponentsInChildren<TMP_InputField>();
        gameManager.playerStats.Weight = Math.Abs(float.Parse(inputsFields[0].text));
        gameManager.playerStats.Age = Math.Abs(int.Parse(inputsFields[1].text));
        gameManager.playerStats.Height = Math.Abs(float.Parse(inputsFields[2].text))/100f;
        gameManager.InitStats();
        gameManager.ActivatePanel();
        
        
        characteristicsInputPanel.SetActive(false);
        inputsFields[0].text = "";
        inputsFields[1].text = "";
        inputsFields[2].text = "";

        hasCharacteristics = true;
        // print(gameManager.playerStats);
        // print(gameManager.CalculateBMI(gameManager.playerStats));

        GymPlanBasedOnBMI();
    }

    public void GymPlanBasedOnBMI()
    {
        dialogue = new List<string>();
        print("size of dialogue = "+dialogue.Count());
        gameManager.CalculateBMI(gameManager.playerStats);
        String BodyType = gameManager.BodyTypeBasedOnBmi();
        print(BodyType);
        switch(BodyType)
        {
           
            case "Underweight":
                {
                    
                    dialogue.Add("You are Underweight so I created a gym program for you.");
                    dialogue.Add("This program will help you gain muscle , but you will have to eat More");
                    dialogue.Add("Ask The nutritionist for more info about the food");
                    dialogue.Add("Your personalized plan is ready");
                    dialogue.Add("10' of TreadMills , 20' Bar , 10' of Squats , 10' of Leg Press");
                    dialogue.Add("Good luck");
                    break;
                }
            case "Normal":
            {
                    
                    dialogue.Add("You have Normal weight.");
                    dialogue.Add("This program will help you gain muscle , but you will have to eat More");
                    dialogue.Add("Ask The nutritionist for more info about the food");
                    dialogue.Add("Your personalized plan is ready");
                    dialogue.Add("10' of TreadMills , 20' Bar , 10' of Squats , 10' of Leg Press");
                    dialogue.Add("Good luck");
                    break;
            }
            case "Overweight":
            {
                    
                    dialogue.Add("You are OverWeight so I created a gym program for you.");
                    dialogue.Add("This program will help you to lose weight , but you will have to eat Less");
                    dialogue.Add("Ask The nutritionist for more info about the food");
                    dialogue.Add("Your personalized plan is ready");
                    dialogue.Add("10' of TreadMills , 20' Bar , 10' of Squats , 10' of Leg Press");
                    dialogue.Add("Good luck");
                    break;
            }
            case "Obese":
            {
                    
                    dialogue.Add("You are Obese so I created a gym program for you.");
                    dialogue.Add("This program will help you lose weight , but you will have to eat less");
                    dialogue.Add("Ask The nutritionist for more info about the food");
                    dialogue.Add("Your personalized plan is ready");
                    dialogue.Add("10' of TreadMills , 20' Bar , 10' of Squats , 10' of Leg Press");
                    dialogue.Add("Good luck");
                    break;
            }
            

        }
        print(dialogue.Count());
        dialogueText.text = dialogue[0]; // εβαλα αυτό εδώ γιατι αλλιώς για κάποιο λόγο δείχει το δεύτερο μήνυμα. Βγάλε το για να καταλάβεις
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
