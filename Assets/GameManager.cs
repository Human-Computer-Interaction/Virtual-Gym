using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerStats
{

    public Dictionary<string, int> Invetory;
    public float Weight;
    public float Stamina;
    public float Money;
    public float Height;
    public int Age;

    public float CaloriesBurned()
    {
        return 0.0f;
    }
    public PlayerStats(float weight, float stamina, float money, float height, int age)
    {
        this.Weight = weight;
        this.Stamina = stamina;
        this.Money = money;
        this.Height = height;
        this.Age = age;
        Invetory = new Dictionary<string, int>();
    }
    public PlayerStats()
    {
        Invetory = new Dictionary<string, int>();
    }
    public PlayerStats(int money, int stamina)
    {
        this.Money = money;
        this.Stamina = stamina;
        Invetory = new Dictionary<string, int>();
    }
    public override string ToString()
    {
        return $"Weight: {Weight}, Stamina: {Stamina}, Money: {Money}, Height: {Height}, Age: {Age}";
    }

}
public class EquipmentUse
{
    public float TreadmillUse;
    public float BarUse;
    public float LegExtensionUse;
    public float BikeUse;
    public float DumbellsUse;

    public float MatUse;

    public EquipmentUse()
    {
        this.TreadmillUse = -1;
        this.BarUse = -1;
        this.LegExtensionUse = -1;
        this.BikeUse = -1;
        this.DumbellsUse = -1;
        this.MatUse = -1;
    }
}
public struct EquipmentTimers
{
    public float TreadmillTimer;
    public float BarTimer;
    public float LegExtensionTimer;
    public float BikeTimer;
    public float DumbellsTimer;

    public float MatTimer;
}
public class GameManager : MonoBehaviour
{
    public static GameManager manager;

    [SerializeField] GameObject Athlete;
    [SerializeField] GameObject Bar;
    [SerializeField] GameObject LegExtension;
    [SerializeField] GameObject Bike;
    [SerializeField] GameObject Treadmill1;
    [SerializeField] GameObject Treadmill2;
    [SerializeField] GameObject Mat;
    [SerializeField] GameObject Dumbells;
    [SerializeField] GameObject PlayerStatsPanel;
    [SerializeField] Text ScreenTimer;
    [SerializeField] GameObject VendingMachine;

    public PlayerStats playerStats;

    public float BMI;

    public EquipmentUse equipmentUse;
    public EquipmentTimers equipmentTimers;

    public float GeneralTimer;

    [SerializeField] GameObject helpPanel;
    [SerializeField] GameObject inventoryPanel;
    [SerializeField] TMP_Text energyDrinksValue;
    [SerializeField] TMP_Text proteinsValue;
    [SerializeField] TMP_Text creatininesValue;
    [SerializeField] TMP_Text glovesValue;
    [SerializeField] TMP_Text beltsValue;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject treadmillFinished;
    [SerializeField] GameObject barFinished;
    [SerializeField] GameObject legExtensionFinished;
    [SerializeField] GameObject dumbellFinished;
    [SerializeField] GameObject bikeFinished;
    [SerializeField] GameObject matFinished;

    private bool isTreadmillFinished = false;
    private bool isBarFinished = false;
    private bool isLegExtensionFinished = false;
    private bool isDumbellFinished = false;
    private bool isBikeFinished = false;
    private bool isMatFinished = false;

