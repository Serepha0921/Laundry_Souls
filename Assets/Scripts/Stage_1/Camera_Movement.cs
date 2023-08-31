using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour {

    public Transform Camera;

    [Header("UI")]
    public GameObject UP;
    public GameObject DOWN;
    [SerializeField]private int cut = 0;

    [Space]
    public float downdistance;
    public float speed = 0.15f;
    public float speed2 = 20f;
    private Vector3 offset = new Vector3 (0,0,-10);

    public void downButton() {
        offset += new Vector3(0, -downdistance, 0);
        cut++;
    }

    public void UpButton()
    {
        offset += new Vector3(0, downdistance, 0);
        cut--;
    }

    private void Update()
    {
        switch (cut)
        {
            case 0:
                
                break;
        }
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = offset;
        Vector3 smoothedPosition = Vector3.Lerp(Camera.position, desiredPosition, speed);
        Camera.position = smoothedPosition;
    }
}
