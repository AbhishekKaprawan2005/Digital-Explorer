using UnityEngine;

public class ObjectTracer : MonoBehaviour
{
    public Transform player;
    public GameObject[] targetObjects;

    void Update()
    {
        GameObject nearest = null;
        float minDistance = Mathf.Infinity;

        foreach (GameObject obj in targetObjects)
        {
            if (obj == null || !obj.activeInHierarchy) continue;

            float distance = Vector3.Distance(player.position, obj.transform.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                nearest = obj;
            }
        }

        if (nearest != null)
        {
            transform.LookAt(nearest.transform);
        }
    }
}