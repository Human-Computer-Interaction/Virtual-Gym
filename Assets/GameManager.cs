using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public struct PlayerStats
{

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

    }
    public override string ToString()
    {
        return $"Weight: {Weight}, Stamina: {Stamina}, Money: {Money}, Height: {Height}, Age: {Age}";
    }

}
public struct EquipmentUse
{
    public float TreadmillUse;
    public float BarUse;
    public float LegExtensionUse;
    public float BikeUse;
    public float DumbellsUse;

    public float SquatUse;
}
public struct EquipmentTimers
{
    public float TreadmillTimer;
    public float BarTimer;
    public float LegExtensionTimer;
    public float BikeTimer;
    public float dumbellsTimer;

    public float SquatTimer;


}
public class GameManager : MonoBehaviour
{
    public static GameManager manager;


    [SerializeField] GameObject Athlete;
    [SerializeField] GameObject Bar;
    [SerializeField] GameObject LegExtension;
    [SerializeField] GameObject Bike;
    //[SerializeField] GameObject Bike1;
    [SerializeField] GameObject Treadmill1;
    [SerializeField] GameObject Treadmill2;
    [SerializeField] GameObject Mat;

    [SerializeField] GameObject WeightScale;
    [SerializeField] GameObject WeightTrack;
    [SerializeField] GameObject Ball12;
    [SerializeField] GameObject Panel;
    [SerializeField] Text ScreenTimer;


    private Collider BarCollider;
    private Collider AthleteCollider;
    private TextMesh textMesh;
    public PlayerStats playerStats;


    //public float Timer = 0f;

    public TextMeshProUGUI[] stats;

    public float BMI;

    public EquipmentUse equipmentUse;

    public EquipmentTimers equipmentTimers;


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
        AthleteCollider = Athlete.GetComponent<Collider>();
        BarCollider = Bar.GetComponent<Collider>();
        Collider LegCollider = LegExtension.GetComponent<Collider>();
        Collider BikeCollider = Bike.GetComponent<Collider>();
        //Collider Bike1Collider = Bike1.GetComponent<Collider>();
        Collider Treadmill1Collider = Treadmill1.GetComponent<Collider>();
        Collider Treadmill2Collider = Treadmill2.GetComponent<Collider>();
        Collider WeightScaleCollider = WeightScale.GetComponent<Collider>();
        Collider MatCollider = Mat.GetComponent<Collider>();
        Collider WeightTrackCollider = WeightTrack.GetComponent<Collider>();
        Collider Ball12Collider = Ball12.GetComponent<Collider>();

        if (AthleteCollider != null && BarCollider != null)

            if (AthleteCollider.bounds.Intersects(BarCollider.bounds))
            {

                // Timer += Time.deltaTime;
                // print("Timer: " + Timer);
                checkExerciseComplition(ref equipmentTimers.BarTimer, equipmentUse.BarUse);
                TimeSpan timeSpan = TimeSpan.FromSeconds(equipmentTimers.BarTimer);
                ScreenTimer.text = string.Format("{0:ss\\:ff}", timeSpan); // show seconds and ms
                //print("Timer: " + equipmentTimers.BarTimer);
            }


        if (AthleteCollider != null && LegCollider != null)
            if (AthleteCollider.bounds.Intersects(LegCollider.bounds))
            {
                checkExerciseComplition(ref equipmentTimers.LegExtensionTimer, equipmentUse.LegExtensionUse);
                //print("Timer: " + equipmentTimers.LegExtensionTimer%.2f);
                TimeSpan timeSpan = TimeSpan.FromSeconds(equipmentTimers.LegExtensionTimer);
                ScreenTimer.text = string.Format("{0:ss\\:ff}", timeSpan); // show seconds and ms
                //print("Timer: " + equipmentTimers.LegExtensionTimer);
                // Timer += Time.deltaTime;
                // print("Timer: " + Timer);
            }
        if (AthleteCollider != null && BikeCollider != null)
            if (AthleteCollider.bounds.Intersects(BikeCollider.bounds))
            {
                Debug.Log("Collision detected in Bike!!");
                checkExerciseComplition(ref equipmentTimers.BikeTimer, equipmentUse.BikeUse);
                //print("Timer: " + equipmentTimers.BikeTimer);
                TimeSpan timeSpan = TimeSpan.FromSeconds(equipmentTimers.BikeTimer);
                ScreenTimer.text = string.Format("{0:ss\\:ff}", timeSpan); // show seconds and ms


            }

