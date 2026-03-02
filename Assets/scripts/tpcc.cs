using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class tpcc : MonoBehaviour
{

    [SerializeField] private float zoomSpeed = 2f;
    [SerializeField] private float zoomlerpspeed = 10f;
    [SerializeField] private float mindistance = 3f;
    [SerializeField] private float maxdistance = 15f;

    private PlayerControls controls;

    private CinemachineCamera cam;
    private CinemachineOrbitalFollow orbital;

    private Vector2 scrollDelta;

    private float targetZoom;
    private float currentzoom;

    void Start()
    {
        controls = new PlayerControls();
        controls.Enable();
        controls.CameraControls.MouseZoom.performed += HandleMouseScroll;

        Cursor.lockState = CursorLockMode.Locked;

        cam = GetComponent<CinemachineCamera>();
        orbital = cam.GetComponent<CinemachineOrbitalFollow>();

        targetZoom = currentzoom = orbital.Radius;

    }
    
     private void HandleMouseScroll(InputAction.CallbackContext context)
    {

        scrollDelta = context.ReadValue<Vector2>();
        Debug.Log("Mouse is scrolling");

    }

    void Update()
    {
        if (scrollDelta.y != 0)
        {

            if (orbital != null)
            {

                targetZoom = Mathf.Clamp(orbital.Radius - scrollDelta.y * zoomSpeed, mindistance, maxdistance);
                scrollDelta = Vector2.zero;

            }

        }

        currentzoom = Mathf.Lerp(currentzoom, targetZoom, Time.deltaTime * zoomlerpspeed);
        orbital.Radius = currentzoom;
    }

}
