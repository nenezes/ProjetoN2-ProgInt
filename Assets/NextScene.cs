using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    private void Update() {
        if (GameManager.Instance != null) {
            SceneManager.LoadScene("LevelSelection");
        }
    }
}
