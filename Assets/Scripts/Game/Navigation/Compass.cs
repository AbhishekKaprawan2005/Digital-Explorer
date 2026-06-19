using UnityEngine;

public class Compass : MonoBehaviour
{
    public Transform player;
    public RectTransform compassNeedle;

    void Update()
    {
        Vector3 north = Vector3.up;

        Vector3 forwardProjected =
            Vector3.ProjectOnPlane(player.forward, player.position.normalized).normalized;

        Vector3 northProjected =
            Vector3.ProjectOnPlane(north, player.position.normalized).normalized;

        float angle = Vector3.SignedAngle(
            forwardProjected,
            northProjected,
            player.position.normalized);

        compassNeedle.localEulerAngles = new Vector3(0, 0, angle);
    }
}