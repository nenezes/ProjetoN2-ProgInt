using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfRotateY : MonoBehaviour
{
    private Vector3 rotation = new Vector3(0, -1, 0);
    [SerializeField] private float rotateSpeed = 1f;
    
    private void Update() {
        transform.Rotate(rotation * (rotateSpeed * Time.deltaTime));
    }
}
