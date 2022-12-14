using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private LayerMask Target;
    [SerializeField] private float Damage;
    
    public float life = 3;

    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject, life);
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out TargetScript TargetHit))
        {
            TargetHit.SubtractHealth(Damage);
            Debug.Log(TargetHit.Health);
            Destroy(gameObject);
        }
    }
}
