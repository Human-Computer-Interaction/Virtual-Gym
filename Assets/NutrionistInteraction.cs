using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NutrionistInteraction : MonoBehaviour
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

        if (gameManager.physicalCondition == "")
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

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }
}
