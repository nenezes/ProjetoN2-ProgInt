using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleporterLevel : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField] private Material matLocked, matUnlocked, matClear;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private string myLevel;
    [SerializeField] private LevelState currentState = LevelState.Locked;
    [SerializeField] private List<TeleporterLevel> adjacentLevels = new List<TeleporterLevel>();

    private void Awake() {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Start() {
        SetLevelState(currentState);
        Debug.Log(GameManager.Instance.clearLevels);
        if (GameManager.Instance.clearLevels.Contains(myLevel)) SetLevelState(LevelState.Clear);
        
        //draw lines
        lineRenderer.positionCount = 0;
        
        foreach (var level in adjacentLevels) {
            lineRenderer.positionCount += 2;
        }

        int iterationCount = 0;
        
        for (int i = 0; i < adjacentLevels.Count; i++) {
            lineRenderer.SetPosition(iterationCount, this.transform.position);
            iterationCount++;
            lineRenderer.SetPosition(iterationCount, adjacentLevels[i].transform.position);
            iterationCount++;
        }
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

    public bool IsUnlocked() => currentState is LevelState.Unlocked or LevelState.Clear;
}

public enum LevelState
{
    Locked,
    Unlocked,
    Clear
}
