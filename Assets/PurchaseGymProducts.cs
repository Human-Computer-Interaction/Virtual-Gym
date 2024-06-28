using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseGymProducts : MonoBehaviour
{
    [System.Serializable]
    public class GymProduct
    {
        public string productName;
        public float price;
        public string buff;
    }

    public List<GymProduct> gymProducts = new List<GymProduct>();
    public GameObject productButtonPrefab;

    [SerializeField]
    public GameObject productsPanel;
    public Text selectedProductText;
    public Text totalPriceText;

    private float totalPrice = 0f;
    private GymProduct selectedProduct;

    void Start()
    {
        // ���������� ������������� ���������
        gymProducts.Add(new GymProduct { productName = "Energy Drink", price = 5f, buff = "+10% Energy" });
        gymProducts.Add(new GymProduct { productName = "Protein", price = 20f, buff = "+15% Strength" });
        gymProducts.Add(new GymProduct { productName = "Creatinine", price = 30f, buff = "+10% Stamina" });
        gymProducts.Add(new GymProduct { productName = "Gym Gloves", price = 10f, buff = "+5% Grip" });
        gymProducts.Add(new GymProduct { productName = "Dipping Belt", price = 25f, buff = "+20% Stability" });

        // �������� ��� ���������
        //DisplayProducts();
    }

    public void DisplayProducts()
    {
        productsPanel.SetActive(true);
        // foreach (GymProduct product in gymProducts)
        // {
        //     GameObject button = Instantiate(productButtonPrefab, productsPanel);
        //     button.GetComponentInChildren<Text>().text = $"{product.productName} - ${product.price} ({product.buff})";
        //     button.GetComponent<Button>().onClick.AddListener(() => SelectProduct(product));
        // }
    }

    void SelectProduct(GymProduct product)
    {
        selectedProduct = product;
        selectedProductText.text = $"Selected: {product.productName} - ${product.price} ({product.buff})";
    }

    public void PurchaseProduct()
    {
        if (selectedProduct != null)
        {
            totalPrice += selectedProduct.price;
            totalPriceText.text = $"Total: ${totalPrice}";
            selectedProductText.text = "Selected: None";
            selectedProduct = null;
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            DisplayProducts();
        }
    }
}
