using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmFin : MonoBehaviour
{

    private StatusController theStatusController;

    // Start is called before the first frame update
    void Start()
    {
        theStatusController = FindObjectOfType<StatusController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider Coll)
    {
        if(Coll.gameObject.tag == "Player")
        {
            Debug.Log("충돌확인");
            theStatusController.DecreaseHP(30);
        }
    }
}
