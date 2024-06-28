using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseGymProducts : MonoBehaviour
{
    [SerializeField]
    public GameObject gameManagerComponent;

    [SerializeField]
    public GameObject productsPanel;

    private float totalPrice = 0f;


    public bool playerIsClose;

    private GameManager gameManager;

    private GameObject playerCameraRotation;
    void Start()
    {
        playerCameraRotation = GameObject.Find("Athlete");
        gameManager = gameManagerComponent.GetComponent<GameManager>();
        // ���������� ������������� ���������
        // gymProducts.Add(new GymProduct { productName = "Energy Drink", price = 5f, buff = 10 });
        // gymProducts.Add(new GymProduct { productName = "Protein", price = 20f, buff = 15 });
        // gymProducts.Add(new GymProduct { productName = "Creatinine", price = 30f, buff = 10 });
        // gymProducts.Add(new GymProduct { productName = "Gym Gloves", price = 10f, buff = 5 });
        // gymProducts.Add(new GymProduct { productName = "Dipping Belt", price = 25f, buff = 20 });

        // �������� ��� ���������
        //DisplayProducts();
    }

    public void DisplayProducts()
    {
        productsPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        playerCameraRotation.GetComponentInChildren<MouseLook>().enabled = false;
        // foreach (var button in productsPanelSelectionButtons)
        // {
        //     button.gameObject.SetActive(true);
        // }
        // productsPanel.SetActive(true);
        // foreach (GymProduct product in gymProducts)
        // {
        //     GameObject button = Instantiate(productButtonPrefab, productsPanel);
        //     button.GetComponentInChildren<Text>().text = $"{product.productName} - ${product.price} ({product.buff})";
        //     button.GetComponent<Button>().onClick.AddListener(() => SelectProduct(product));
        // }
    }

    // void SelectProduct(GymProduct product)
    // {
    //     selectedProduct = product;
    //     selectedProductText.text = $"Selected: {product.productName} - ${product.price} ({product.buff})";
    // }

    public void PurchaseProduct()
    {
        // if (selectedProduct != null)
        // {
        //     totalPrice += selectedProduct.price;
        //     totalPriceText.text = $"Total: ${totalPrice}";
        //     selectedProductText.text = "Selected: None";
        //     selectedProduct = null;
        // }
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
            //print("VLAKAS");
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
