using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("SETUP")]
    public float interactionRange;

    [Header("INTERACTION")]
    public Interactable mouseInteractable;
    public List<Interactable> nearbyInteractable = new List<Interactable>();

    Player player;
    float holdTimer;

    void Start()
    {
        player = GetComponent<Player>();
    }
    void Update()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, interactionRange);
        foreach (var item in cols)
        {
            if (item.gameObject != gameObject)
            {
                if (item.GetComponent<Interactable>() != null)
                {
                    if (!nearbyInteractable.Contains(item.GetComponent<Interactable>()))
                        nearbyInteractable.Add(item.GetComponent<Interactable>());
                }
            }
        }

        List<Interactable> toRemove = new List<Interactable>();
        foreach (var item in nearbyInteractable)
        {
            if (Vector2.Distance(item.transform.position, transform.position) > interactionRange)
            {
                item.ToggleMarker(false, false);
                toRemove.Add(item);
            }
        }
        foreach (var item in toRemove)
        {
            nearbyInteractable.Remove(item);
        }
        foreach (var item in nearbyInteractable)
        {
            if (item != mouseInteractable)
                item.ToggleMarker(true, false);
        }

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
        if (hit)
        {
            if (hit.transform.GetComponent<Interactable>() != null)
            {
                if (nearbyInteractable.Contains(hit.transform.GetComponent<Interactable>()))
                {
                    mouseInteractable = hit.transform.GetComponent<Interactable>();
                    mouseInteractable.ToggleMarker(true, true);
                    mouseInteractable.SetupMarker(player.inputScheme);
                }
                else
                {
                    mouseInteractable = null;
                }
            }
            else
            {
                mouseInteractable = null;
            }
        }
        else
        {
            mouseInteractable = null;
        }

        if (mouseInteractable != null)
        {
            if (mouseInteractable.lastInteraction + mouseInteractable.interactRest <= Time.time)
            {
                if (mouseInteractable.type == InteractionType.CLICK)
                {
                    if (player.CheckInput(player.inputScheme.interact_Primary) && mouseInteractable.button == InteractButton.PRIMARY)
                    {
                        mouseInteractable.Interact();
                    }
                    else if (player.CheckInput(player.inputScheme.interact_Secondary) && mouseInteractable.button == InteractButton.SECONDARY)
                    {
                        mouseInteractable.Interact();
                    }
                    else if (player.CheckInput(player.inputScheme.interact_Speak) && mouseInteractable.button == InteractButton.SPEAK)
                    {
                        mouseInteractable.Interact();
                    }
                }
                else if (mouseInteractable.type == InteractionType.HOLD)
                {
                    if (player.CheckInput(player.inputScheme.interact_Primary) && mouseInteractable.button == InteractButton.PRIMARY)
                    {
                        holdTimer += Time.deltaTime;

                        if (holdTimer >= mouseInteractable.holdTime)
                        {
                            mouseInteractable.Interact();
                            holdTimer = 0;
                        }
                    }
                    else if (player.CheckInput(player.inputScheme.interact_Secondary) && mouseInteractable.button == InteractButton.SECONDARY)
                    {
                        holdTimer += Time.deltaTime;

                        if (holdTimer >= mouseInteractable.holdTime)
                        {
                            mouseInteractable.Interact();
                            holdTimer = 0;
                        }
                    }
                    else if (player.CheckInput(player.inputScheme.interact_Speak) && mouseInteractable.button == InteractButton.SPEAK)
                    {
                        holdTimer += Time.deltaTime;

                        if (holdTimer >= mouseInteractable.holdTime)
                        {
                            mouseInteractable.Interact();
                            holdTimer = 0;
                        }
                    }
                    else
                    {
                        holdTimer = 0;
                    }

                    mouseInteractable.SetRadialMarker(holdTimer);
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}
