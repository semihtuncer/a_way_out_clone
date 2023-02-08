using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public InputScheme inputScheme;

    public float horizontal;
    public float vertical;

    void Start()
    {

    }
    void Update()
    {
        GetInputs();
    }

    void GetInputs()
    {
        if (CheckInput(inputScheme.move_Forward))
        {
            vertical = 1;
        }
        if (CheckInput(inputScheme.move_Backward))
        {
            vertical = -1;
        }
        if (CheckInput(inputScheme.move_Forward) == CheckInput(inputScheme.move_Backward))
        {
            vertical = 0;
        }

        if (CheckInput(inputScheme.move_Right))
        {
            horizontal = 1;
        }
        if (CheckInput(inputScheme.move_Left))
        {
            horizontal = -1;
        }
        if (CheckInput(inputScheme.move_Left) == CheckInput(inputScheme.move_Right))
        {
            horizontal = 0;
        }
    }

    public bool CheckInput(InputModel im)
    {
        if (im.hold)
        {
            return Input.GetKey(im.key);
        }
        else
        {
            return Input.GetKeyDown(im.key);
        }
    }
}
