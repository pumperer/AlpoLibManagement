using UnityEngine;

public abstract class PointBase : MonoBehaviour
{
    [SerializeField] private string pointName;
    [SerializeField] private Transform targetPoint;
    
    public string PointName => pointName;
    public Transform TargetPoint => targetPoint;
    public bool Occupied { get; set; } = false;
}
