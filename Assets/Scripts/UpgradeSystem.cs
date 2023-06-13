using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private TextMeshProUGUI coinCount;

    private void Start() {
        Hide();
    }

    private void Update() {
        coinCount.text = $"{GameManager.Instance.currentCoins}";
        
        if (!Input.GetKeyDown(KeyCode.Tab)) return;
        
        if (canvasGroup.alpha == 0) Show();
        else Hide();
    }

    private void Hide() {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    private void Show() {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }
}
