using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringWheel : InteractableObject
{
    public SubMovementt submovement;
    int playerNumber;
    bool isActive;

    // Use this for initialization
    void Start()
    {

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
            if (Input.GetAxis("Horizontal" + playerNumber) != 0 || Input.GetAxis("Vertical" + playerNumber) != 0)
            {
                submovement.MoveSub(new Vector3(Input.GetAxis("Horizontal" + playerNumber), 0, Input.GetAxis("Vertical" + playerNumber)));
            }
        }
    }

    public override void Interact(PlayerController player)
    {
        AttachPlayer(player);
    }

    private void AttachPlayer(PlayerController player)
    {
        playerNumber = player.PlayerNumber;
        isActive = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {

        }
    }


}
