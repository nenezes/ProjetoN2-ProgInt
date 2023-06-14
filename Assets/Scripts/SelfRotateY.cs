using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SelfRotateY : MonoBehaviour
{
    private Vector3 rotation = new Vector3(0, -1, 0);
    [SerializeField] private float rotateSpeed = 1f;
    [SerializeField] private GameObject blingFx;
    
    private void Update() {
        transform.Rotate(rotation * (rotateSpeed * Time.deltaTime));
    }

    private void OnDestroy() {
        Instantiate(blingFx, transform.position, quaternion.identity);
    }
}
