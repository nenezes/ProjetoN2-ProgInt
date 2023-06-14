using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public string clearLevels = "";
    public string boughtUpgrades = "";
    
    public int currentCoins;
    public bool hasDoubleJump = false;
    public int jumpBonus = 0;
    public int moveBonus = 0;
    public int coinBonus = 1;
    
    
    public Vector3 nextSpawnPos = Vector3.zero;

    private void Awake() {
        if (Instance == null) {
            Debug.Log("Creating GameManager.");
            Instance = this;
        }
        else {
            Destroy(gameObject.transform);
        }
    }
    
    

    public void GoToLevel(string level) {
        //player.instance.nextspawnpos = level.getspawnposition
        SceneManager.LoadScene("Game");
    }
}
