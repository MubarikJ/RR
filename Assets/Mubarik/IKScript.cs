using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKScript : MonoBehaviour
{
    public Transform RightHandTracker;
    public Transform LeftHandTracker;
    public Transform ChestTracker;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnAnimatorIK(int layerIndex)
    {
        // Right Hand IK
        float rightHandReach = animator.GetFloat("RightArm");
        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, rightHandReach);
        animator.SetIKPosition(AvatarIKGoal.RightHand, RightHandTracker.position);

        // Left Hand IK
        float leftHandReach = animator.GetFloat("LeftArm");
        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, leftHandReach);
        animator.SetIKPosition(AvatarIKGoal.LeftHand, LeftHandTracker.position);

        // Chest Tracker - Directly updating chest bone position/rotation
        if (ChestTracker != null)
        {
            Transform chestBone = animator.GetBoneTransform(HumanBodyBones.Chest);
            if (chestBone != null)
            {
                chestBone.position = ChestTracker.position;
                chestBone.rotation = ChestTracker.rotation;
            }
        }
    }
}
