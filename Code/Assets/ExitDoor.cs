using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    private bool playerNearDoor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Athlete"))
        {
            playerNearDoor = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Athlete"))
        {
            playerNearDoor = false;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerNearDoor)
        {
            Cursor.lockState = CursorLockMode.Confined;
            SceneManager.LoadSceneAsync("Menu");
            Destroy(GameManager.manager);
        }
    }
}
