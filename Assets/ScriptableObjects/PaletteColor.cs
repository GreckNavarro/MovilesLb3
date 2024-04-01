using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PaletteColor", menuName = "ScriptableObjects/PaletteColor", order = 2)]
public class PaletteColor : ScriptableObject
{
    [SerializeField] private Color titleColor;
    [SerializeField] private Color characterButtonsColor;
    [SerializeField] private Color playButtonColor;
    [SerializeField] private Color backgroundColor;

    public Color TitleColor => titleColor;
    public Color CharacterButtonsColor => characterButtonsColor;
    public Color PlayButtonColor => playButtonColor;
    public Color BackgroundColor => backgroundColor;



}
