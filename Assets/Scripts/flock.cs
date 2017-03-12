using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flock : MonoBehaviour
{

    public float speed = 0.1f;
    float rotationSpeed = 4.0f; // How fast fish will turn. 
    Vector3 averageHeading; //Heading direction, head towards average heading of group.
    Vector3 averagePosition;    //Average position of the group.
    float neighbourDistance = 3.0f; //Maximum distance fish need to be to each other to flock.

    bool turning = false; // turns true if fish reach boundary

    // Use this for initialization
    void Start()
    {
        speed = Random.Range(1, 3); //Sets random fish speed at start.
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, Vector3.zero) >= globalFlock.tankSize)
        {
            turning = true;
        }
        else
        {
            turning = false; 
        }

        if(turning)
        {
            Vector3 direction = Vector3.zero - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
            speed = Random.Range(0.5f, 1);
        }

        if (Random.Range(0, 5) < 1)
            ApplyRules();

        transform.Translate(0, 0, Time.deltaTime * speed);
    }

    void ApplyRules()
    {
        GameObject[] gos;
        gos = globalFlock.allFish;  //grab all the fish

        Vector3 vcentre = Vector3.zero; //centre of the group
        Vector3 vavoid = Vector3.zero;  //avoid hitting fish in the middle
        float gSpeed = 0.1f;    //Initial group speed.

        Vector3 goalPos = globalFlock.goalPos;

        float dist; // distance variable

        int groupSize = 0;  //groupsize of the fish, who is within the neighbour distance
        foreach (GameObject go in gos)
        {
            if (go != this.gameObject)
            {
                dist = Vector3.Distance(go.transform.position, this.transform.position);
                if (dist <= neighbourDistance)        // is fish part of the group?
                {
                    vcentre += go.transform.position;   //Add up the centres
                    groupSize++;    //Add up the groupsize

                    if (dist < 1.0f)  //if small distance avoid
                    {
                        vavoid = vavoid = (transform.transform.position - go.transform.position);   //calculate vector away from fish
                    }

                    flock anotherFlock = go.GetComponent<flock>();  //grab flock script and add up speeds
                    gSpeed = gSpeed + anotherFlock.speed;   //group speed
                }
            }
        }

        if (groupSize > 0) //if we are in a group
        {
            vcentre = vcentre / groupSize + (goalPos - this.transform.position);    //calculate the average centre
            speed = gSpeed / groupSize;    //calculate the average speed

            Vector3 direction = (vcentre = vavoid) - transform.position;
            if (direction != Vector3.zero)
                transform.rotation = Quaternion.Slerp(transform.rotation,
                                                      Quaternion.LookRotation(direction),
                                                      rotationSpeed * Time.deltaTime);
        }

    }

}
