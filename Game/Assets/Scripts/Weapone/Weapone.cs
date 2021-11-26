using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapone : MonoBehaviour
{
    [SerializeField] Transform bulletPoint;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform mainBody;
    [SerializeField] float speedBullet;
    Rigidbody2D bulletRB;
    

    void Update()
    {
        Shoot();
    }
    void Shoot()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            GameObject gameObject= Instantiate(bullet, bulletPoint.position, transform.rotation);
            bulletRB = gameObject.GetComponent<Rigidbody2D>();
            bulletRB.velocity = Vector2.right * speedBullet * mainBody.localScale.x;
        }
    }
}
