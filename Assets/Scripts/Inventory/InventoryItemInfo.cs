using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryItemInfo : MonoBehaviour
{
    [SerializeField] private TMP_Text messageText;

    private void OnEnable()
    {
        GameEvents.OnShowItemInfo += UpdateMessage;
    }

    private void OnDisable()
    {
        GameEvents.OnShowItemInfo -= UpdateMessage;
    }

    private void UpdateMessage(string message)
    {
        messageText.text = message;
    }
}
