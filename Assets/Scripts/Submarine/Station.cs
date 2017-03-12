using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : InteractableObject
{
    int playerNumber;
    bool isActive;
    Exhaust exhaust;
    Submarine submarine;

    // Use this for initialization
    void Start()
    {
        submarine = LevelController.instance.submarine;
        exhaust = submarine.exhaust;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            //if (Input.GetAxis("HorizontalR" + playerNumber) != 0 || Input.GetAxis("VerticalR" + playerNumber) != 0)
            //{
            //    RotatePlayer(new Vector3(Input.GetAxis("HorizontalR" + playerNumber), 0, Input.GetAxis("VerticalR" + playerNumber)));
            //}
        }
        else
        {
            
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isActive)
        {
            if (Input.GetAxis("Horizontal" + playerNumber) != 0)
            {
                exhaust.RotateEngine(Input.GetAxis("Horizontal" + playerNumber));
            }
            else
            {
                exhaust.RotateEngine(0);
            }

            if (Input.GetAxis("Vertical" + playerNumber) != 0)
            {
                exhaust.MoveForward(Input.GetAxis("Vertical" + playerNumber));
            }
        }
    }

    public override void Interact(Player player)
    {
        if (isActive)
        {
            DetachPlayer(player);
        }
        else
        {
            AttachPlayer(player);
        }
    }

    private void AttachPlayer(Player player)
    {
        playerNumber = player.PlayerNumber;
        isActive = true;
        player.gameObject.transform.SetParent(submarine.transform);
        player.SetFreeze(true);
    }

    private void DetachPlayer(Player player)
    {
        playerNumber = 0;
        isActive = false;
        player.gameObject.transform.SetParent(null);
        player.SetFreeze(false);

    }
 }
