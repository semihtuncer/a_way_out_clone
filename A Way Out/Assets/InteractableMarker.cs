using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableMarker : MonoBehaviour
{
    public Interactable interactable;

    [Header("UI")]
    public Text keyText;
    public Image radial;
    public Image square;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        interactable = GetComponentInParent<Interactable>();
    }

    public void SetupMarker(string s)
    {
        anim = GetComponent<Animator>();
        interactable = GetComponentInParent<Interactable>();

        if (interactable.type == InteractionType.HOLD)
        {
            radial.transform.parent.gameObject.SetActive(true);
            square.gameObject.SetActive(false);
        }
        else
        {
            radial.transform.parent.gameObject.SetActive(false);
            square.gameObject.SetActive(true);
        }

        keyText.text = s;
    }
    public void SetRadialSlider(float t)
    {
        radial.fillAmount = t;
    }

    public void ToggleMarker(bool t)
    {
        anim.SetBool("SHOW_MARKER", t);
    }
    public void ToggleInteraction(bool t)
    {
        anim.SetBool("SHOW", t);
    }
}