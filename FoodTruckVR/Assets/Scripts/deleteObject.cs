using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteObject : MonoBehaviour
{
    public string[] DeletableTags;

    private GameObject toDelete;

    // Fixed update is for physics updates regardless of framerate, should fix things skipping the trigger
    void FixedUpdate()
    {
        if (toDelete != null)
        {
            toDelete.transform.position = new Vector3(0f, -20000f, 0f); //teleport the object very far away to trigger Exit collision and trigger script functions
            Destroy(toDelete, 0.1f); //slight delay for time to trigger the function
        }
    }

    void OnTriggerStay(Collider objectCollide) //OnTriggerStay is more robust than plainly using OnTriggerEnter
    {
        foreach(string tag in DeletableTags) //go through the array one by one
        {
            if (objectCollide.CompareTag( tag )) //if it matches a tag in the array, delete the object
            {
                //kill object
                toDelete = objectCollide.gameObject;

            }
        }

        ////ideally use a public array that can be modified on the prefab
        //if (objectCollide.CompareTag("Taco") || objectCollide.CompareTag("ChipBowl") || objectCollide.CompareTag("Refill") || objectCollide.CompareTag("Deletable") || objectCollide.CompareTag("Cash"))
        //{
        //    //kill object
        //    toDelete = objectCollide.gameObject;

        //}
    }
}
