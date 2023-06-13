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

    [SerializeField] private float completionRadius = 2.5f;
    [SerializeField] private LayerMask goalLayer;
    
    float direction;

    private void Awake() {
        if (Instance != null) {
            Destroy(Instance.gameObject);
            Instance = this;
        }

        Instance = this;
        /*
        if (GameManager.Instance.nextSpawnPos == Vector3.zero) return;

        this.transform.position = GameManager.Instance.nextSpawnPos;*/
    }
    
    void Update()
    {
        direction = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rig.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
        }


        TryCompletion();
    }

    void FixedUpdate()
    {
        rig.velocity = new Vector2(direction * speed, rig.velocity.y);
    }

    private void TryCompletion() {
        Collider[] hitCol = Physics.OverlapSphere(transform.position, completionRadius, goalLayer);

        if (hitCol.Length > 0) {
            hitCol[0].GetComponent<LevelGoal>().CompleteLevel();
        }
    }
}
