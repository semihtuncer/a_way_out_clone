using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Input Scheme")]
public class InputScheme : ScriptableObject
{
    [Header("MOVEMENT")]
    public InputModel move_Forward;
    public InputModel move_Backward;
    public InputModel move_Left;
    public InputModel move_Right;

    [Space(5)]
    public InputModel move_Sprint;

    [Header("INTERACTION")]
    public InputModel interact_Primary;
    public InputModel interact_Secondary;
    public InputModel interact_Speak;
    public InputModel interact_Cancel;
}

[System.Serializable]
public class InputModel
{
    public bool hold;
    public KeyCode key;
}