using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveToplayer : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 offset;
    private void Start()
    {
        
    }
    private void LateUpdate()
    {
        transform.position = player.position + offset;
    }
}
