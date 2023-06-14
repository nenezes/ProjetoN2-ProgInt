using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    
    public float speed;
    public float jumpForce;
    [SerializeField] private bool hasDoubleJump = false;
    public Rigidbody rig;
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool canDoubleJump = false;

    [SerializeField] private float completionRadius = 1.1f;
    [SerializeField] private LayerMask goalLayer, coinLayer;
    private float jumpBuffer;
    
    float direction;
    

    private void Awake() {
        if (Instance != null) {
            Destroy(Instance.gameObject);
            Instance = this;
        }

        Instance = this;
    }

    private void Start() {
        speed += GameManager.Instance.moveBonus;
        jumpForce += GameManager.Instance.jumpBonus;
        hasDoubleJump = GameManager.Instance.hasDoubleJump;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene("LevelSelection");
        
        if (jumpBuffer > 0) jumpBuffer -= Time.deltaTime;
        
        if (Physics.Raycast(transform.position, Vector3.down, 1.1f) && jumpBuffer <= 0) {
            isGrounded = true;
        }
        
        direction = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rig.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
            jumpBuffer = .2f;
            isGrounded = false;
            if (hasDoubleJump) canDoubleJump = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && canDoubleJump && jumpBuffer <= 0) {
            rig.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
            canDoubleJump = false;
        }


        TryCompletion();
        TryColect();
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
    
    private void TryColect() {
        Collider[] hitCol = Physics.OverlapSphere(transform.position, completionRadius, coinLayer);

        if (hitCol.Length > 0) {
            foreach (var coin in hitCol) {
                GameManager.Instance.currentCoins += (3 * GameManager.Instance.coinBonus);
                Destroy(coin.gameObject);
            }
        }
    }
}