    public void Awake()
    {
        if (manager == null)
        {
            manager = this;
            DontDestroyOnLoad(this);

        }
        else if (manager != this && manager != null)
        {
            Destroy(this);
        }
    }
    private void CheckCollision()
    {
        Collider AthleteCollider = Athlete.GetComponent<Collider>();
        Collider BarCollider = Bar.GetComponent<Collider>();
        Collider LegCollider = LegExtension.GetComponent<Collider>();
        Collider BikeCollider = Bike.GetComponent<Collider>();
        Collider Treadmill1Collider = Treadmill1.GetComponent<Collider>();
        Collider Treadmill2Collider = Treadmill2.GetComponent<Collider>();
        Collider MatCollider = Mat.GetComponent<Collider>();
        Collider DumbellsCollider = Dumbells.GetComponent<Collider>();

        if (AthleteCollider != null && BarCollider != null)
            if (AthleteCollider.bounds.Intersects(BarCollider.bounds))
            {
                updateGeneralTimer(ref GeneralTimer);
                checkExerciseComplition(ref equipmentTimers.BarTimer, equipmentUse.BarUse, out isBarFinished);
                TimeSpan timeSpan = TimeSpan.FromSeconds(equipmentTimers.BarTimer);
                ScreenTimer.text = string.Format("{0:ss\\:ff}", timeSpan); // show seconds and ms
                if (isBarFinished)
                {
                    barFinished.SetActive(true);
                }
            }
            else barFinished.SetActive(false);
        if (AthleteCollider != null && LegCollider != null)
            if (AthleteCollider.bounds.Intersects(LegCollider.bounds))
            {
                updateGeneralTimer(ref GeneralTimer);
                checkExerciseComplition(ref equipmentTimers.LegExtensionTimer, equipmentUse.LegExtensionUse, out isLegExtensionFinished);
                TimeSpan timeSpan = TimeSpan.FromSeconds(equipmentTimers.LegExtensionTimer);
                ScreenTimer.text = string.Format("{0:ss\\:ff}", timeSpan); // show seconds and ms
                if (isLegExtensionFinished)
                {
                    legExtensionFinished.SetActive(true);
                }
            }
            else legExtensionFinished.SetActive(false);
        if (AthleteCollider != null && BikeCollider != null)
            if (AthleteCollider.bounds.Intersects(BikeCollider.bounds))
            {
                updateGeneralTimer(ref GeneralTimer);
                checkExerciseComplition(ref equipmentTimers.BikeTimer, equipmentUse.BikeUse, out isBikeFinished);
                TimeSpan timeSpan = TimeSpan.FromSeconds(equipmentTimers.BikeTimer);
                ScreenTimer.text = string.Format("{0:ss\\:ff}", timeSpan); // show seconds and ms
                if (isBikeFinished)
                {
                    bikeFinished.SetActive(true);
                }
            }
            else bikeFinished.SetActive(false);
        if (AthleteCollider != null && Treadmill1Collider != null)
            if (AthleteCollider.bounds.Intersects(Treadmill1Collider.bounds))
            {
                updateGeneralTimer(ref GeneralTimer);
                checkExerciseComplition(ref equipmentTimers.TreadmillTimer, equipmentUse.TreadmillUse, out isTreadmillFinished);
                TimeSpan timeSpan = TimeSpan.FromSeconds(equipmentTimers.TreadmillTimer);
                ScreenTimer.text = string.Format("{0:ss\\:ff}", timeSpan); // show seconds and ms
                if (isTreadmillFinished)
                {
                    treadmillFinished.SetActive(true);
                }
            }
            else treadmillFinished.SetActive(false);
        // This code is duplicate of the above code

        if (AthleteCollider != null && Treadmill2Collider != null)
            if (AthleteCollider.bounds.Intersects(Treadmill2Collider.bounds))
            {
                updateGeneralTimer(ref GeneralTimer);
                checkExerciseComplition(ref equipmentTimers.TreadmillTimer, equipmentUse.TreadmillUse, out isTreadmillFinished);
                TimeSpan timeSpan = TimeSpan.FromSeconds(equipmentTimers.TreadmillTimer);
                ScreenTimer.text = string.Format("{0:ss\\:ff}", timeSpan); // show seconds and ms
                if (isTreadmillFinished)
                {
                    treadmillFinished.SetActive(true);
                }
            }
            else treadmillFinished.SetActive(false);
        if (AthleteCollider != null && MatCollider != null)
        {
            if (AthleteCollider.bounds.Intersects(MatCollider.bounds))
            {
                updateGeneralTimer(ref GeneralTimer);
                checkExerciseComplition(ref equipmentTimers.MatTimer, equipmentUse.MatUse, out isMatFinished);
                TimeSpan timeSpan = TimeSpan.FromSeconds(equipmentTimers.MatTimer);
                ScreenTimer.text = string.Format("{0:ss\\:ff}", timeSpan); // show seconds and ms
                if (isMatFinished)
                {
                    matFinished.SetActive(true);
                }
            }
            else matFinished.SetActive(false);
        }
        if (AthleteCollider != null && DumbellsCollider != null)
            if (AthleteCollider.bounds.Intersects(DumbellsCollider.bounds))
            {
                updateGeneralTimer(ref GeneralTimer);
                checkExerciseComplition(ref equipmentTimers.DumbellsTimer, equipmentUse.DumbellsUse, out isDumbellFinished);
                TimeSpan timeSpan = TimeSpan.FromSeconds(equipmentTimers.DumbellsTimer);
                ScreenTimer.text = string.Format("{0:ss\\:ff}", timeSpan); // show seconds and ms
                if (isDumbellFinished)
                {
                    dumbellFinished.SetActive(true);
                }
            }
            else dumbellFinished.SetActive(false);
    }
    public float CalculateBMI(PlayerStats playerStats)
    {
        BMI = playerStats.Weight / (playerStats.Height * playerStats.Height);
        return BMI;
    }

