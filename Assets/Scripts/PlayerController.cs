using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public int PlayerNumber;
    private Rigidbody rgbd;

    [SerializeField]
    private float movementSpeed;

    // Use this for initialization
    void Start()
    {
        
        rgbd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal" + PlayerNumber) != 0 || Input.GetAxis("Vertical" + PlayerNumber) != 0)
        {
            MovePlayer(new Vector3(Input.GetAxis("Horizontal" + PlayerNumber), 0, Input.GetAxis("Vertical" + PlayerNumber)));
        }
    }

    void Update()
    {
        if (Input.GetAxis("HorizontalR" + PlayerNumber) != 0 || Input.GetAxis("VerticalR" + PlayerNumber) != 0)
        {
            RotatePlayer(new Vector3(Input.GetAxis("HorizontalR" + PlayerNumber), 0, Input.GetAxis("VerticalR" + PlayerNumber)));
        }
    }

    /// <summary>
    /// Moves a player towards a controller defined direction
    /// </summary>
    /// <param name="direction"></param>
    void MovePlayer(Vector3 direction)
    {
        rgbd.MovePosition(new Vector3(gameObject.transform.localPosition.x + direction.x * movementSpeed, 0, gameObject.transform.localPosition.z + direction.z * movementSpeed));
    }

    /// <summary>
    /// Rotates a player towards a controller defined direction
    /// </summary>
    /// <param name="direction"></param>
    void RotatePlayer(Vector3 direction)
    {
        Vector3 relativePos = direction - transform.localPosition;
        //transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.LookRotation(relativePos), Time.deltaTime);
        transform.localRotation = Quaternion.LookRotation(relativePos);
    }
}
