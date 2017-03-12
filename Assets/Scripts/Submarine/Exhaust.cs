using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exhaust : MonoBehaviour {

    Submarine submarine;
    Rigidbody rgbd;
    [SerializeField]
    float rotationSpeed = 30f;
    [SerializeField]
    float acceleration = 30f;

	// Use this for initialization
	void Start () {
        submarine = LevelController.instance.submarine;
        rgbd = GetComponent<Rigidbody>();
	}

    void Update()
    {
        //if (Input.GetButtonDown("Debug"))
        //{
        //    RotateEngine(0);
        //}
    }

    public void RotateEngine(float amount)
    {
        rgbd.AddTorque(new Vector3(0, -amount * rotationSpeed, 0));
    }

    public void MoveForward(float amount)
    {
        rgbd.AddRelativeForce(Vector3.forward * acceleration * amount);
    }
}
