﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinCollider : MonoBehaviour
{
    public GameObject ingredSpawn1;
    public GameObject ingredSpawn2;
    public GameObject ingredSpawn3;

    public PhysicalIngredient IngredTempPref;

    private GameObject toDelete;

    // Update is called once per frame
    void LateUpdate()
    {
        if (toDelete != null)
        {
            toDelete.transform.position = new Vector3(0f, -20000f, 0f); //teleport the object very far away to trigger Exit collision and trigger script functions
            Destroy(toDelete, 0.1f); //slight delay for time to trigger the function
        }
    }

    void OnTriggerEnter (Collider refillCollide)
    {
        if (refillCollide.CompareTag("Refill"))
        {
            ContainerManager containerManager = ContainerManager.SharedInstance;

            //get pickup container
            PickupIngredientContainer pickupContainer = containerManager.PickupIngredientContainer;

            //Debug.Log("refilled");

            //temp vars for ingreds
            //PhysicalIngredient IngredInst1;
            //PhysicalIngredient IngredInst2;
            //PhysicalIngredient IngredInst3;

            pickupContainer.GetIngredientModelByType(refillCollide.GetComponent<Refill>().IngredientType).transform.position = ingredSpawn1.transform.position;
            pickupContainer.GetIngredientModelByType(refillCollide.GetComponent<Refill>().IngredientType).transform.position = ingredSpawn2.transform.position;
            pickupContainer.GetIngredientModelByType(refillCollide.GetComponent<Refill>().IngredientType).transform.position = ingredSpawn3.transform.position;

            //create each ingredient
            //IngredInst1 = Instantiate(IngredTempPref);
            //IngredInst1.IngredientType = refillCollide.GetComponent<Refill>().IngredientType;
            //IngredInst1.transform.position = ingredSpawn1.transform.position;


            //IngredInst2 = Instantiate(IngredTempPref);
            //IngredInst2.IngredientType = refillCollide.GetComponent<Refill>().IngredientType;
            //IngredInst2.transform.position = ingredSpawn2.transform.position;

            //IngredInst3 = Instantiate(IngredTempPref);
            //IngredInst3.IngredientType = refillCollide.GetComponent<Refill>().IngredientType;
            //IngredInst3.transform.position = ingredSpawn3.transform.position;

            //kill refill
            toDelete = refillCollide.gameObject;

        }
    }
}
