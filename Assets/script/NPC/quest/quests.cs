using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "quest", menuName = "quest")]

public class quests : ScriptableObject
{
    public string [] quest;

    public static bool questAccept;
}