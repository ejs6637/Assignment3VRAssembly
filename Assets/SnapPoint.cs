using UnityEngine;

public class SnapPoint : MonoBehaviour
{
    [Header("Name of the object that can snap here")]
    public string partName; // THIS FIELD MUST MATCH the Snappable's partName

    private void OnTriggerEnter(Collider other)
    {
        Snappable snappable = other.GetComponent<Snappable>();
        if (snappable != null && snappable.partName == partName)
        {
            Snap(snappable);
        }
    }

    private void Snap(Snappable snappable)
    {
        // Move and rotate the object to the SnapPoint
        snappable.transform.position = transform.position;
        snappable.transform.rotation = transform.rotation;

        // Make Rigidbody kinematic so it stays in place
        Rigidbody rb = snappable.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        Debug.Log($"{snappable.partName} snapped to {partName}");
    }
}