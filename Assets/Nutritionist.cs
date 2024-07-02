using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NutritionistInteraction : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public GameObject continueButton;
    public GameObject nutritionInputPanel;
    public GameObject gameManagerComponent;
    private GameManager gameManager;
    private GameObject playerCameraRotation;
    private GameObject playerCamera;

    private List<string> dialogue;
    private int index;
    public float wordSpeed;
    public bool playerIsClose;
    private bool hasNutritionPlan = false;
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
            "Καλώς ήρθατε στο τμήμα διατροφής!",
            "Θα πρέπει να συμπληρώσετε μερικές πληροφορίες για τη διατροφή σας."
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

        if (!hasNutritionPlan)
        {
            if (gameManager.HasCompletedExercise())
            {
                dialogue = new List<string>
                {
                    "Έχετε ολοκληρώσει την άσκησή σας. Καλή δουλειά!",
                    "Τώρα θα πρέπει να ασχοληθείτε με τη διατροφή σας.",
                    "Θα σας δώσω ένα εξατομικευμένο πρόγραμμα διατροφής.",
                    "Καλή επιτυχία!"
                };
                hasNutritionPlan = true;
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
            if (!hasNutritionPlan)
                nutritionInputPanel.SetActive(true);
        }
    }
    public void PassInputsToGameManager()
    {
        var inputFields = nutritionInputPanel.GetComponentsInChildren<TMP_InputField>();
        gameManager.playerStats.CaloricIntake = Math.Abs(float.Parse(inputFields[0].text));
        gameManager.playerStats.ProteinIntake = Math.Abs(float.Parse(inputFields[1].text));
        gameManager.playerStats.CarbsIntake = Math.Abs(float.Parse(inputFields[2].text));
        gameManager.playerStats.FatIntake = Math.Abs(float.Parse(inputFields[3].text));
        gameManager.InitStats();
        gameManager.ActivateNutritionPanel();
        nutritionInputPanel.SetActive(false);
        foreach (var field in inputFields)
        {
            field.text = "";
        }
        hasNutritionPlan = true;
        NutritionPlanBasedOnBMI();
    }

    public void NutritionPlanBasedOnBMI()
    {
        dialogue.Clear();
        gameManager.CalculateBMI(gameManager.playerStats);
        string bodyType = gameManager.BodyTypeBasedOnBmi();
        print(bodyType);
        switch (bodyType)
        {
            case "Underweight":
                {
                    dialogue.Add("Είστε ελλιποβαρής, οπότε δημιούργησα ένα πρόγραμμα διατροφής για εσάς.");
                    dialogue.Add("Θα πρέπει να τρώτε περισσότερο για να αυξήσετε το βάρος σας.");
                    dialogue.Add("Καλή επιτυχία!");
                    gameManager.playerStats.CaloricIntake += 500;
                    break;
                }
            case "Normal":
                {
                    dialogue.Add("Έχετε φυσιολογικό βάρος.");
                    dialogue.Add("Συνεχίστε με μια ισορροπημένη διατροφή για να διατηρήσετε το βάρος σας.");
                    dialogue.Add("Καλή επιτυχία!");
                    break;
                }
            case "Overweight":
                {
                    dialogue.Add("Είστε υπέρβαρος, οπότε δημιούργησα ένα πρόγραμμα διατροφής για εσάς.");
                    dialogue.Add("Θα πρέπει να τρώτε λιγότερο για να χάσετε βάρος.");
                    dialogue.Add("Καλή επιτυχία!");
                    gameManager.playerStats.CaloricIntake -= 500;
                    break;
                }
            case "Obese":
                {
                    dialogue.Add("Είστε παχύσαρκος, οπότε δημιούργησα ένα πρόγραμμα διατροφής για εσάς.");
                    dialogue.Add("Θα πρέπει να τρώτε λιγότερο για να χάσετε βάρος.");
                    dialogue.Add("Καλή επιτυχία!");
                    gameManager.playerStats.CaloricIntake -= 1000;
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
