using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformCopier : MonoBehaviour
{

    public Transform Target;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Target.transform, this.transform.parent.forward);
        this.transform.position = this.transform.parent.position ;
    }
}
