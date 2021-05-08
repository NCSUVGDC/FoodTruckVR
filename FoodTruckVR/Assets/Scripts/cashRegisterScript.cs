using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cashRegisterScript : MonoBehaviour
{
    public float currentRegisterValue = 0;
    public GameObject textMeshObject;
    private GameObject toDelete;

    // Start is called before the first frame update
    void Start()
    {
        //append the value to the text mesh and force 2 decimal places
        textMeshObject.GetComponent<TextMesh>().text = "$" + currentRegisterValue.ToString("F2");
    }

    void LateUpdate()
    {
        if (toDelete != null)
        {
            toDelete.transform.position = new Vector3(0f, -20000f, 0f); //teleport the object very far away to trigger Exit collision and trigger script functions
            Destroy(toDelete, 0.1f); //slight delay for time to trigger the function
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cash")) // && other.gameObject.GetComponent<OVRGrabbable>().isGrabbed) //tags are case sensetive and do nothing unless it's being grabbed.
        {
            currentRegisterValue += other.gameObject.GetComponent<cashValueScript>().cashValue; //add cash value of cash to register value

            updateRegisterText("$" + currentRegisterValue.ToString("F2")); //new register text

            toDelete = other.gameObject; //now delete the cash
        }
    }

    public void updateRegisterText(string newText)
    {
        textMeshObject.GetComponent<TextMesh>().text = newText;
    }

    // Update is called once per frame
    void Update()
    {
        //No need to spam this if we only update the text when cash touches the register
        //textMesh_obj.GetComponent<TextMesh>().text = "$" + currentRegisterValue.ToString("F2");
    }
}
