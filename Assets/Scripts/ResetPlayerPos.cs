using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerPos : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;


    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent<Player>(out Player player)) {
            player.transform.position = respawnPoint.position;
        }
    }
}
