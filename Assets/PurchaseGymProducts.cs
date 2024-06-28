using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseGymProducts : MonoBehaviour
{
    public List<GymProduct> gymProducts;

    [SerializeField]
    public GameObject productsPanel;

    private float totalPrice = 0f;
    private GymProduct selectedProduct;

    public struct GymProduct
    {
        public string productName;
        public float price;
        public float buff;
    }
    private GameObject playerCameraRotation;
    void Start()
    {
        playerCameraRotation = GameObject.Find("Athlete");
        gymProducts = new List<GymProduct>();
        // ���������� ������������� ���������
        gymProducts.Add(new GymProduct { productName = "Energy Drink", price = 5f, buff = 10 });
        gymProducts.Add(new GymProduct { productName = "Protein", price = 20f, buff = 15 });
        gymProducts.Add(new GymProduct { productName = "Creatinine", price = 30f, buff = 10 });
        gymProducts.Add(new GymProduct { productName = "Gym Gloves", price = 10f, buff = 5 });
        gymProducts.Add(new GymProduct { productName = "Dipping Belt", price = 25f, buff = 20 });

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

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            DisplayProducts();
        }
    }
}
