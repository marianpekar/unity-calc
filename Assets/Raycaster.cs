using UnityEngine;

public class Raycaster : MonoBehaviour
{
    Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Key key = hit.collider.gameObject.GetComponent<Key>();
                if (key)
                {
                    key.Press();
                }
            }
        }
    }
}
