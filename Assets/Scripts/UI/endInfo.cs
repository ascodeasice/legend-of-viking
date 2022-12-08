using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class endInfo : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI earnedCoinText;
    void Start()
    {
        earnedCoinText.text = $"You've earned {collectItem.coinCount} coins";
    }
}
