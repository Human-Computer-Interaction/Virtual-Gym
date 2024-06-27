using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseProducts : MonoBehaviour
{
    public bool playerIsClose;
    public GameObject gameManagerComponent;
    public GameObject purchasePanel;
    public GameObject addProductButton;
    public GameObject removeProductButton;
    public GameObject purchaseButton;
    public GameObject nameProductsText;
    public GameObject priceProductsText;
    public GameObject numberProductsText;

    private string eshopText;
    private GameManager gameManager;
    private GameObject playerCameraRotation;
    private GameObject playerCamera;

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
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerCameraRotation = GameObject.Find("Athlete");
        playerCamera = GameObject.Find("Camera");
        gameManager = gameManagerComponent.GetComponent<GameManager>();

        eshopText = "Uniwa Fitness E-shop";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            playerCameraRotation.GetComponentInChildren<MouseLook>().enabled = false;
            Cursor.lockState = CursorLockMode.Confined;
            // 88f is the y rotation of the camera, not 0 because we're rotating the camera when the game starts.
            playerCamera.transform.rotation = Quaternion.Euler(new Vector3(12f, 88f, 0f));
            if (purchasePanel.activeInHierarchy)
            {
                purchasePanel.SetActive(false);
                playerCameraRotation.GetComponentInChildren<MouseLook>().enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                purchasePanel.SetActive(true);
                nameProductsText.GetComponent<Text>().text = eshopText;
                priceProductsText.GetComponent<Text>().text = "Price: 1000";
                numberProductsText.GetComponent<Text>().text = "Number: 0";
            }
        }
    }
}
