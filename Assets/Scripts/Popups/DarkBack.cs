using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class DarkBack : MonoBehaviour
{
    public delegate void OnEndTransition();


    private CanvasGroup cg
    {
        get
        {
            return GetComponent<CanvasGroup>();
        }
    }

    public float fadeTime = 0f;

    private OnEndTransition _event;

    public void Show(OnEndTransition callback = null)
    {
        _event = callback;
        StartFade(1);
    }

    public void Hide(OnEndTransition callback = null)
    {
        _event = callback;
        StartFade(0);
    }

    private void StartFade(float targetAlpha)
    {
        cg.DOFade(targetAlpha, fadeTime).OnComplete(CallEvent);
    }

    private void CallEvent()
    {
        _event?.Invoke();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

}
