using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    private bool energyShield;
    private float shieldCharge;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Health_Pickup"))
        {
            Destroy(collision.gameObject);

            if (PlayerHealth.playerHealth < 10)
            {
                PlayerHealth.playerHealth += 1;
            }
        }
    }
}
