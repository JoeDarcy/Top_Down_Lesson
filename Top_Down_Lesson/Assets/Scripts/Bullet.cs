using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject hitEffect;

    private GameObject hitEffectInstance;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hitEffectInstance = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(hitEffectInstance, 2.0f);
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
