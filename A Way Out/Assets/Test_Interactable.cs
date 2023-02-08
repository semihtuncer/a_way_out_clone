using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Interactable : Interactable
{
    public DoorController dc;
    public List<SpriteRenderer> sr;

    public override void Interact()
    {
        base.Interact();

        StartCoroutine(Wire());
        dc.ToggleDoor();
    }

    IEnumerator Wire()
    {
        foreach (var item in sr)
        {
            item.color = Color.green;
        }
        yield return new WaitForSeconds(0.2f);
        foreach (var item in sr)
        {
            item.color = Color.white;
        }
    }
}