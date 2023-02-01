using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject muzzleFlashPrefab;
    [SerializeField] private float bulletForce = 20.0f;
    [SerializeField] private Color bulletColour_1;
    [SerializeField] private Color bulletColour_2;
    [SerializeField] private Color bulletColour_3;
    [SerializeField] private Color bulletColour_4;
    [SerializeField] private Color bulletColour_5;

    private Color bulletColour;
    private SpriteRenderer bulletSpriteRenderer;
    private int colourSelect;
    private Transform rightFirePoint;
    private Transform leftFirePoint;
    private GameObject bulletInstanceRight;
    private GameObject bulletInstanceLeft;
    private GameObject muzzleFlashInstanceRight;
    private GameObject muzzleFlashInstanceLeft;
    private Rigidbody2D bulletRb;

    // Start is called before the first frame update
    void Start()
    {
        // Get reference to right and left fire points
        rightFirePoint = GameObject.FindGameObjectWithTag("Right_Fire_Point").transform;
        leftFirePoint = GameObject.FindGameObjectWithTag("Left_Fire_Point").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
	        Shoot();
        }
    }


    private Color ChooseBulletColour()
    {
        colourSelect = Random.Range(1, 6);

        switch (colourSelect)
        {
            case 1:
                bulletColour = bulletColour_1;
                break;
            case 2:
                bulletColour = bulletColour_2;
                break;
            case 3:
                bulletColour = bulletColour_3;
                break;
            case 4:
                bulletColour = bulletColour_4;
                break;
            case 5:
                bulletColour = bulletColour_5;
                break;
            default:
                bulletColour = bulletColour_1;
                break;
        }

        return bulletColour;
    }

    private void Shoot()
    {
	    // Fire right bullet
        muzzleFlashInstanceRight = Instantiate(muzzleFlashPrefab, rightFirePoint.position, rightFirePoint.rotation);
        Destroy(muzzleFlashInstanceRight, 0.02f);
        bulletInstanceRight = Instantiate(bulletPrefab, rightFirePoint.position, rightFirePoint.rotation);
        bulletSpriteRenderer = bulletInstanceRight.GetComponent<SpriteRenderer>();
        bulletSpriteRenderer.color = ChooseBulletColour();
        bulletRb = bulletInstanceRight.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(rightFirePoint.up * bulletForce, ForceMode2D.Impulse);

        // Fire left bullet
        muzzleFlashInstanceLeft = Instantiate(muzzleFlashPrefab, leftFirePoint.position, leftFirePoint.rotation);
        Destroy(muzzleFlashInstanceLeft, 0.02f);
        bulletInstanceLeft = Instantiate(bulletPrefab, leftFirePoint.position, rightFirePoint.rotation);
        bulletSpriteRenderer = bulletInstanceLeft.GetComponent<SpriteRenderer>();
        bulletSpriteRenderer.color = ChooseBulletColour();
        bulletRb = bulletInstanceLeft.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(leftFirePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
