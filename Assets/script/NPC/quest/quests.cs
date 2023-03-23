using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "quest", menuName = "quest")]

public class quests : ScriptableObject
{
    public string [] textNPC;

    public int itemId, amount;

    public int questslide;
}