using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;


    [SerializeField] GameObject Athlete;
    [SerializeField] GameObject Bar;
    [SerializeField] GameObject LegExtension;
    [SerializeField] GameObject Bike;
    [SerializeField] GameObject Bike1;
    [SerializeField] GameObject Treadmill1;
    [SerializeField] GameObject Treadmill2;
    [SerializeField] GameObject Mat;
    [SerializeField] GameObject Mat3;
    [SerializeField] GameObject Mat4;
    [SerializeField] GameObject Mat5;
    [SerializeField] GameObject WeightScale;
    [SerializeField] GameObject WeightTrack;
    [SerializeField] GameObject Ball12;

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
        Collider Bike1Collider = Bike1.GetComponent<Collider>();
        Collider Treadmill1Collider = Treadmill1.GetComponent<Collider>();
        Collider Treadmill2Collider = Treadmill2.GetComponent<Collider>();
        Collider WeightScaleCollider = WeightScale.GetComponent<Collider>();
        Collider MatCollider = Mat.GetComponent<Collider>();
        Collider Mat3Collider = Mat3.GetComponent<Collider>();
        Collider Mat4Collider = Mat4.GetComponent<Collider>();
        Collider Mat5Collider = Mat5.GetComponent<Collider>();
        Collider WeightTrackCollider = WeightTrack.GetComponent<Collider>();
        Collider Ball12Collider = Ball12.GetComponent<Collider>();

        if (AthleteCollider != null && BarCollider != null)
            if (AthleteCollider.bounds.Intersects(BarCollider.bounds))
                Debug.Log("Collision detected in Bar!!");
        if (AthleteCollider != null && LegCollider != null)
            if (AthleteCollider.bounds.Intersects(LegCollider.bounds))
                Debug.Log("Collision detected in Leg Extension!!");
        if (AthleteCollider != null && BikeCollider != null)
            if (AthleteCollider.bounds.Intersects(BikeCollider.bounds))
                Debug.Log("Collision detected in Bike!!");
        if (AthleteCollider != null && Bike1Collider != null)
            if (AthleteCollider.bounds.Intersects(Bike1Collider.bounds))
                Debug.Log("Collision detected in Bike1!!");
        if (AthleteCollider != null && Treadmill1Collider != null)
            if (AthleteCollider.bounds.Intersects(Treadmill1Collider.bounds))
                Debug.Log("Collision detected in Treadmill1!!");
        if (AthleteCollider != null && Treadmill2Collider != null)
            if (AthleteCollider.bounds.Intersects(Treadmill2Collider.bounds))
                Debug.Log("Collision detected in Treadmill2!!");
        if (AthleteCollider != null && WeightScaleCollider != null)
            if (AthleteCollider.bounds.Intersects(WeightScaleCollider.bounds))
                Debug.Log("Collision detected in WeightScale!!");
        if (AthleteCollider != null && MatCollider != null)
            if (AthleteCollider.bounds.Intersects(MatCollider.bounds))
                Debug.Log("Collision detected in Mat!!");
        if (AthleteCollider != null && Mat3Collider != null)
            if (AthleteCollider.bounds.Intersects(Mat3Collider.bounds))
                Debug.Log("Collision detected in Mat3!!");
        if (AthleteCollider != null && Mat4Collider != null)
            if (AthleteCollider.bounds.Intersects(Mat4Collider.bounds))
                Debug.Log("Collision detected in Mat4!!");
        if (AthleteCollider != null && Mat5Collider != null)
            if (AthleteCollider.bounds.Intersects(Mat5Collider.bounds))
                Debug.Log("Collision detected in Mat5!!");
        if (AthleteCollider != null && WeightTrackCollider != null)
            if (AthleteCollider.bounds.Intersects(WeightTrackCollider.bounds))
                Debug.Log("Collision detected in WeightTrack!!");
        if (AthleteCollider != null && Ball12Collider != null)
            if (AthleteCollider.bounds.Intersects(Ball12Collider.bounds))
                Debug.Log("Collision detected in Ball12!!");
    }

    void Start()
    {
    }


    void Update()
    {
        CheckCollision();
    }
}
