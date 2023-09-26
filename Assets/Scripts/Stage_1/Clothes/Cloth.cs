using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloth : MonoBehaviour
{
    public string owner;
    public Clothes_Status status;
    [Header("ClothManager")]
    public ClothesManager cm;
    [Header("Moving")]
    public Transform movingPoint;
    public float speed = 0.1f;
    private bool inital_moving;
    private Drag_Feature DF;

    private void Awake()
    {
        Vector2 S = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
        gameObject.GetComponent<BoxCollider2D>().size = S;
        DF = gameObject.GetComponent<Drag_Feature>();
        inital_moving = true;
    }

    // Update is called once per frame

    private void Update()
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SortingBucket")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = status.shape[status.shape.Length - 1];
            if(!DF.moving){
                gameObject.transform.position = movingPoint.position;
                cm.sorted(gameObject, collision.name);
                cm.RidClothes(gameObject);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.tag == "SortingBucket")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = status.shape[status.shape.Length - 1];
            if(!DF.moving){
                gameObject.transform.position = movingPoint.position;
                cm.sorted(gameObject, collision.name);
                cm.RidClothes(gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = status.shape[0];
    }
}
