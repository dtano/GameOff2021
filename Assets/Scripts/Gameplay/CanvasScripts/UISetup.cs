using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISetup : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log($"Canvas scale factor is {canvas.scaleFactor}");
        DragDrop.SetCanvasScaleFactor(canvas.scaleFactor);    
    }
}
