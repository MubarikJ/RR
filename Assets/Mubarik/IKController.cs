using UnityEngine;

public class IKController : MonoBehaviour
{
    private Animator animator;

    [Header("IK Targets")]
    public Transform rightHandTarget; // Assign your Right Arm Tracker
    public Transform leftHandTarget;  // Assign your Left Arm Tracker

    [Header("IK Weights")]
    public float rightHandWeight = 1.0f; // Full influence
    public float leftHandWeight = 1.0f;  // Full influence

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnAnimatorIK(int layerIndex)
    {
        if (animator)
        {
            // Right hand IK
            if (rightHandTarget)
            {
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, rightHandWeight);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, rightHandWeight);
                animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandTarget.position);
                animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandTarget.rotation);
            }

            // Left hand IK
            if (leftHandTarget)
            {
                animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, leftHandWeight);
                animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, leftHandWeight);
                animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandTarget.position);
                animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandTarget.rotation);
            }
        }
    }
}
