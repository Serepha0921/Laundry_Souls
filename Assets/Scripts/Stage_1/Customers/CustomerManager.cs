using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CustomerManager : MonoBehaviour
{
    public GameObject customer;
    private Queue<GameObject> customers;
    public int customers_number;
    private bool turn = true;

    public string[] names;
    public Clothes_Status[] clothes;

    public static CustomerManager instance;

    private void Awake()
    {
        if(instance == null)
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
        customers = new Queue<GameObject>();
        GameObject temp;
        
        for (int i = 0; i < customers_number; i++)
        {
            temp = Instantiate(customer);
            temp.SetActive(false);
            instance.customers.Enqueue(temp);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        while (turn)
        {
            getCustomer();
            turn = false;
        }
    }

    public static GameObject getCustomer()
    {
        if(instance.customers.Count > 0)
        {
            GameObject custom = instance.customers.Dequeue();
            custom.SetActive(true);
            return custom;
        }

        return null;
    }

}
