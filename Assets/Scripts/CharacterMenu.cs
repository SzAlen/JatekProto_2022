using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    //textek
    public Text hitpointText, pointsText, survivorsSavedText, foodCollectedText;

    private int currentCharacterSelection = 0;
    public Image characterSelectionSprite;

    //character selection
    public void OnArrowClick(bool right)
    {
        if(right)
        {
            currentCharacterSelection ++;

            if(currentCharacterSelection == GameManager.instance.playerSprites.Count)
                currentCharacterSelection = 0;

            OnSelectionChanged();
        }
        else
        {
            currentCharacterSelection --;

            if(currentCharacterSelection < 0)
                currentCharacterSelection = GameManager.instance.playerSprites.Count - 1;

            OnSelectionChanged();
        }
    }

    private void OnSelectionChanged()
    {
        characterSelectionSprite.sprite = GameManager.instance.playerSprites[currentCharacterSelection];
    }

    //Update character info
    public void UpdateMenu()
    {
        hitpointText.text = GameManager.instance.player.hitpoint.ToString();
        survivorsSavedText.text = GameManager.instance.survivorsSaved.ToString();
        foodCollectedText.text = GameManager.instance.foodCollected.ToString();
        pointsText.text = GameManager.instance.points.ToString();
    }

}
