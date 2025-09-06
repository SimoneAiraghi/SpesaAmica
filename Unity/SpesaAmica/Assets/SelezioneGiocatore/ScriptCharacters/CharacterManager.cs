using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterManager : MonoBehaviour
{
    public CharacterDatabase characterDB;
    
    public TextMeshProUGUI descriptionText;
    public SpriteRenderer artworkSprite;

    private int selectedOption = 0; 
    
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateCharacter(selectedOption);
        KeepCharacterIndex();
    }

    public void NextOption()
    {
        selectedOption++;

        if (selectedOption >= characterDB.CharacterCount)
        {
            selectedOption = 0; 
        }

        UpdateCharacter(selectedOption);
        KeepCharacterIndex();
    }

    public void BackOption()
    {
        selectedOption--;

        if (selectedOption < 0)
        {
            selectedOption = characterDB.CharacterCount - 1; 
        }

        UpdateCharacter(selectedOption);
        KeepCharacterIndex();
    }

    private void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite;
        descriptionText.text = character.characterDescription; 
    }

    public void KeepCharacterIndex()
    {
        PlayerPrefs.SetInt("SelectedCharacterIndex", selectedOption); 
    }
    
}
