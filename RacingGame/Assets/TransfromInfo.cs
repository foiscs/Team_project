using UnityEngine;

[SerializeField]
public class TransfromInfo
{
    public Vector3 Position;
    public Quaternion Rotation;
    public TransfromInfo(Transform target)
    {
        Position = target.position;
        Rotation = target.rotation;
    }
}
