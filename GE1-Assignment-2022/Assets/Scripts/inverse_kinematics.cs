/*
 * 
 * HEADS UP
 * 
 * I FOLLOWED THIS YOUTUBE TUTORIAL ON HOW TO IMPLEMENT IK FOR MY USE CASE
 * 
 * this is an algorithm that would take a bonkers amount of self studying to
 * come up with my own implementation. I learned a lot from this explanation.
 * https://www.youtube.com/watch?v=qqOAzn05fvk
 * 
 * I could have just used the unity built in animation rigging IK solution but
 * that didnt feel like I was learning anything or doing any code.
 */


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
        Bones = new Transform[ChainLen + 1];
        Positions = new Vector3[ChainLen + 1];
        BonesLength = new float[ChainLen];
        CompleteLength = 0f;

        var current = transform;
        for (var i = Bones.Length - 1; i >= 0; i--)
        {
            Bones[i] = current;

            // Differentiate between leaf bone or mid bone
            // last bone will hit this it has no length
            if (i == Bones.Length - 1)
            {
            }
            else
            {
                BonesLength[i] = (Bones[i + 1].position - current.position).magnitude;
                CompleteLength += BonesLength[i];
            }

            current = current.parent;
        }
    }

    // This function is called every frame
    void LateUpdate()
    {
        ResolveIK();       
    }

    private void ResolveIK()
    {
        // Invalid state checks
        if (Target == null)
        { 
            return;
        }

        if (Bones.Length != ChainLen)
        {
            Init();
        }

        // Get position
        // Fabrik AK algorithm requires getting every position,
        // doing calculations, and then updating the nodes.
        // so no references and no computation on bones directly
        for (int i = 0; i < Bones.Length; i++)
        {
            Positions[i] = Bones[i].position;
        }


        // Actual calculations
        // Check if position 0 is reachable
        if ((Target.position - Bones[0].position).sqrMagnitude >= CompleteLength * CompleteLength)
        {
            // Stretch
            var direction = (Target.position - Positions[0]).normalized;

            // Set everything starting from after root node
            // new pos = pos of predecessor + direction multiplied by predecessor length
            for (int i = 1; i < Positions.Length; i++)
            {
                Positions[i] = Positions[i - 1] + direction * BonesLength[i - 1];
            }

        }
        else
        {
            for (int iteration = 0; iteration < Iterations; iteration++)
            {
                // Work backwards
                for (int i = Positions.Length - 1; i > 0; i--)
                {
                    if (i == Positions.Length - 1)
                    {
                        Positions[i] = Target.position;
                    }
                    else
                    {
                        Positions[i] = Positions[i + 1] + (Positions[i] - Positions[i + 1]).normalized * BonesLength[i];
                    }
                }


                // Work forwards
                for (int i = 0; i < Positions.Length; i++)
                {
                    Positions[i] = Positions[i - 1] + (Positions[i] - Positions[i - 1]).normalized * BonesLength[i - 1];
                }

                // Stops when it is close enough
                if ((Positions[Positions.Length - 1] - Target.position).sqrMagnitude < SolveDelta * SolveDelta)
                {
                    break;
                }
            }
        }


        // set positions onto bones
        // doing inverse of starting loop
        for (int i = 0;i < Positions.Length; i++)
        {
            Bones[i].position = Positions[i];
        }

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
