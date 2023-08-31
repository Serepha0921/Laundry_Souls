using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesManager : MonoBehaviour
{

    public static ClothesManager instance;
    public int clothes_number;
    public GameObject cloth;
    private Queue<GameObject> clothes;

    [Header("SortBucket")]
    public GameObject Laundry;
    public GameObject DryClean;
    public GameObject HouseHold;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        clothes = new Queue<GameObject>();
        GameObject temp;
        for (int i = 0; i < clothes_number; i++)
        {
            temp = Instantiate(cloth);
            temp.SetActive(false);
            instance.clothes.Enqueue(temp);
        }
    }

    
    public void sign_status(List<Clothes_Status> stat, int cloth_number)
    {
        GameObject temp;
        for(int i = 0; i < cloth_number; i++)
        {
            temp = instance.clothes.Dequeue();
            temp.GetComponent<Cloth>().status = stat[i];
            temp.GetComponent<SpriteRenderer>().sprite = stat[i].shape[0];
            temp.SetActive(true);
        }
    }
}
