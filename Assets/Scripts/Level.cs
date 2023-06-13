using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private Transform levelStartPointTransform;


    public Vector3 GetLevelStartPoint() => levelStartPointTransform.position;
}
