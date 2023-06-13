using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleporterLevel : MonoBehaviour
{
    [SerializeField] private Material matLocked, matUnlocked, matClear;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private string myLevel;
    [SerializeField] private LevelState currentState = LevelState.Locked;
    [SerializeField] private List<TeleporterLevel> adjacentLevels = new List<TeleporterLevel>();

    private void Start() {
        SetLevelState(currentState);
        if (GameManager.Instance.clearLevels.Contains(myLevel)) SetLevelState(LevelState.Clear);
    }

    public void SetLevelState(LevelState state) {
        currentState = state;

        if (currentState == LevelState.Clear) {
            foreach (TeleporterLevel level in adjacentLevels) {
                if (level.currentState != LevelState.Locked) continue;

                level.SetLevelState(LevelState.Unlocked);
            }
        }

        switch (currentState) {
            case LevelState.Clear:
                GameManager.Instance.clearLevels = $"{GameManager.Instance.clearLevels}, {myLevel}";
                meshRenderer.material = matClear;
                break;
            case LevelState.Locked:
                meshRenderer.material = matLocked;
                break;
            case LevelState.Unlocked:
                meshRenderer.material = matUnlocked;
                break;
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.T)) SetLevelState(currentState);
    }

    public void Teleport() {
        SceneManager.LoadScene(myLevel);
    }
    
}

public enum LevelState
{
    Locked,
    Unlocked,
    Clear
}
