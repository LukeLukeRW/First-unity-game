using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Projectile")
        {
            collision.GetComponent < Bullet >().Ded();
            GameObject.Destroy(gameObject);
        }
    }

    void Update()
    {
        
    }
}
