using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public OrderBox currentOrder;
    private bool OrderCorrect = false;

    public GameObject cashSpawner1;
    public GameObject cashSpawner2;

    //The following was added by Drumstick to have a new car color for each order
    System.Random sysRNG = new System.Random();

    public MeshRenderer meshrender;

    public Material[] paintMats = new Material[10];

    private bool payForTaco = false;
    private bool payForChips = false;

    public void newCustomerPaint()
    {
        Material[] carMaterials = meshrender.materials;

        carMaterials[1] = paintMats[sysRNG.Next(0, paintMats.Length)];
        meshrender.materials = carMaterials;
    }
    //


    void OnTriggerEnter(Collider orderCollide)
    {

        if (orderCollide.gameObject.CompareTag("Taco"))
        {
            Debug.Log("taco collide");
            List<IngredientType> tacoOrder_given = orderCollide.gameObject.GetComponent<FoodContainer>().Ingredients;
            //Debug.Log(tacoOrder[3].IngredientType);

            ////add 4 nones so the list is at least 4 long
            //tacoOrder.Add(IngredientType.None);
            //tacoOrder.Add(IngredientType.None);
            //tacoOrder.Add(IngredientType.None);
            //tacoOrder.Add(IngredientType.None);

            //add nones so the list is at least 4 long
            while (tacoOrder_given.Count < 4) tacoOrder_given.Add(IngredientType.None);

            List<IngredientType> tacoOrder_customer = new List<IngredientType>(new IngredientType[]
                { currentOrder.tacoSlot1, currentOrder.tacoSlot2, currentOrder.tacoSlot3, currentOrder.tacoSlot4 }); //create list from customer taco slots

            tacoOrder_customer.Sort();
            tacoOrder_given.Sort();

            Debug.Log("customer: " + tacoOrder_customer[0] + ", " + tacoOrder_customer[1] + ", " + tacoOrder_customer[2] + ", " + tacoOrder_customer[3]);
            Debug.Log("given: " + tacoOrder_given[0] + ", " + tacoOrder_given[1] + ", " + tacoOrder_given[2] + ", " + tacoOrder_given[3]);

            //bool[] tacoOrderChecklist = new bool[] { true, true, true, true };

            OrderCorrect = true;
            if (!currentOrder.tacoOrder)
            {
                OrderCorrect = false;
            }

            for (int i = 0; i == 3; i++) //test 4 times for each of the potential slots
            {
                if (tacoOrder_given[i] != tacoOrder_customer[i])
                OrderCorrect = false;
            }

            //for (int i = 0; i == 3; i++) //test 4 times for each of the potential slots
            //{
            //    foreach (IngredientType item in tacoOrder_given) //go through the given taco order one ingredient at a time
            //    {
            //        if (item == tacoOrder_customer[0])
            //        {
            //            Debug.Log(item + " correct, removing...");
            //            tacoOrder_customer.RemoveAt(0); //remove the correct slot so it doesn't get double counted
            //        }
            //    }
            //}
            //if (tacoOrder_customer.Count > 0) //if the order was not correct, then the list will have the incorrect ingredients remaining
            //{
            //    OrderCorrect = false;
            //}

            //if (currentOrder.tacoTopingTotal >= 1)
            //{
            //    if (tacoOrder_given[0] != currentOrder.tacoSlot1)
            //        OrderCorrect = false;
            //}
            //if (currentOrder.tacoTopingTotal >= 2)
            //{
            //    if (tacoOrder_given[1] != currentOrder.tacoSlot2)
            //        OrderCorrect = false;
            //}
            //if (currentOrder.tacoTopingTotal >= 3)
            //{
            //    if (tacoOrder_given[2] != currentOrder.tacoSlot3)
            //        OrderCorrect = false;
            //}
            //if (currentOrder.tacoTopingTotal >= 4)
            //{
            //    if (tacoOrder_given[3] != currentOrder.tacoSlot4)
            //        OrderCorrect = false;
            //}

            if (OrderCorrect)
            {
                Debug.Log("taco order correct!");
                currentOrder.tacoOrder = false;
                currentOrder.tacoSlot1 = IngredientType.None;
                currentOrder.tacoSlot2 = IngredientType.None;
                currentOrder.tacoSlot3 = IngredientType.None;
                currentOrder.tacoSlot4 = IngredientType.None;

                currentOrder.resetTacoMats();

                currentOrder.resetPatience();

                payForTaco = true;
            }
            else
            {
                Debug.Log("taco W R O N G");
            }


        }



        if (orderCollide.gameObject.CompareTag("ChipBowl"))
        {
            Debug.Log("chip collide");
            List<IngredientType> chipOrder_given = orderCollide.gameObject.GetComponent<FoodContainer>().Ingredients;
            //Debug.Log(chipOrder[3].IngredientType);

            ////add 2 nones so the list is at least 2 long
            //chipOrder_given.Add(IngredientType.None);
            //chipOrder_given.Add(IngredientType.None);

            //add nones so the list is at least 2 long
            while (chipOrder_given.Count < 2) chipOrder_given.Add(IngredientType.None);

            List<IngredientType> chipOrder_customer = new List<IngredientType>(new IngredientType[]
                { currentOrder.chipSlot1, currentOrder.chipSlot2}); //create list from customer taco slots

            chipOrder_customer.Sort();
            chipOrder_given.Sort();

            OrderCorrect = true;
            if (!currentOrder.chipOrder)
            {
                OrderCorrect = false;
            }
            for (int i = 0; i == 1; i++) //test 2 times for each of the potential slots
            {
                if (chipOrder_given[i] != chipOrder_customer[i])
                    OrderCorrect = false;
            }

            //if (currentOrder.chipsTotal >= 1)
            //{
            //    if (chipOrder_given[0] != currentOrder.chipSlot1)
            //        OrderCorrect = false;
            //}
            //if (currentOrder.chipsTotal >= 2)
            //{
            //    if (chipOrder_given[1] != currentOrder.chipSlot2)
            //        OrderCorrect = false;
            //}

            //if (currentOrder.chipSlot == "None")
            //{
            //    if (chipOrder[1] != IngredientType.Chip)
            //        OrderCorrect = false;
            //}
            //if (currentOrder.chipSlot == "Queso")
            //{
            //    if (chipOrder[1] != IngredientType.Queso)
            //        OrderCorrect = false;
            //}

            if (OrderCorrect)
            {
                Debug.Log("chip correct!");
                currentOrder.chipOrder = false;

                currentOrder.chipSlot1 = IngredientType.None;
                currentOrder.chipSlot2 = IngredientType.None;

                currentOrder.chipSlot = "None";

                currentOrder.resetChipMats();

                currentOrder.resetPatience();

                payForChips = true;
            }
            else
            {
                Debug.Log("chip W R O N G");
            }


        }
        

        /*CHECK FOR COMPLETE ORDER*/
        if (!currentOrder.tacoOrder && !currentOrder.chipOrder)
        {
            currentOrder.NewOrder();

            //only pay after both items are completed
            if (payForTaco)
            {
                cashSpawner1.GetComponent<itemSpawner>().spawnItem(); //force spawn a cash valued $5
            }

            if (payForChips)
            {
                cashSpawner2.GetComponent<itemSpawner>().spawnItem(); //force spawn a cash valued $2
            }

            //reset these variables
            payForTaco = false;
            payForChips = false;
        }
    }
}
