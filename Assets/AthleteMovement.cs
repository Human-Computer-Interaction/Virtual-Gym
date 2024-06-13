using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class AthleteMovement : MonoBehaviour


{
    [SerializeField]
    private CharacterController controller;

    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float gravity = -9.81f;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private float groundDistance = 0.0f;
    private LayerMask groundMask;

    private Vector3 velocity;
    private bool isGrounded;

    // Get Animator component
    private Animator animator;

    private bool isOnTTreadmille = false;

    [SerializeField] Camera camera;
    // Update is called once per frame

    [SerializeField] GameObject Treadmill1;
    [SerializeField] GameObject Treadmill2;

    private GameObject playerCameraRotation;
    private GameObject playerCamera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Treadmills") | other.gameObject.CompareTag("Bike") | other.gameObject.CompareTag("Push-Ups")
            | other.gameObject.CompareTag("Bar") | other.gameObject.CompareTag("Weights") | other.gameObject.CompareTag("Leg Extension"))
        {
            Vector3 desiredPosition = new Vector3(camera.transform.position.x, camera.transform.position.y, camera.transform.position.z);
            playerCameraRotation.GetComponentInChildren<MouseLook>().enabled = false;
            camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y + 1f, camera.transform.position.z);
            Debug.Log("Initial Rotation: " + camera.transform.rotation.eulerAngles);
            camera.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
            Debug.Log("New Rotation: " + camera.transform.rotation.eulerAngles);

            if (other.gameObject.CompareTag("Treadmills"))
            {
                animator.SetBool("isRunning", true);

            }
            else if (other.gameObject.CompareTag("Bike"))
            {
                animator.SetBool("isRiding", true);
            }
            else if (other.gameObject.CompareTag("Push-Ups"))
            {
                print("mphka");
                animator.SetBool("isPushing", true);
                print(animator.GetBool("isPushing"));
            }
            else if (other.gameObject.CompareTag("Bar"))
            {
                animator.SetBool("isSquating", true);
            }
            else if (other.gameObject.CompareTag("Weights"))
            {
                animator.SetBool("isLifting", true);
            }
            else if (other.gameObject.CompareTag("Leg Extension"))
            {
                animator.SetBool("isLegging", true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Treadmills") | other.gameObject.CompareTag("Bike") | other.gameObject.CompareTag("Push-Ups")
        | other.gameObject.CompareTag("Bar") | other.gameObject.CompareTag("Weights") | other.gameObject.CompareTag("Leg Extension"))
        {
            playerCameraRotation.GetComponentInChildren<MouseLook>().enabled = true;
            camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y - 1f, camera.transform.position.z);
            camera.transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
            if (other.gameObject.CompareTag("Treadmills"))
            {
                animator.SetBool("isRunning", false);

            }
            else if (other.gameObject.CompareTag("Bike"))
            {
                animator.SetBool("isRiding", false);
            }
            else if (other.gameObject.CompareTag("Push-Ups"))
            {
                animator.SetBool("isPushing", false);
            }
            else if (other.gameObject.CompareTag("Bar"))
            {
                animator.SetBool("isSquating", false);
            }
            else if (other.gameObject.CompareTag("Weights"))
            {
                animator.SetBool("isLifting", false);
            }
            else if (other.gameObject.CompareTag("Leg Extension"))
            {
                animator.SetBool("isLegging", false);
            }
        }

    }

    void CheckCollision()
    {
        Collider Treadmill1Collider = Treadmill1.GetComponent<Collider>();
        Collider Treadmill2Collider = Treadmill2.GetComponent<Collider>();

        Collider AthleteCollider = GetComponent<Collider>();
        if (Treadmill1Collider != null && Treadmill2Collider != null)
        {
            if (AthleteCollider.bounds.Intersects(Treadmill2Collider.bounds) ||
             AthleteCollider.bounds.Intersects(Treadmill1Collider.bounds))
            {
                isOnTTreadmille = true;

            }
            else
            {
                isOnTTreadmille = false;
                // animator.SetBool("isRunning", false);
                // speed = 1f;

            }
        }
    }


    void Start()
    {

        // Get the Animator component
        animator = GetComponentInChildren<Animator>();
        groundCheck = GameObject.Find("Ground-Check").GetComponent<Transform>();
        controller = GetComponent<CharacterController>();
        playerCameraRotation = GameObject.Find("Athlete");
        playerCamera = GameObject.Find("Camera");


    }

    void Update()
    {
        CheckCollision();

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(x, 0, z);
        if (move == Vector3.zero)
        {
            animator.SetFloat("Speed", 0);
        }
        else
        {
            animator.SetFloat("Speed", 1f);
        }




        move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);



    }

}
