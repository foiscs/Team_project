using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelAlignment : MonoBehaviour
{
    public WheelCollider CorrespondingCollider;
    public GameObject SlipPrefab;

    public float RotationValue = 0.0f;

    private void Update()
    {
        var hit = new RaycastHit();
        Vector3 ColliderCenterPoint = CorrespondingCollider.transform.TransformPoint(CorrespondingCollider.center);

        // if(Physics.Raycast(ColliderCenterPoint,-CorrespondingCollider.transform.up,hit,CorrespondingCollider.suspensionDistance+CorrespondingCollider.radius))
        {

        }
    }
}
