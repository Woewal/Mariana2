using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public int PlayerNumber;
    private Rigidbody rgbd;

    private bool isStatic = false;

    [SerializeField]
    private float movementSpeed;

    private InteractableObject isCollidingWith;

    // Use this for initialization
    void Start()
    {
        
        rgbd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((Input.GetAxis("Horizontal" + PlayerNumber) != 0 || Input.GetAxis("Vertical" + PlayerNumber) != 0) && !isStatic)
        {
            MovePlayer(new Vector3(Input.GetAxis("Horizontal" + PlayerNumber), 0, Input.GetAxis("Vertical" + PlayerNumber)));
        }
    }

    void Update()
    {
        if ((Input.GetAxis("HorizontalR" + PlayerNumber) != 0 || Input.GetAxis("VerticalR" + PlayerNumber) != 0) && !isStatic)
        {
            RotatePlayer(new Vector3(Input.GetAxis("HorizontalR" + PlayerNumber), 0, Input.GetAxis("VerticalR" + PlayerNumber)));
        }

        if (Input.GetButtonDown("Interact" + PlayerNumber) && isCollidingWith != null)
        {
            isCollidingWith.Interact(this);
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<InteractableObject>())
        {
            isCollidingWith = other.gameObject.GetComponent<InteractableObject>();
        }
    }

    public void SetFreeze(bool shouldFreeze)
    {
        if (shouldFreeze)
        {
            rgbd.isKinematic = true;
            isStatic = true;
        }
        else
        {
            rgbd.isKinematic = false;
            isStatic = false;
        }
    }
}
