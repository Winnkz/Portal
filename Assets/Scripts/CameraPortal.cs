using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPortal : MonoBehaviour
{
    public Camera mainCamera;
    
    public Camera otherCam;
    public PlayerMovement player;   
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion direccion = Quaternion.Inverse(transform.rotation) * mainCamera.transform.rotation;

        otherCam.transform.localEulerAngles = new Vector3(direccion.eulerAngles.x, direccion.eulerAngles.y - 180, direccion.eulerAngles.z);

        Vector3 distancia = transform.InverseTransformPoint(mainCamera.transform.position);
        otherCam.transform.localPosition = -new Vector3(distancia.x, -distancia.y, distancia.z);
    }
}
