using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class inverse_kinematics : MonoBehaviour
{
    public int ChainLen = 2;

    public Transform Target;

    // how many solver iterations to run per update
    public int Iterations;

    // distance at which solver stops
    public float SolveDelta = 0.001f;

    // strengh returning to start pos
    [Range(0, 1)]
    public float SnapStrength = 1f;


    protected float CompleteLength;
    protected float[] BonesLength;
    protected Transform[] Bones;
    protected Vector3[] Positions;


    // Gizmos to help visualise how this works
    // Pretty cool solution
    private void OnDrawGizmos()
    {
        var current = this.transform;

        for (int i = 0; i < ChainLen && current != null; i++)
        {
            var scale = Vector3.Distance(current.position, current.parent.position) * 0.1f;
            Handles.matrix = Matrix4x4.TRS(current.position, Quaternion.FromToRotation(Vector3.up, current.parent.position - current.position), new Vector3(scale, Vector3.Distance(current.parent.position, current.position), scale));
            Handles.color = Color.green;
            Handles.DrawWireCube(Vector3.up * 0.5f, Vector3.one);
            current = current.parent;
        }
    }

    void Awake()
    {
        Init();
    }

    void Init()
    {
        // Initial array
        Bones
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