        if (AthleteCollider != null && Treadmill1Collider != null)
            if (AthleteCollider.bounds.Intersects(Treadmill1Collider.bounds))
            {
                Debug.Log("Collision detected in Treadmill1!!");
                checkExerciseComplition(ref equipmentTimers.TreadmillTimer, equipmentUse.TreadmillUse);
                //print("Timer: " + equipmentTimers.TreadmillTimer);
                TimeSpan timeSpan = TimeSpan.FromSeconds(equipmentTimers.TreadmillTimer);
                ScreenTimer.text = string.Format("{0:ss\\:ff}", timeSpan); // show seconds and ms
            }
        if (AthleteCollider != null && Treadmill2Collider != null)
            if (AthleteCollider.bounds.Intersects(Treadmill2Collider.bounds))
            {
                Debug.Log("Collision detected in Treadmill2!!");
                checkExerciseComplition(ref equipmentTimers.TreadmillTimer, equipmentUse.TreadmillUse);
                //print("Timer: " + equipmentTimers.TreadmillTimer);
                TimeSpan timeSpan = TimeSpan.FromSeconds(equipmentTimers.TreadmillTimer);
                ScreenTimer.text = string.Format("{0:ss\\:ff}", timeSpan); // show seconds and ms
            }
        if (AthleteCollider != null && WeightScaleCollider != null)
            if (AthleteCollider.bounds.Intersects(WeightScaleCollider.bounds))
            {
                Debug.Log("Collision detected in WeightScale!!");
                checkExerciseComplition(ref equipmentTimers.dumbellsTimer, equipmentUse.DumbellsUse);
                //print("Timer: " + equipmentTimers.dumbellsTimer);
                TimeSpan timeSpan = TimeSpan.FromSeconds(equipmentTimers.dumbellsTimer);
                ScreenTimer.text = string.Format("{0:ss\\:ff}", timeSpan); // show seconds and ms
            }
        if (AthleteCollider != null && MatCollider != null)
        {
            if (AthleteCollider.bounds.Intersects(MatCollider.bounds))
            {
                print("Collision detected in Mat!!");
            }

        }




    }

    // BMI Needs Fixing!
    public float CalculateBMI(PlayerStats playerStats)
    {
        BMI = playerStats.Weight / (playerStats.Height * playerStats.Height);
        return BMI;
    }

    public String BodyTypeBasedOnBmi()
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
        // var textMeshComponents = Panel.GetComponentsInChildren<TextMeshProUGUI>();


        // textMeshComponents[0].text = "Weight: " + playerStats.Weight;
        // textMeshComponents[1].text = "Age: " + playerStats.Age;
        // textMeshComponents[2].text = "Height: " + playerStats.Height;
        // textMeshComponents[3].text = "Money: " + playerStats.Money;
        // textMeshComponents[4].text = "Stamina: " + playerStats.Stamina;

        // stats = textMeshComponents;

        var textMeshComponents = Panel.GetComponentsInChildren<TextMeshProUGUI>();
        textMeshComponents = textMeshComponents.Where(x => x.tag == "StatsValues").ToArray();
        print(textMeshComponents.Length);
        textMeshComponents[0].text = playerStats.Weight.ToString();
        textMeshComponents[1].text = playerStats.Age.ToString();
        textMeshComponents[2].text = playerStats.Height.ToString();
        textMeshComponents[3].text = playerStats.Money.ToString();
        textMeshComponents[4].text = playerStats.Stamina.ToString();

        //stats = textMeshComponents;

    }

    public void ActivatePanel()
    {
        Panel.SetActive(true);
    }

    public void checkExerciseComplition(ref float Timer, float maxTime)
    {
        if (Timer < maxTime)
        {
            Timer += Time.deltaTime;
        }


    }

    void Start()
    {
        playerStats = new PlayerStats();
        // Money and Stamina should be RNG
        playerStats.Money = 100f;
        playerStats.Stamina = 100f;
        BMI = CalculateBMI(playerStats);
        print("BMI " + BMI);
        String bodyType = BodyTypeBasedOnBmi();
        print("BodyType: " + bodyType);
        var textMeshComponents = Panel.GetComponentsInChildren<TextMeshProUGUI>();
        print(textMeshComponents.Length);
        InitStats();


        // CalculateBMI();
    }


    void Update()
    {


        CheckCollision();
        //CheckTrigger();

        //print("Timer: " + Timer);
    }

    // private void CheckTrigger()
    // {


    //     if (AthleteCollider.bounds.Intersects(BarCollider.bounds))
    //     {
    //         Timer += Time.deltaTime;
    //     }
    // }
}
