using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Turn {my_turn, not_yet};
public class customer : MonoBehaviour {
    [Header("Customer_Status")]
    public string customer_name;
    public List<Clothes_Status> clothes;
    public Sprite[] appearance;

    [Header("Managers")]
    public CustomerManager customerManager;
    public ClothesManager clothesManager;

    [Space]

    public Turn turn; 

    private SpriteRenderer SR;
    private Transform trans;
    private Color backColor = new Color(0.65f, 0.65f, 0.65f);
    private Color frontColor = new Color(1f, 1f, 1f);

    private int amountClothes = 0;
    private int chooseClothes = 0;
    private GameObject cloth;
    private bool ClothSpawned = false;

    private void Awake()
    {
        int face = Random.Range(0, 5);
        SR = gameObject.GetComponent<SpriteRenderer>();
        trans = gameObject.GetComponent<Transform>();
        
        SR.sprite = appearance[face];

        amountClothes = Random.Range(1, 5);
        for(int i = 0; i < amountClothes; i++)
        {
            chooseClothes = Random.Range(0, customerManager.clothes.Length-1);
            clothes.Add(customerManager.clothes[chooseClothes]);
            customer_name = customerManager.names[Random.Range(0, customerManager.names.Length - 1)];
        }
    }

    private void Update()
    {
        
        switch (turn)
        {
            case Turn.my_turn:
                SR.color = frontColor;
                SR.sortingOrder = 3;
                trans.position = new Vector3(2.1f,-0.3f,0f);
                trans.localScale = new Vector3(1f, 1f, 1f);

                spawn_Clothes();
                
                break;
            case Turn.not_yet:
                gameObject.SetActive(false);
                break;
        }
    }

    private void spawn_Clothes()
    {
        if (!ClothSpawned)
        {
            clothesManager.sign_status(clothes, amountClothes);
        }
        ClothSpawned = true;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "Ticket"){
            Debug.Log("Next");
            if(!other.gameObject.GetComponent<Drag_Feature>().moving){
                customerManager.next = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.name == "Ticket"){
            Debug.Log("Next");
            if(!other.gameObject.GetComponent<Drag_Feature>().moving){
                customerManager.next = true;
            }
        }
    }

}
