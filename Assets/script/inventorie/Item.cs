using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "create new Item")]  
public class Item : ScriptableObject
{
    public int itemId;
    public string nameItem;

    public int startStack, maxStack;

    public Texture icon;
    public GameObject prefap;

    public Types type;

    [SerializeField] LayerMask itemlayer;

    public enum Types
    {
        test,
        quest,
        item,
        weapon,
        Ammo,
        healing,
    }
}
