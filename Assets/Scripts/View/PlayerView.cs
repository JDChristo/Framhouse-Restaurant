using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : BaseClass
{
    [SerializeField] private Transform player1;
    [SerializeField] private Transform player2;

    private PlayerController playerController;

    
    private Transform currentPlayer;
    private Rigidbody2D playerBody;

    public Transform CurrentPlayer { get => currentPlayer; }
    public Rigidbody2D PlayerBody { get => playerBody; }
    public Transform PlayerOne { get => player1; }
    public Transform PlayerTwo { get => player2; }

    private void SetPlayer(Transform p)
    {
        currentPlayer = p;
        playerBody = p.GetComponent<Rigidbody2D>();
    }

    public void PlayerMovement(Vector2 velocity)
    {
        playerBody.velocity = velocity;
    }

    public void SwitchPlayer()
    {
        PlayerMovement(Vector2.zero);
        SetPlayer((currentPlayer == player1) ? player2 : player1);
    }

    public void Init()
    {
        playerController = SetController<PlayerController>();
        SetPlayer(player1);
    }
}
