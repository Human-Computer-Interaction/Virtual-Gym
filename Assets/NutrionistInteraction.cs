using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NutrionistInteraction : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public GameObject continueButton;
    public GameObject gameManagerComponent;
    private GameManager gameManager;
    private GameObject playerCameraRotation;
    private GameObject playerCamera;

    private List<string> dialogue;
    private int index;
    public float wordSpeed;
    public bool playerIsClose;
    private bool hasBought = false;

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

        if (gameManager.physicalCondition == "Unknown")
        {
            dialogue = new List<string>
            {
                "Welcome to PADA Gym!",
                "You should talk to the fitness instructor to check your physical condition.",
            };
        }
        else
        {
            dialogue = new List<string>
            {
                "Welcome to PADA Gym!",
                "You have already checked your physical condition."
            };
        }
    }

    // Update is called once per frame
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

        if (hasBought == false)
        {
            if (gameManager.productsBuy.ProteinBuy != -1 &&
                gameManager.productsBuy.CreatineBuy != -1 &&
                gameManager.productsBuy.EnergyDrinkBuy != -1 &&
                gameManager.productsBuy.ZoneBuy != -1 &&
                gameManager.productsBuy.GlovesBuy != -1)
            {
                if (gameManager.productBought(ref gameManager.productLimits.ProteinLimits, gameManager.productsBuy.ProteinBuy) &&
                    gameManager.productBought(ref gameManager.productLimits.CreatineLimits, gameManager.productsBuy.CreatineBuy) &&
                    gameManager.productBought(ref gameManager.productLimits.EnergyDrinkLimits, gameManager.productsBuy.EnergyDrinkBuy) &&
                    gameManager.productBought(ref gameManager.productLimits.ZoneLimits, gameManager.productsBuy.ZoneBuy) &&
                    gameManager.productBought(ref gameManager.productLimits.GlovesLimits, gameManager.productsBuy.GlovesBuy))
                {
                    dialogue = new List<string>
                    {
                        "You have bought your food program!",
                        "Now you are able to improve your physical condition.",
                        "Good luck!",
                    };
                    hasBought = true;

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
        }
    }

    public void FoodProgramBasedOnPhysicalCondition()
    {
        dialogue.Clear();
        print(gameManager.physicalCondition);
        switch(gameManager.physicalCondition)
        {
            case "Underweight":
            {
                dialogue.Add("You are 'Underweight' so I created a food program for you.");
                dialogue.Add("The fitness instructor gave you a program that will help you gain muscle, but you will have to eat more.");
                dialogue.Add("Let me show you what to buy from the vending machine.");
                dialogue.Add("Your food program is ready.");
                dialogue.Add("5 Protein, 5 Creatine, 4 Energy Drinks, 1 pair of Gloves, 1 Dipping Zone");
                dialogue.Add("Πάρε κανά κιλό ρε χτικιάρη!!");
                gameManager.productsBuy.ProteinBuy = 5;
                gameManager.productsBuy.CreatineBuy = 5;
                gameManager.productsBuy.EnergyDrinkBuy = 4;
                gameManager.productsBuy.ZoneBuy = 1;
                gameManager.productsBuy.GlovesBuy = 1;

                break;
            }
            case "Normal":
            {
                dialogue.Add("You are 'Normal' so I created a food program for you.");
                dialogue.Add("The fitness instructor gave you a program that will help you maintain your weight.");
                dialogue.Add("Let me show you what to buy from the vending machine.");
                dialogue.Add("Your food program is ready.");
                dialogue.Add("5 Protein, 1 Energy Drink, 1 Dipping Zone");
                dialogue.Add("Είσαι Αστέρι!!");
                gameManager.productsBuy.ProteinBuy = 5;
                gameManager.productsBuy.EnergyDrinkBuy = 1;
                gameManager.productsBuy.ZoneBuy = 1;

                break;
            }
            case "Overweight":
            {
                dialogue.Add("You are 'Overweight' so I created a food program for you.");
                dialogue.Add("The fitness instructor gave you a program that will help you to lose weight, but you will have to eat less.");
                dialogue.Add("Let me show you what to buy from the vending machine.");
                dialogue.Add("Your food program is ready.");
                dialogue.Add("1 Protein, 1 Creatine, 5 Energy Drink, 1 Gloves, 1 Dipping Zone");
                dialogue.Add("Χάσε κανά κιλό ρε χοντρέ!!");
                gameManager.productsBuy.ProteinBuy = 1;
                gameManager.productsBuy.CreatineBuy = 1;
                gameManager.productsBuy.EnergyDrinkBuy = 5;
                gameManager.productsBuy.ZoneBuy = 1;
                gameManager.productsBuy.GlovesBuy = 1;

                break;
            }
            case "Obese":
            {
                dialogue.Add("You are 'Obese' so I created a food program for you.");
                dialogue.Add("The fitness instructor gave you a program that will help you to lose weight, but you will have to eat less.");
                dialogue.Add("Let me show you what to buy from the vending machine.");
                dialogue.Add("Your food program is ready.");
                dialogue.Add("10 Energy Drink, 1 Gloves, 1 Dipping Zone");
                dialogue.Add("Ε ρε τι κάνουν τα McDonalds!!");
                gameManager.productsBuy.EnergyDrinkBuy = 10;
                gameManager.productsBuy.ZoneBuy = 1;
                gameManager.productsBuy.GlovesBuy = 1;

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
