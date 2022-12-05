using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ConnectUsPage : MonoBehaviour
{
    public Button phoneButton;
    public Button websiteButton;
    public Button emailButton;

    public string phoneNum;
    public string emailAddress;
    public string websiteAddress;

    private void Start()
    {
        phoneButton.onClick.AddListener(() =>
        {
            string phoneNum = $"tel: +{this.phoneNum}";

            //For accessing static strings(ACTION_CALL) from android.content.Intent
            AndroidJavaClass intentStaticClass = new AndroidJavaClass("android.content.Intent");
            string actionCall = intentStaticClass.GetStatic<string>("ACTION_CALL");

            //Create Uri
            AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
            AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", phoneNum);

            //Pass ACTION_CALL and Uri.parse to the intent
            AndroidJavaObject intent = new AndroidJavaObject("android.content.Intent", actionCall, uriObject);
        });

        websiteButton.onClick.AddListener(() =>
        {
            Application.OpenURL(websiteAddress);
        });

        emailButton.onClick.AddListener(() =>
        {
            string email = emailAddress;

            string subject = MyEscapeURL("My Subject");

            string body = MyEscapeURL("My Body\r\nFull of non-escaped chars");

            Application.OpenURL("mailto:" + email + "?subject=" + subject + "&body=" + body);
        });
    }

    string MyEscapeURL(string url)
    {
        return UnityWebRequest.EscapeURL(url).Replace("+", "%20");
    }
}
