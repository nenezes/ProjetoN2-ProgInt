using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public string clearLevels = "";
    
    public Vector3 nextSpawnPos = Vector3.zero;

    private void Awake() {
        if (Instance != null) {
            Destroy(Instance.gameObject);
            Instance = this;
        }

        Instance = this;
    }
    
    

    public void GoToLevel(string level) {
        //player.instance.nextspawnpos = level.getspawnposition
        SceneManager.LoadScene("Game");
    }
}
