﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{

    Player player;

    void Start()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        player.SetDirectionalInput(input);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.OnJumpKeyDown();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            player.OnJumpKeyUp();
        }
    }
}
