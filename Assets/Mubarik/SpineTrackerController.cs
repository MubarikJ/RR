using UnityEngine;

public class SpineTrackerController : MonoBehaviour
{
    public Transform chestTracker; // Tracker for the chest

    // Assign the spine bones in the hierarchy
    public Transform spine;
    public Transform spine1;
    public Transform spine2;
    public Transform chest;

    void Update()
    {
        // Check if the chest tracker and bones are assigned
        if (chestTracker != null && spine != null && chest != null)
        {
            // Map the tracker position to the top spine/chest, propagating influence
            PropagateChestMovement();
        }
        else
        {
            Debug.LogWarning("Chest tracker or spine bones not assigned!");
        }
    }

    private void PropagateChestMovement()
    {
        // Calculate the position/rotation adjustments
        Vector3 chestPosition = chestTracker.position;
        Quaternion chestRotation = chestTracker.rotation;

        // Smoothly blend positions/rotations through the spine chain
        if (spine != null)
        {
            spine.position = Vector3.Lerp(spine.position, chestPosition, 0.33f);
            spine.rotation = Quaternion.Slerp(spine.rotation, chestRotation, 0.33f);
        }

        if (spine1 != null)
        {
            spine1.position = Vector3.Lerp(spine1.position, chestPosition, 0.66f);
            spine1.rotation = Quaternion.Slerp(spine1.rotation, chestRotation, 0.66f);
        }

        if (spine2 != null)
        {
            spine2.position = Vector3.Lerp(spine2.position, chestPosition, 0.9f);
            spine2.rotation = Quaternion.Slerp(spine2.rotation, chestRotation, 0.9f);
        }

        if (chest != null)
        {
            chest.position = chestPosition;
            chest.rotation = chestRotation;
        }
    }
}
