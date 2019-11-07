using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shoot : MonoBehaviour
{
    private Camera cam;
    private float damage = 10;
    private float range = 500;
    public GameObject bulletHole;


    void Start()
    {
        cam = transform.GetChild(0).GetComponent<Camera>();
    }

    void Update()
    {
        if((Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer) && Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    public void Shoot() {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Instantiate(bulletHole, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
            Debug.Log(hit.transform.name + ", Damage : " + damage);
        }
    }
}