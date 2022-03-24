using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Terrehbyte.GameEvents;

public class NotificationManager : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Text notificationLabel;
    
    [Header("Receiving Events")]
    [SerializeField]
    private GameEvent<string> onNotification;

    private void Start()
    {
        onNotification.AddListener(HandleNotification);
    }

    private void HandleNotification(string notification)
    {
        notificationLabel.text = notification;
    }
}
