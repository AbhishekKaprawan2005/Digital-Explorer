using System.Net;
using UnityEngine;

public class Equip : MonoBehaviour
{
    public GameObject pickupButton;
    public GameObject dropButton;
    public GameObject des;
    public GameObject cr;
    public GameObject crm;
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

    public void PickUp()
    {
        Rigidbody rb = cr.GetComponent<Rigidbody>();

        rb.isKinematic = true;
        rb.useGravity = false;

        cr.SetActive(true);
        crm.SetActive(false);


        pickupButton.SetActive(false);
        dropButton.SetActive(true);
        des.SetActive(true);
    }

    public void Drop()
    {
        Rigidbody rb = cr.GetComponent<Rigidbody>();

        cr.transform.SetParent(null);

        cr.transform.position =
            playerCamera.transform.position +
            playerCamera.transform.forward * 1.5f;

        rb.isKinematic = false;
        rb.useGravity = true;
        cr.SetActive(true);
        dropButton.SetActive(false);
        des.SetActive(false);
        crm.SetActive(false);
    }
}