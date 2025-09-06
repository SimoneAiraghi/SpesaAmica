using System.Collections;
using System.Collections.Generic;
using Cassa.Script;
using TMPro;
using UnityEngine;

public class DaysCounter : MonoBehaviour
{
    public TextMeshProUGUI days;
    
    // Start is called before the first frame update
    public void Start()
    {
        days.text = CassaManagerScript.instance != null ? CassaManagerScript.instance.days.ToString() : "1";
    }
    
}
