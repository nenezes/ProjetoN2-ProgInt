using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public Transform chController;
    bool inside = false;
    public float speedUpDown = 3.2f;
    public Player FPSInput;
    [SerializeField] private Rigidbody chRb;

    void Start()
    {
        FPSInput = GetComponent<Player>();
        inside = false;
        chRb = GetComponent<Rigidbody>();
        speedUpDown = Player.Instance.speed;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Ladder") {
            chRb.velocity = Vector3.zero;
            FPSInput.canMove = false;
            chRb.useGravity = false;
            inside = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Ladder")
        {
            FPSInput.canMove = true;
            chRb.useGravity = true;
            inside = false;
        }
    }

    void Update()
    {
        if (inside) {
            if (Input.GetKey(KeyCode.W)) {
                chController.transform.position += (Vector3.up * (speedUpDown * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.S)) {
                chController.transform.position += (Vector3.down * (speedUpDown * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.A)) {
                chController.transform.position += (Vector3.left * (speedUpDown * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.D)) {
                chController.transform.position += (Vector3.right * (speedUpDown * Time.deltaTime));
            }
        }
    }
}
