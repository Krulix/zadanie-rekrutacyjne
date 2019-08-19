using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InitWindow : MonoBehaviour
{
    public TMP_InputField inputField;
    public RodWindow rodWindow;
    public CanvasGroup canvasGroup;

    public void InitRodWindow()
    {
        int rodCount;
        int.TryParse(inputField.text, out rodCount);
        rodWindow.Show(rodCount);
        Hide();
    }

    public void Show()
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;
    }

    public void Hide()
    {
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
    }
}
