using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private bool isDragging = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null && hit.collider.gameObject == gameObject)
                {
                    isDragging = true;
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

       
        if (isDragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 newPos = new Vector3(hit.point.x, transform.position.y, transform.position.z);
                transform.position = newPos;
            }
        }
    }
}
