using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGoal : MonoBehaviour
{
    [SerializeField] private string myLevel;
    //[SerializeField] private float checkRadius = 5f;
    
    /*private void Update() {
        Collider[] hitCol = Physics.OverlapSphere(transform.position, checkRadius);

        Debug.Log(hitCol);
        
        if (hitCol.Length < 1) return;
        
        foreach (var col in hitCol) {
            if (TryGetComponent<Player>(out Player player)) {
                CompleteLevel();
            }
        }
    }*/

    public void CompleteLevel() {
        GameManager.Instance.clearLevels = $"{GameManager.Instance.clearLevels}, {myLevel}";
        SceneManager.LoadScene("LevelSelection");
    }
}
