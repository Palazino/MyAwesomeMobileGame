using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorOnClick : MonoBehaviour
{
    private Color defaultColor;
    private Renderer rend;
    private bool isDragging;

    void Start()
    {
        rend = GetComponent<Renderer>();
        if (rend != null)
        {
            defaultColor = rend.material.color;
        }
    }

    void Update()
    {
        // Vérifie si la souris est enfoncée
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null && hit.collider.gameObject == gameObject)
                {
                    isDragging = true;
                    ChangeColor();
                }
            }
        }

        // Vérifie si la souris est relâchée
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            ResetColor();
        }
    }

    void ChangeColor()
    {
        if (rend != null)
        {
            rend.material.color = Color.red; // Change la couleur en rouge
        }
    }

    void ResetColor()
    {
        if (rend != null)
        {
            rend.material.color = defaultColor; // Réinitialise la couleur par défaut
        }
    }
}
