using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    
    public float speed;
    public float jumpForce;
    public Rigidbody rig;

    float direction;

    private void Awake() {
        if (Instance != null) {
            Destroy(Instance.gameObject);
            Instance = this;
        }

        Instance = this;
    }

    void Start()
    {
        
    }
    void Update()
    {
        direction = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rig.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
        }

    }

    void FixedUpdate()
    {
        rig.velocity = new Vector2(direction * speed, rig.velocity.y);
    }
}
