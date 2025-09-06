using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
   [SerializeField] Slider volumeSlider;
   public Button confirmButton;
   void Start()
   {
       if (!PlayerPrefs.HasKey("musicVolume"))
       {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
       }
   
       else 
       {
         Load();
       } 
    if (confirmButton != null)
        {
            // Aggiungi il gestore di eventi al bottone di conferma
            confirmButton.onClick.AddListener(OnConfirmButtonPressed);
        }
        else
        {
            Debug.LogError("Il pulsante di conferma non è stato assegnato nell'Inspector.");
        }
   }

   public void ChangeVolume()
   {
     AudioListener.volume = volumeSlider.value;
     Save();
     confirmButton.onClick.AddListener(OnConfirmButtonPressed);
   }

   private void Load()
   {
       volumeSlider.value =PlayerPrefs.GetFloat("musicVolume");
   }

   private void Save()
   {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
   }
 
   public void OnConfirmButtonPressed()
    {
        if (confirmButton != null)
        {
        // Disattiva lo slider
        volumeSlider.gameObject.SetActive(false);

        // Disattiva il bottone di conferma
        confirmButton.gameObject.SetActive(false);
        }
        else 
        {
          Debug.LogError("Il pulsante di conferma non è stato inizializzato correttamente.");
        }
    }         

}
