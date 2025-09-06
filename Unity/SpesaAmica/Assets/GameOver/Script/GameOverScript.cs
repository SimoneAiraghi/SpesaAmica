using System;
using System.Collections;
using System.Collections.Generic;
using Cassa.Script;
using TMPro;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    public TextMeshProUGUI message;
    
    public void Start()
    {
        DrawText(CassaManagerScript.instance.gameOverMessage);
    }

    private void DrawText(string text)
    {
        message.text = text;
    }
}
