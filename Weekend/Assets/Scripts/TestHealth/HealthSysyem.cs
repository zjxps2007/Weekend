using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSysyem : MonoBehaviour
{
    private int hp = 100;

    public void Damage(int dmg, Vector3 targetPos)
    {

        hp -= dmg;
        Debug.Log("체력 : " + hp);
        if (hp <= 0)
        {
            Debug.Log("죽음");
            return;
        }
    }
}
