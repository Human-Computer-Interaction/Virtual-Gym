using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationInGym : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(transform.up, 10f * Time.deltaTime, Space.World);
    }
}
