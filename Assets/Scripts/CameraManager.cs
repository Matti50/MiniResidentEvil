using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{

    [SerializeField]
    private CinemachineVirtualCamera _hallCamera;

    [SerializeField]
    private CinemachineVirtualCamera _corridorCamera;

    [SerializeField]
    private CinemachineVirtualCamera _roomCamera;


    void Start()
    {
        ActivateCamera(true, false, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActivateCamera(true, false, false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActivateCamera(false, true, false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ActivateCamera(false, false, true);
        }
    }

    private void ActivateCamera(bool hallCameraActive, bool corridorCameraActive, bool roomCameraActive)
    {
        _hallCamera.gameObject.SetActive(hallCameraActive);
        _corridorCamera.gameObject.SetActive(corridorCameraActive);
        _roomCamera.gameObject.SetActive(roomCameraActive);
    }
}
