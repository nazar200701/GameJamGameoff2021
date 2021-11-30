using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapone1 : MonoBehaviour
{
    [SerializeField] Transform bulletPoint;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform mainBody;
    [SerializeField] float speedBullet;
    float currentAngle;
    int directionOfView;
    Rigidbody2D bulletRB;

    void Update()
    {
        Angle();
        Shoot();
    }
    void Angle()
    {
        currentAngle = transform.rotation.z;
        if ((currentAngle > 90 && currentAngle < 180) || (currentAngle < -90 && currentAngle > -180))
        {
            directionOfView = -1;
        }
        else
        {
            directionOfView = 1;
        }
    }
    void Shoot()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            GameObject gameObject= Instantiate(bullet, bulletPoint.position, transform.rotation);
            bulletRB = gameObject.GetComponent<Rigidbody2D>();
            bulletRB.velocity = Vector2.right * speedBullet * directionOfView;
        }
    }
}
