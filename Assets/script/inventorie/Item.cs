using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "create new Item")]
[System.Serializable]
public class Item : ScriptableObject
{
    public int itemId;
    public string nameItem;

    public int startStack, maxStack;

    public Texture icon;
    public GameObject prefap;

    public Types type;

    public enum Types
    {
        test,
        quest,
        item,
        Ammo,
        healing,
    }
}
