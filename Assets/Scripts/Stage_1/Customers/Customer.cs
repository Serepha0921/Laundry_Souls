using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Turn {my_turn, not_yet};
public class customer : MonoBehaviour {
    [Header("Customer_Status")]
    public string customer_name;
    public human type;
    public List<Clothes_Status> clothes;
    public Sprite[] appearance;

    [Header("Managers")]
    public CustomerManager customerManager;
    public ClothesManager clothesManager;

    [Space]
    public Dialogue dialogue;

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
        human human_type = (human)Random.Range(0, 5);
        SR = gameObject.GetComponent<SpriteRenderer>();
        trans = gameObject.GetComponent<Transform>();
        int R = 0;
        switch (human_type)
        {
            case human.oldadultfem2:
                R = 0;
                break;
            case human.adultfem:
                R = 1;
                break;
            case human.adultmasc:
                R = 2;
                break;
            case human.oldadultmasc:
                R = 3;
                break;
            case human.youngadultfem:
                R = 4;
                break;
            case human.youngadultmasc:
                R = 5;
                break;
            default:
                R = 0;
                break;
        }
        SR.sprite = appearance[R];

        amountClothes = Random.Range(1, 5);
        for(int i = 0; i < amountClothes; i++)
        {
            chooseClothes = Random.Range(0, customerManager.clothes.Length-1);
            clothes.Add(customerManager.clothes[chooseClothes]);
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
                SR.color = backColor;
                SR.sortingOrder = 1;
                trans.position = new Vector3(2.5f, 0f, 0f);
                trans.localScale = new Vector3(0.7f, 0.7f, 0.7f);
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

}
