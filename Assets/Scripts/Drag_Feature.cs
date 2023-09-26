using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag_Feature : MonoBehaviour
{
    public bool moving;

    private float startPosX;
    private float startPosY;

    // Start is called before the first frame update
    private void Start()
    {
        moving = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (moving)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y -startPosY, this.gameObject.transform.localPosition.z);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            moving = true;
        }
    }

    private void OnMouseUp()
    {
        moving = false;
    }
}
