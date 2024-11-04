using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f; 

    private Vector3 targetPosition;
    private bool isMoving = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetTargetPosition();
        }
        if (isMoving)
        {
            MoveToTargetPosition();
        }
    }

    void SetTargetPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.nearClipPlane;
        targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        targetPosition.y = transform.position.y; 
        targetPosition.z = transform.position.z; 

        isMoving = true;
    }

    void MoveToTargetPosition()
    {
        float step = moveSpeed * Time.deltaTime; // Calculer le pas en fonction de la vitesse et du temps écoulé
        transform.position = Vector3.Lerp(transform.position, targetPosition, step);

        // Arrêter le mouvement une fois la position atteinte
        if (Vector3.Distance(transform.position, targetPosition) < 0.001f)
        {
            transform.position = targetPosition;
            isMoving = false;
        }
    }
}
