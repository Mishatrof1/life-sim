using System;
using UnityEngine;
using UnityEngine.UI;

public class DropdownTemplateSortingFix : MonoBehaviour
{
    private Canvas _canvas;
    
    private void Awake()
    {
        _canvas = GetComponent<Canvas>();
    }

    private void Update()
    {
        if (_canvas == null)
            return;
        
        _canvas.sortingLayerName = "Popup";
    }
}