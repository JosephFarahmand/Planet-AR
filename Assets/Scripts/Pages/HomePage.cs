using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomePage : MonoBehaviour
{
    public Button videoButton;

    public string vieoURL = "";

    private void Start()
    {
        videoButton.onClick.AddListener(() =>
        {
            Application.OpenURL(vieoURL);
        });
    }
}
