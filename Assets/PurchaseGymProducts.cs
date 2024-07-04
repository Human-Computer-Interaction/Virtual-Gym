using System.Collections;
using UnityEngine;

public class PurchaseGymProducts : MonoBehaviour
{
    [SerializeField]
    public GameObject gameManagerComponent;

    [SerializeField]
    public GameObject vendingMachinePanel;

    private bool playerIsClose;
    [SerializeField]
    public GameObject energyItemsPanel;
    [SerializeField]
    public GameObject fitnessItemsPanel;
    [SerializeField]
    public GameObject energyDrinksButton;
    [SerializeField]
    public GameObject fitnessProductButton;
    [SerializeField]
    public GameObject exitButton;
    [SerializeField]
    public GameObject moneyWarning;
    private GameManager gameManager;

    private GameObject player;
    void Start()
    {
        player = GameObject.Find("Athlete");
        gameManager = gameManagerComponent.GetComponent<GameManager>();
    }

    public void DisplayVendingMachinePanel()
    {
        vendingMachinePanel.SetActive(true);
        player.GetComponentInChildren<MouseLook>().enabled = false;
        Cursor.lockState = CursorLockMode.Confined;

    }

    public void DisplayEnergyItems()
    {
        energyDrinksButton.SetActive(false);
        fitnessProductButton.SetActive(false);
        exitButton.SetActive(false);
        energyItemsPanel.SetActive(true);
    }

    public void DisplayFitnessItems()
    {
        energyDrinksButton.SetActive(false);
        fitnessProductButton.SetActive(false);
        exitButton.SetActive(false);
        fitnessItemsPanel.SetActive(true);
    }

    public void ReturnToCaregorySelection()
    {
        energyItemsPanel.SetActive(false);
        fitnessItemsPanel.SetActive(false);
        energyDrinksButton.SetActive(true);
        fitnessProductButton.SetActive(true);
        exitButton.SetActive(true);
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
            vendingMachinePanel.SetActive(false);
            player.GetComponentInChildren<MouseLook>().enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void BuyEnergyDrink()
    {
        if (gameManager.playerStats.Money >= 5f)
        {
            gameManager.playerStats.Money -= 5f;
            gameManager.playerStats.Stamina += 0.1f;
            gameManager.InitStats();
        }
        else
        {
            StartCoroutine(DisplayMoneyWarning());
        }
    }

    public void BuyProtein()
    {
        if (gameManager.playerStats.Money >= 20f)
        {
            gameManager.playerStats.Money -= 20f;
            gameManager.playerStats.Weight += 0.1f;
            gameManager.playerStats.Stamina += 0.15f;
            gameManager.InitStats();
        }
        else
        {
            StartCoroutine(DisplayMoneyWarning());
        }
    }

    public void BuyCreatine()
    {
        if (gameManager.playerStats.Money >= 30f)
        {
            gameManager.playerStats.Money -= 30f;
            gameManager.playerStats.Weight += 0.1f;
            gameManager.playerStats.Stamina += 0.2f;
            gameManager.InitStats();
        }
        else
        {
            StartCoroutine(DisplayMoneyWarning());
        }
    }
    public void BuyGloves()
    {
        if (gameManager.playerStats.Money >= 10f)
        {
            gameManager.playerStats.Money -= 10f;
            gameManager.playerStats.Stamina += 0.1f;
            gameManager.InitStats();
        }
        else
        {
            StartCoroutine(DisplayMoneyWarning());
        }
    }
    public void BuyDippingBelt()
    {
        if (gameManager.playerStats.Money >= 25f)
        {
            gameManager.playerStats.Money -= 25f;
            gameManager.playerStats.Stamina += 0.25f;
            gameManager.InitStats();
        }
        else
        {
            StartCoroutine(DisplayMoneyWarning());
        }

    }
    public void ExitSnackMachine()
    {
        vendingMachinePanel.SetActive(false);
        player.GetComponentInChildren<MouseLook>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private IEnumerator DisplayMoneyWarning()
    {

        moneyWarning.SetActive(true);
        yield return new WaitForSeconds(2f);
        moneyWarning.SetActive(false);

    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            DisplayVendingMachinePanel();
        }
    }




}
