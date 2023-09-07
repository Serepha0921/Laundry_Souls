using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloth : MonoBehaviour
{
    public Clothes_Status status;

    [Header("Moving")]
    public Transform movingPoint;
    public float speed = 0.1f;
    private bool inital_moving;

    private bool moving;

    private float startPosX;
    private float startPosY;

    private void Awake()
    {
        Vector2 S = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
        gameObject.GetComponent<BoxCollider2D>().size = S;
        inital_moving = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (moving)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x, mousePos.y, this.gameObject.transform.localPosition.z);
        }
    }

    private void LateUpdate()
    {
        if (inital_moving)
        {
            if (transform.position != movingPoint.position)
            {
                Vector3 desiredPosition = movingPoint.position;
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, speed);
                transform.position = smoothedPosition;
            }
            else
            {
                inital_moving = false;
            }
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
            startPosY = mousePos.y = this.transform.localPosition.y;

            moving = true;
        }
    }

    private void OnMouseUp()
    {
        moving = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("in");
        if (collision.gameObject.tag == "SortingBucket")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = status.shape[2];
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Out");
        gameObject.GetComponent<SpriteRenderer>().sprite = status.shape[0];
    }
}
