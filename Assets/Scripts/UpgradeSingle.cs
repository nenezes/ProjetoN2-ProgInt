using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSingle : MonoBehaviour
{
    private Button myButton;

    [SerializeField] private string upgradeID;
    [SerializeField] private bool enabledOnStart;
    [SerializeField] private List<UpgradeSingle> imediateChilds;
    [SerializeField] private int upgradeCost;
    [SerializeField] private TextMeshProUGUI upgradeCostText;
    [SerializeField] private UpgradeModifier myModifier;
    
    private void Awake() {
        myButton = GetComponent<Button>();
        
        if (!enabledOnStart) {
            myButton.GetComponent<Image>().color = Color.grey;
            myButton.enabled = false;
        }
    }

    private void Start() {
        upgradeCostText.text = $"{upgradeCost}";

        myButton.onClick.AddListener(TryBuyUpgrade);

        IsBought();
    }

    private bool IsBought() {
        if (!GameManager.Instance.boughtUpgrades.Contains(upgradeID)) return false;

        myButton.enabled = false;
        myButton.GetComponent<Image>().color = Color.green;

        foreach (var child in imediateChilds) {
            child.myButton.enabled = true;
            child.myButton.GetComponent<Image>().color = Color.white;
            child.IsBought();
        }
        
        return true;
    }

    private void TryBuyUpgrade() {
        if (GameManager.Instance.currentCoins >= upgradeCost) {
            BuyUpgrade();
        }
        else Debug.Log("Not enough coins!");
    }

    private void BuyUpgrade() {
        GameManager.Instance.boughtUpgrades = $"{GameManager.Instance.boughtUpgrades}, {upgradeID}";
        GameManager.Instance.currentCoins -= upgradeCost;
        ApplyModifier();
        IsBought();
    }

    private void ApplyModifier() {
        switch (myModifier) {
            case UpgradeModifier.DoubleJump:
                GameManager.Instance.hasDoubleJump = true;
                break;
            case UpgradeModifier.Jump:
                GameManager.Instance.jumpBonus++;
                break;
            case UpgradeModifier.Coin:
                GameManager.Instance.coinBonus++;
                break;
            case UpgradeModifier.Move:
                GameManager.Instance.moveBonus++;
                break;
        }
    }
}

public enum UpgradeModifier
{
    Jump,
    Move,
    Coin,
    DoubleJump
}