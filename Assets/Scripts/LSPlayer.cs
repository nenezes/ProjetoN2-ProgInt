using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSPlayer : MonoBehaviour
{
    [SerializeField] private LayerMask teleportLayer;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float interactionRadius = 2f;
    
    private void Update() {
        HandleMovement();
        
        if (Input.GetKeyDown(KeyCode.E)) TryInteraction();

        if (Input.GetKeyDown(KeyCode.Space)) GameManager.Instance.currentCoins += 100;
    }

    private void HandleMovement() {
        Vector2 inputVector = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W)) inputVector.y = +1;

        if (Input.GetKey(KeyCode.S)) inputVector.y = -1;

        if (Input.GetKey(KeyCode.A)) inputVector.x = -1;

        if (Input.GetKey(KeyCode.D)) inputVector.x = +1;

        inputVector = inputVector.normalized;

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDir * (moveSpeed * Time.deltaTime);
    }

    private void TryInteraction() {
        Collider[] hitCol = Physics.OverlapSphere(transform.position, interactionRadius, teleportLayer);

        if (hitCol.Length > 0) {
            TeleporterLevel teleport = hitCol[0].transform.GetComponent<TeleporterLevel>();
            if (teleport.IsUnlocked()) teleport.Teleport();
        }
        /*
        if (Physics.SphereCast(transform.position, interactionRadius, transform.position, out RaycastHit hitInfo, 3f, teleportLayer)) {
            TeleporterLevel teleport = hitInfo.transform.GetComponent<TeleporterLevel>();
            Debug.Log(teleport);
            if (teleport.IsUnlocked()) teleport.Teleport();
        }*/
    }
}