    public string BodyTypeBasedOnBmi()
    {
        if (BMI < 18.5f)
        {
            return "Underweight";
        }
        else if (BMI >= 18.5f && BMI <= 24.9f)
        {
            return "Normal";
        }
        else if (BMI >= 25f && BMI <= 29.9f)
        {
            return "Overweight";
        }
        else if (BMI >= 30f)
        {
            return "Obese";
        }

        return "";
    }
    public void InitStats()
    {
        var textMeshComponents = PlayerStatsPanel.GetComponentsInChildren<TextMeshProUGUI>();
        textMeshComponents = textMeshComponents.Where(x => x.tag == "StatsValues").ToArray();
        textMeshComponents[0].text = playerStats.Weight.ToString();
        textMeshComponents[1].text = playerStats.Age.ToString();
        textMeshComponents[2].text = playerStats.Height.ToString();
        textMeshComponents[3].text = playerStats.Money.ToString();
        textMeshComponents[4].text = playerStats.Stamina.ToString();
    }
    public void ActivatePanel()
    {
        PlayerStatsPanel.SetActive(true);
    }
    public void checkExerciseComplition(ref float Timer, float maxTime, out bool isFinished)
    {
        if (maxTime == -1 || maxTime == 0)
        {
            isFinished = false;
            return;
        }
        if (Timer < maxTime)
        {
            Timer += Time.deltaTime;
            isFinished = false;
        }
        else isFinished = true;
    }
    public void updateGeneralTimer(ref float Timer)
    {
        Timer += Time.deltaTime;
        int generalTimerToInt = (int)Timer;
        if (generalTimerToInt / 10 > 0)
        {
            playerStats.Money += 1;
            InitStats();
            Timer = 0;
        }
    }

    public bool exerciseComplited(ref float Timer, float maxTime)
    {
        if (Timer >= maxTime)
        {
            return true;
        }
        return false;
    }


    void Start()
    {
        var rand = new System.Random();
        playerStats = new PlayerStats
        {
            Money = rand.Next(1, 20),
            Stamina = rand.Next(30, 70)
        };
        playerStats.Invetory.Add("EnergyDrink", 0);
        playerStats.Invetory.Add("Protein", 0);
        playerStats.Invetory.Add("Creatinine", 0);
        playerStats.Invetory.Add("Gloves", 0);
        playerStats.Invetory.Add("Belt", 0);
        GeneralTimer = 0;
        BMI = CalculateBMI(playerStats);
        print("BMI " + BMI);
        string bodyType = BodyTypeBasedOnBmi();
        print("BodyType: " + bodyType);
        InitStats();
        equipmentUse = new EquipmentUse();
    }

    public void HelpPanelActivate()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            helpPanel.SetActive(!helpPanel.activeSelf);
        }
    }
    public void InventoryPanelActivate()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            UpdateInventoryValues();
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        }
    }
    public void UpdateInventoryValues()
    {
        energyDrinksValue.text = playerStats.Invetory["EnergyDrink"].ToString();
        proteinsValue.text = playerStats.Invetory["Protein"].ToString();
        creatininesValue.text = playerStats.Invetory["Creatinine"].ToString();
        glovesValue.text = playerStats.Invetory["Gloves"].ToString();
        beltsValue.text = playerStats.Invetory["Belt"].ToString();
    }
    public void PausePanelActivate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
            pausePanel.SetActive(true);
        }
    }
    public void ResumeGameButton()
    {
        pausePanel.SetActive(false);
        UnpauseGame();
    }
    public void ExitGameButton()
    {
        SceneManager.LoadSceneAsync("Menu");
        Destroy(GameManager.manager);
    }
    void Update()
    {
        CheckCollision();
        HelpPanelActivate();
        InventoryPanelActivate();
        PausePanelActivate();
    }
    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0;
    }
    public void UnpauseGame()
    {

        Time.timeScale = 1;
        pausePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
