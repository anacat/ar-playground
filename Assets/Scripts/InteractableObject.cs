using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour
{
    public Canvas canvas;
    public Button button;
    public GameObject selectionVisualizer;
    public TextMeshPro text;

    private void Awake()
    {
        Deselect();

        canvas.worldCamera = Camera.main;
    }

    public void Select()
    {
        selectionVisualizer.SetActive(true);
        button.gameObject.SetActive(true);

        //text.text = "selected";
    }

    public void Deselect()
    {
        selectionVisualizer.SetActive(false);
        button.gameObject.SetActive(false);

        //text.text = "";
    }

    public void ButtonClick()
    {
        Destroy(gameObject);
    }
}
