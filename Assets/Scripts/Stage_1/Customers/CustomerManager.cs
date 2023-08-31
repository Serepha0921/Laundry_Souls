using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum human { oldadultfem2, adultfem, adultmasc, oldadultmasc, youngadultfem, youngadultmasc };
public class CustomerManager : MonoBehaviour
{
    public GameObject customer;
    private Queue<GameObject> customers;
    public int customers_number;
    private List<GameObject> line;

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
        line = new List<GameObject>();
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
        while (line.Count < 2)
        {
            line.Add(getCustomer());
        }
        line[1].GetComponent<customer>().turn = Turn.not_yet;
        line[0].GetComponent<customer>().turn = Turn.my_turn;
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
