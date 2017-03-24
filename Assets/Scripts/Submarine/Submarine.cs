using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submarine : MonoBehaviour
{
    private Rigidbody rgbd;
    private float movementSpeed = 0.4f;
    
    public Station steeringWheel;
    public Exhaust exhaust;
    


    // Use this for initialization
    void Start()
    {
        rgbd = GetComponentInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    /// <summary>
    /// Moves a player towards a controller defined direction
    /// </summary>
    /// <param name="direction"></param>
    public void MoveSub(Vector3 direction)
    {
        rgbd.MovePosition(new Vector3(gameObject.transform.localPosition.x + direction.x * movementSpeed, 0, gameObject.transform.localPosition.z + direction.z * movementSpeed));
    }
}
