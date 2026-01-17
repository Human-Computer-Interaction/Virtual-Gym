using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField]
    public Button buyEnergyDrinkButton;
    [SerializeField]
    public Button buyProteinButton;
    [SerializeField]
    public Button buyCreatineButton;
    [SerializeField]
    public Button buyGlovesButton;
    [SerializeField]
    public Button buyDippingBeltButton;
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
            gameManager.playerStats.Weight += 0.2f;
            gameManager.playerStats.Stamina += 1.5f;
            gameManager.InitStats();
            gameManager.playerStats.Invetory["EnergyDrink"] += 1;
            gameManager.itemsToBuyFromVendingMachine["EnergyDrink"] -= 1;
            gameManager.athleteBoughtAllItems = BoughtAllItems();
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
            gameManager.playerStats.Weight += 0.5f;
            gameManager.playerStats.Stamina += 1f;
            gameManager.InitStats();
            gameManager.playerStats.Invetory["Protein"] += 1;
            gameManager.itemsToBuyFromVendingMachine["Protein"] -= 1;
            gameManager.athleteBoughtAllItems = BoughtAllItems();
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
            gameManager.playerStats.Weight += 1f;
            gameManager.playerStats.Stamina += 0.5f;
            gameManager.InitStats();
            gameManager.playerStats.Invetory["Creatine"] += 1;
            gameManager.itemsToBuyFromVendingMachine["Creatine"] -= 1;
            gameManager.athleteBoughtAllItems = BoughtAllItems();

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
            gameManager.playerStats.Weight += 0.3f;
            gameManager.InitStats();
            gameManager.playerStats.Invetory["Gloves"] += 1;
            gameManager.itemsToBuyFromVendingMachine["Gloves"] -= 1;
            gameManager.athleteBoughtAllItems = BoughtAllItems();
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
            gameManager.playerStats.Weight += 0.75f;
            gameManager.InitStats();
            gameManager.playerStats.Invetory["Belt"] += 1;
            gameManager.itemsToBuyFromVendingMachine["DippingBelt"] -= 1;
            gameManager.athleteBoughtAllItems = BoughtAllItems();

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
        CanBuyEnergyDrink();
        CanBuyProtein();
        CanBuyCreatine();
        CanBuyGloves();
        CanBuyDippingBelt();

    }
    public void CanBuyEnergyDrink()
    {
        gameManager.itemsToBuyFromVendingMachine.TryGetValue("EnergyDrink", out int energyDrinksToBuy);
        if (energyDrinksToBuy == 0)
        {
            buyEnergyDrinkButton.interactable = false;
        }
        else buyEnergyDrinkButton.interactable = true;
    }
    public void CanBuyProtein()
    {
        gameManager.itemsToBuyFromVendingMachine.TryGetValue("Protein", out int proteinToBuy);
        if (proteinToBuy == 0)
        {
            buyProteinButton.interactable = false;
        }
        else buyProteinButton.interactable = true;
    }
    public void CanBuyCreatine()
    {
        gameManager.itemsToBuyFromVendingMachine.TryGetValue("Creatine", out int creatineToBuy);
        if (creatineToBuy == 0)
        {
            buyCreatineButton.interactable = false;
        }
        else buyCreatineButton.interactable = true;
    }
    public void CanBuyGloves()
    {
        gameManager.itemsToBuyFromVendingMachine.TryGetValue("Gloves", out int glovesToBuy);
        if (glovesToBuy == 0)
        {
            buyGlovesButton.interactable = false;
        }
        else buyGlovesButton.interactable = true;
    }
    public void CanBuyDippingBelt()
    {
        gameManager.itemsToBuyFromVendingMachine.TryGetValue("DippingBelt", out int beltToBuy);
        if (beltToBuy == 0)
        {
            buyDippingBeltButton.interactable = false;
        }
        else buyDippingBeltButton.interactable = true;
    }
    public bool BoughtAllItems()
    {
        return gameManager.itemsToBuyFromVendingMachine.All(item => item.Value == 0);
    }


}
