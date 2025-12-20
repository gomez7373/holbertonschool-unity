using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Teleports the Player to a paired destination teleporter.
/// Uses an internal cooldown map so the Player does not need a separate script.
/// </summary>
public class Teleporter : MonoBehaviour
{
    [Header("Link")]
    public Teleporter destination;

    [Header("Landing (optional)")]
    public Transform destinationPoint;

    [Header("Rules")]
    public float cooldownSeconds = 0.75f;

    // Cooldown per Player instance (no extra Player script needed)
    private static readonly Dictionary<int, float> nextAllowedByPlayerId = new Dictionary<int, float>();

    private void Reset()
    {
        // Ensure trigger is set when component is added
        Collider c = GetComponent<Collider>();
        if (c != null) c.isTrigger = true;

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug (optional): uncomment to verify trigger fires
        // Debug.Log("Teleporter trigger by: " + other.name);

        if (!other.CompareTag("Player"))
            return;

        if (destination == null)
            return;

        int id = other.gameObject.GetInstanceID();

        if (nextAllowedByPlayerId.TryGetValue(id, out float t) && Time.time < t)
            return;

        nextAllowedByPlayerId[id] = Time.time + cooldownSeconds;

        Vector3 targetPos = (destinationPoint != null)
            ? destinationPoint.position
            : destination.transform.position;

        CharacterController cc = other.GetComponent<CharacterController>();
        if (cc != null)
        {
            cc.enabled = false;
            other.transform.position = targetPos;
            cc.enabled = true;
        }
        else
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.position = targetPos;
                rb.velocity = Vector3.zero;
            }
            else
            {
                other.transform.position = targetPos;
            }
        }
    }
}

