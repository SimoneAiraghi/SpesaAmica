using UnityEngine;
using UnityEngine.UI;

public class InfoButton : MonoBehaviour
{
    public GameObject infoPanel; // Trascina il tuo pannello Info qui nella finestra ispettore
    public Button closeButton;

    void Start()
    {
        infoPanel.SetActive(false);

        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(ShowInfo);

        closeButton.onClick.AddListener(HideInfo);
    }

    void ShowInfo()
    {
        infoPanel.SetActive(true);
    }

    void HideInfo()
    {
        infoPanel.SetActive(false);
    }
}
