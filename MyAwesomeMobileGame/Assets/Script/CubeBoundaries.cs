using UnityEngine;

public class CubeBoundaries : MonoBehaviour
{
    public float minX = -5f; 
    public float maxX = 5f;  
    private float _playerYPosition;

    void Update()
    {
        if( Input.GetMouseButton(0) )
        CheckBoundaries();
    }

    void CheckBoundaries()
    {
        var mousePosition = Input.mousePosition; var bottomLeftBoundary = Camera.main.ViewportToWorldPoint(Vector3.zero);
        var topRightBoundary = Camera.main.ViewportToWorldPoint(Vector3.one);
        var mousePositionInWorldSpace = Camera.main.ScreenToWorldPoint(mousePosition); 
        mousePositionInWorldSpace.z = 0; mousePositionInWorldSpace.y = _playerYPosition; 
        mousePositionInWorldSpace.x = Mathf.Clamp(mousePositionInWorldSpace.x, bottomLeftBoundary.x + .5f, topRightBoundary.x - .5f); 
        transform.position = mousePositionInWorldSpace;
    }
}
