using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

#if UNITY_ANDROID
using Unity.Notifications.Android;
using UnityEngine.Android;
#endif

public class NotificationSimple : MonoBehaviour
{
    private const string idCanal = "canalNotificacion";
    private NotificationSO NotificationSO;

    private void Start()
    {
#if UNITY_ANDROID
        RequestAuhtorization();
        RegisterNotificationChannel();
#endif
    }

#if UNITY_ANDROID
    //Request authorization to send notifications
    public void RequestAuhtorization()
    {
        if(!Permission.HasUserAuthorizedPermission("android.permission.POST_NOTIFICATIONS"))
        {
            Permission.RequestUserPermission("android.permission.POST_NOTIFICATIONS");
        }
    }

    //Register a Notification Channel
    public void RegisterNotificationChannel()
    {
        AndroidNotificationChannel channel = new AndroidNotificationChannel
        {
            Id = "default_channel",
            Name = "Default",
            Importance = Importance.Default,
            Description = "Notifications"
        };

        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }

    //Set Up Notification Template
    public static void SendNotification(NotificationSO so)
    {
        AndroidNotification notification = new AndroidNotification();
        notification.Title = so.title;
        notification.Text = so.text;
        notification.FireTime = DateTime.Now;
        notification.SmallIcon = so.idSmallIcon;
        notification.LargeIcon = so.idLargeIcon;

        AndroidNotificationCenter.SendNotification(notification, "default_channel");
    }

    /*public void ButtonFunction()
    {
        SendNotification(NotificationSO);
    }*/
#endif
}
