using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private Camera cam;

    void Start()
    {
        cam = transform.GetChild(0).GetComponent<Camera>();
    }

    void Update()
    {
        
    }
}
