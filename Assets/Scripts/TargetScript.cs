using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public float Health = 10f;

    public void SubtractHealth(float Damage)
    {
        Health -= Damage;

        if(Health <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
