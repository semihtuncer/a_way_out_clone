using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float walkSpeed;
    public float runSpeed;
    public float acceleration;

    public float positionChange;

    Vector2 moveDir;
    Player player;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();

        moveSpeed = walkSpeed;
    }
    void Update()
    {
        moveDir = Vector3.Lerp(moveDir, new Vector2(player.horizontal, player.vertical).normalized, Time.deltaTime * positionChange);

        moveSpeed = Mathf.Lerp(moveSpeed, player.CheckInput(player.inputScheme.move_Sprint) ? runSpeed : walkSpeed, Time.deltaTime * acceleration);
        rb.velocity = moveDir * moveSpeed;
    }
}
