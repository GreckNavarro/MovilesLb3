using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] private Text title;
    [SerializeField] private Image[] buttonsImages;
    [SerializeField] private Image buttonGame;

    public void SelectPaletteColor(PaletteColor newColor)
    {
        background.color = newColor.BackgroundColor;
        title.color = newColor.TitleColor;
        for(int i = 0; i < buttonsImages.Length; i++)
        {
            buttonsImages[i].color = newColor.CharacterButtonsColor;
        }
        buttonGame.color = newColor.PlayButtonColor;
    }
}
