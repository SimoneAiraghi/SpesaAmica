using UnityEngine;
using UnityEngine.UI;

public class ImageDisplay : MonoBehaviour
{
    public Image broccoliImage;
    public Image cornImage;
    public Image frenchFriesImage;

    void Start()
    {
        int indicePersonaggio = PlayerPrefs.GetInt("SelectedCharacterIndex", 0);
        DisplaySelectedImage(indicePersonaggio);
    }

    void DisplaySelectedImage(int indicePersonaggio)
    {
     
        switch (indicePersonaggio)
        {
            case 0: //frenchfries
                broccoliImage.gameObject.SetActive(false);
                cornImage.gameObject.SetActive(false);
                frenchFriesImage.gameObject.SetActive(true);
                break;
            case 1: //corn
                broccoliImage.gameObject.SetActive(false);
                cornImage.gameObject.SetActive(true);
                frenchFriesImage.gameObject.SetActive(false);
                break;
            case 2: //broccoli
                broccoliImage.gameObject.SetActive(true);
                cornImage.gameObject.SetActive(false);
                frenchFriesImage.gameObject.SetActive(false);
                break;
            default:
                // Gestisci eventuali scenari non previsti
                break;
        }
    }
}
