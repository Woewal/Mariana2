using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMovementt : MonoBehaviour
{
    private Rigidbody rgbd;
    private float movementSpeed = 10;
    


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

    /// <summary>
    /// Rotates a player towards a controller defined direction
    /// </summary>
    /// <param name="direction"></param>
    public void RotateSub(Vector3 direction)
    {
        Vector3 relativePos = direction - transform.localPosition;
        //transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.LookRotation(relativePos), Time.deltaTime);
        transform.localRotation = Quaternion.LookRotation(relativePos);
    }

}
