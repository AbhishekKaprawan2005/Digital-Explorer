using System.Net;
using UnityEngine;

public class Equip2 : MonoBehaviour
{
    public GameObject pickupButton;
    public GameObject dropButton;
    public GameObject des;
    public GameObject sw1;
    public GameObject swm1;
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

        sw1.SetActive(true);
        swm1.SetActive(false);


        pickupButton.SetActive(false);
        dropButton.SetActive(true);
        des.SetActive(true);
    }

    public void Drop()
    {
        sw1.SetActive(false); // hand object hide

        swm1.SetActive(true); // world object show

        swm1.transform.position =
            playerCamera.transform.position +
            playerCamera.transform.forward * 1.5f;

        Rigidbody rb = swm1.GetComponent<Rigidbody>();

        rb.isKinematic = false;
        rb.useGravity = true;

        dropButton.SetActive(false);
        des.SetActive(false);
    }
}