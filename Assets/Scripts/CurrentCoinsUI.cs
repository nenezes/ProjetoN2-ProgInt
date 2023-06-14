using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentCoinsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI count;

    private void Update() {
        count.text = $"{GameManager.Instance.currentCoins}";
    }
}
