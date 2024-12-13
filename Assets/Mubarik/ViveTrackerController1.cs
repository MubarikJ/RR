using UnityEngine;

public class ViveTrackerController1 : MonoBehaviour
{
    public Transform rightArmTracker;  // Tracker for the right arm
    public Transform leftArmTracker;   // Tracker for the left arm
    

    public Transform characterRightArm; // Character's right arm bone
    public Transform characterLeftArm;  // Character's left arm bone
    

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Directly map tracker data to character bones for precise control
        MapTrackerToBone(rightArmTracker, characterRightArm);
        MapTrackerToBone(leftArmTracker, characterLeftArm);
        
    }

    private void MapTrackerToBone(Transform tracker, Transform bone)
    {
        if (tracker != null && bone != null)
        {
            bone.position = tracker.position;
            bone.rotation = tracker.rotation;
        }
    }

    void OnAnimatorIK(int layerIndex)
    {
        // Optional: Use IK for smoother blending (if desired)
        if (animator != null)
        {
            float rightHandIKWeight = 1.0f; // Set full influence for IK
            float leftHandIKWeight = 1.0f;

            // Right Hand IK
            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, rightHandIKWeight);
            animator.SetIKPosition(AvatarIKGoal.RightHand, rightArmTracker.position);
            animator.SetIKRotationWeight(AvatarIKGoal.RightHand, rightHandIKWeight);
            animator.SetIKRotation(AvatarIKGoal.RightHand, rightArmTracker.rotation);

            // Left Hand IK
            animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, leftHandIKWeight);
            animator.SetIKPosition(AvatarIKGoal.LeftHand, leftArmTracker.position);
            animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, leftHandIKWeight);
            animator.SetIKRotation(AvatarIKGoal.LeftHand, leftArmTracker.rotation);
        }
    }
}
