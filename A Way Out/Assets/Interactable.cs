using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [Header("TYPE")]
    public float holdTime;
    public float interactRest;
    public int requiredPlayers;
    public float lastInteraction;
    public InteractableMarker marker;

    [Header("INTERACTION")]
    public InteractButton button;
    public InteractionType type;


    public void ToggleMarker(bool toggle, bool showMarker)
    {
        marker.ToggleInteraction(toggle);
        marker.ToggleMarker(showMarker);
    }
    public void SetupMarker(InputScheme controlScheme)
    {
        string s = "";
        if (button == InteractButton.PRIMARY)
            s = controlScheme.interact_Primary.key.ToString();
        else if (button == InteractButton.SECONDARY)
            s = controlScheme.interact_Secondary.key.ToString();
        else if (button == InteractButton.SPEAK)
            s = controlScheme.interact_Speak.key.ToString();

        marker.SetupMarker(s);
    }

    public virtual void Interact()
    {
        lastInteraction = Time.time;
    }

    public void SetRadialMarker(float t)
    {
        marker.SetRadialSlider(t / holdTime);
    }
}

public enum InteractionType
{
    CLICK,
    HOLD,
}
public enum InteractButton
{
    PRIMARY,
    SECONDARY,
    SPEAK
}