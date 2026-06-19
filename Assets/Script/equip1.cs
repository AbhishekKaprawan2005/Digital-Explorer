using System.Net;
using UnityEngine;

public class Equip1 : MonoBehaviour
{
    public GameObject pickupButton;
    public GameObject dropButton;
    public GameObject des;
    public GameObject sw;
    public GameObject swm;
    public Transform handpoint;

    public Camera playerCamera;


    private void Start()
    {
        pickupButton.SetActive(false);
        dropButton.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            pickupButton.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("player"))
        {
            pickupButton.SetActive(false);
        }
    }

    public void PickUp1()
    {
        //Rigidbody rb = sw.GetComponent<Rigidbody>();

        //rb.isKinematic = true;
        //rb.useGravity = false;

        sw.SetActive(true);
        swm.SetActive(false);


        pickupButton.SetActive(false);
        dropButton.SetActive(true);
        des.SetActive(true);
    }

    public void Drop1()
    {
        sw.SetActive(false); // hand object hide

        swm.SetActive(true); // world object show

        swm.transform.position =
            playerCamera.transform.position +
            playerCamera.transform.forward * 1.5f;

        Rigidbody rb = swm.GetComponent<Rigidbody>();

        rb.isKinematic = false;
        rb.useGravity = true;

        dropButton.SetActive(false);
        des.SetActive(false);
    }
}