using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string NPC_Name;
    public string Title;

    [TextArea(1, 3)]
    public string[] sentences;
}
