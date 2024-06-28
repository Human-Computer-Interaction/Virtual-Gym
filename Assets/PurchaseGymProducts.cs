using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseGymProducts : MonoBehaviour
{
    [SerializeField]
    public GameObject gameManagerComponent;

    [SerializeField]
    public GameObject productsPanel;

    public bool playerIsClose;

    private GameManager gameManager;

    private GameObject playerCameraRotation;
    void Start()
    {
        playerCameraRotation = GameObject.Find("Athlete");
        gameManager = gameManagerComponent.GetComponent<GameManager>();
    }

    public void DisplayProducts()
    {
        productsPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        playerCameraRotation.GetComponentInChildren<MouseLook>().enabled = false;
    }
    public void PurchaseProduct()
    {
        // To do
    }



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
            productsPanel.SetActive(false);
            playerCameraRotation.GetComponentInChildren<MouseLook>().enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void BuyEnergyDrink()
    {
        if (gameManager.playerStats.Money >= 5f)
        {
            gameManager.playerStats.Money -= 5f;
            gameManager.playerStats.Stamina += 10f;
            gameManager.InitStats();
        }
    }

    public void BuyEnergyProtein()
    {
        if (gameManager.playerStats.Money >= 20f)
        {
            gameManager.playerStats.Money -= 20f;
            gameManager.playerStats.Weight += 0.1f;
            gameManager.playerStats.Stamina += 15f;
            gameManager.InitStats();
        }
    }

    public void BuyCreatine()
    {
        if (gameManager.playerStats.Money >= 30f)
        {
            gameManager.playerStats.Money -= 30f;
            gameManager.playerStats.Weight += 0.1f;
            gameManager.playerStats.Stamina += 10f;
            gameManager.InitStats();
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            DisplayProducts();
        }
    }




}
