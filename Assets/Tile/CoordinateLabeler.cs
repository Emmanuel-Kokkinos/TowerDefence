using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();

    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        DisplayCoordinates();
    }

    void Update()
    {
        //Only updates tile texts when in scene mode
        if(!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }
    }

    //Updates text on tiles when moving them in scene mode
    void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.y / UnityEditor.EditorSnapSettings.move.y);

        label.text = coordinates.x + "," + coordinates.y;
    }

    //Updates tile names in inspector
    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
