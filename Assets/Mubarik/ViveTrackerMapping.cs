using UnityEngine;

public class ViveTrackerMapping : MonoBehaviour
{
    public Transform rightArmTracker; // Tracker for the right arm
    public Transform leftArmTracker;  // Tracker for the left arm
    public Transform chestTracker;    // Tracker for the chest

    public Transform characterRightArm;  // Character's right arm bone
    public Transform characterLeftArm;   // Character's left arm bone
    public Transform characterSpine;     // Character's spine bone (parent of chest)

    void Update()
    {
        // Map right arm tracker
        if (rightArmTracker != null && characterRightArm != null)
        {
            characterRightArm.position = rightArmTracker.position;
            characterRightArm.rotation = rightArmTracker.rotation;
        }

        // Map left arm tracker
        if (leftArmTracker != null && characterLeftArm != null)
        {
            characterLeftArm.position = leftArmTracker.position;
            characterLeftArm.rotation = leftArmTracker.rotation;
        }

        // Map chest tracker (move spine instead of chest directly)
        if (chestTracker != null && characterSpine != null)
        {
            // Smoothly move the spine toward the tracker (optional)
            characterSpine.position = Vector3.Lerp(characterSpine.position, chestTracker.position, 0.5f);
            characterSpine.rotation = Quaternion.Lerp(characterSpine.rotation, chestTracker.rotation, 0.5f);
        }
    }
}
