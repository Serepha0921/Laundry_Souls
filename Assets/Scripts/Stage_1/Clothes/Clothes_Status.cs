using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Type {Laundry, Dry_Clean, Household};
[CreateAssetMenu(fileName = "Cloth", menuName = "ScriptableObject/Clothes")]
public class Clothes_Status :ScriptableObject {
    public int id;

    public string Clothes_name;
    public Type type;
    public Sprite[] shape;
    public float price;
}
