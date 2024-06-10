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

        if (AthleteCollider != null && BarCollider != null)
        {
            if (AthleteCollider.bounds.Intersects(BarCollider.bounds))
            {
                Debug.Log("Collision detected!");
            }
        }
    }

    void Start()
    {
        
    }


    void Update()
    {
        CheckCollision();
    }
}
