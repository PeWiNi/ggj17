using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColors : MonoBehaviour
{
    public int numberOfChildObject = 0;
    Object obj = new Object();
    readonly float _colorMin = 0f;
    readonly float _colorMax = 1f;

    // Use this for initialization
    void Start()
    {
        numberOfChildObject = transform.GetComponentsInChildren<MeshRenderer>().Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfChildObject != transform.GetComponentsInChildren<MeshRenderer>().Length)
        {
            Debug.Log("if");
            ApplyColors();
        }
        else if (numberOfChildObject > 0 && numberOfChildObject == transform.GetComponentsInChildren<MeshRenderer>().Length)
        {
            Debug.Log("else if");
            ApplyColors();
        }
    }

    private void ApplyColors()
    {
        lock (obj)
        {
            var allChildren = transform.GetComponentsInChildren<MeshRenderer>();
            numberOfChildObject = allChildren.Length;
            foreach (var child in allChildren)
            {
                float modifier = child.transform.childCount * 0.01f;
                Debug.Log("modifier = " + modifier);
                switch (child.transform.tag.ToLower())
                {
                    case "cone":
                        child.materials[0].color = new Color(Mathf.Clamp(1f + modifier, _colorMin, _colorMax), Mathf.Clamp(1f + modifier, _colorMin, _colorMax), Mathf.Clamp(1f + modifier, _colorMin, _colorMax), 1f);
                        break;
                    case "cube":
                        child.materials[0].color = new Color(Mathf.Clamp(1f + modifier, _colorMin, _colorMax), Mathf.Clamp(1f + modifier, _colorMin, _colorMax), Mathf.Clamp(0f + modifier, _colorMin, _colorMax), 1f);
                        break;
                    case "cylinder":
                        child.materials[0].color = new Color(Mathf.Clamp(1f + modifier, _colorMin, _colorMax), Mathf.Clamp(0f + modifier, _colorMin, _colorMax), Mathf.Clamp(0f + modifier, _colorMin, _colorMax), 1f);
                        break;
                    case "helix":
                        child.materials[0].color = new Color(Mathf.Clamp(0f + modifier, _colorMin, _colorMax), Mathf.Clamp(0f + modifier, _colorMin, _colorMax), Mathf.Clamp(1f + modifier, _colorMin, _colorMax), 1f);
                        break;
                    case "pyramid":
                        child.materials[0].color = new Color(Mathf.Clamp(0f + modifier, _colorMin, _colorMax), Mathf.Clamp(1f + modifier, _colorMin, _colorMax), Mathf.Clamp(1f + modifier, _colorMin, _colorMax), 1f);
                        break;
                    case "sphere":
                        child.materials[0].color = new Color(Mathf.Clamp(.5f + modifier, _colorMin, _colorMax), Mathf.Clamp(1f + modifier, _colorMin, _colorMax), Mathf.Clamp(1f + modifier, _colorMin, _colorMax), 1f);
                        break;
                    case "torus":
                        child.materials[0].color = new Color(Mathf.Clamp(1f + modifier, _colorMin, _colorMax), Mathf.Clamp(.5f + modifier, _colorMin, _colorMax), Mathf.Clamp(.5f + modifier, _colorMin, _colorMax), 1f);
                        break;
                    default:
                        child.materials[0].color = new Color(1f + modifier, 1f + modifier, .5f + modifier, .1f);
                        break;
                }
            }
        }
    }
}
