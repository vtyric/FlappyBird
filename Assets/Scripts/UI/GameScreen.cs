using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameScreen : Screen
{
    public UnityAction PlayButtonClick;

    protected override void OnButtonClick() => PlayButtonClick?.Invoke();

    public override void Open() => ChangeScreen(1, true);

    public override void Close() => ChangeScreen(0, false);

    private void ChangeScreen(int canvasGroupAlpha, bool isInteractable)
    {
        CanvasGroup.alpha = canvasGroupAlpha;
        Button.interactable = isInteractable;
    }
}
