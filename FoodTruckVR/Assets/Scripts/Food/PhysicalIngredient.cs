using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalIngredient : Ingredient
{
    public bool CanGrab = true;

    private GameObject toDelete;

    private void Awake()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (toDelete != null)
        {
            toDelete.transform.position = new Vector3(0f, -20000f, 0f); //teleport the object very far away to trigger Exit collision and trigger script functions
            Destroy(toDelete, 0.1f); //slight delay for time to trigger the function
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<FoodContainer>() != null)
        {
            if (collision.gameObject.GetComponent<FoodContainer>().AddIngredient(this))
            {
                toDelete = gameObject;
            }
        } else
        {
            //Debug.Log("Failure to add");
        }
    }

}
