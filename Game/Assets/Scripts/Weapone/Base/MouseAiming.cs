using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAiming : MonoBehaviour
{
    //public float offset;

    
    private Camera cam;
    private void Start()
    {
        cam = Camera.main;
    }
    private void Update()
    {
       
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);
    }
}
