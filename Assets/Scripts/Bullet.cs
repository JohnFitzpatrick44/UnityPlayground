using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        var effect = Instantiate(hitEffect, transform.position, Quaternion.Euler(0, 0, Random.Range(0f, 360f)));
        Destroy(effect, 2f);
        Destroy(gameObject);
    }
}
