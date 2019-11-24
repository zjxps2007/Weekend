using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dm : MonoBehaviour
{
    [SerializeField] private int hp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int _dmg, Vector3 _targetPos)
    {
        hp -= _dmg;
        Debug.Log("체력 : "+hp);
        if(hp <= 0)
        {
            Debug.Log("체력 0이하");
            return;
        }
    }
}
