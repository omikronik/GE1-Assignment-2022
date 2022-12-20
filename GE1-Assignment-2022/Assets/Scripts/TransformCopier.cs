using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformCopier : MonoBehaviour
{

    public Transform Target;

    // Start is called before the first frame update
    void Start()
    {
        transform.SetParent(Target, false);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation = Target.rotation;
        transform.LookAt(Target);

        //transform.position = Target.position;
        //transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
        //transform.localposition;
        //this.transform.position = target.transform.position;
        //this.transform.position = this.transform.parent.position ;
        //this.transform.rotation = this.transform.parent.rotation;
        //this.transform.eulerAngles= new Vector3(this.transform.parent.rotation.eulerAngles.x, this.transform.parent.eulerAngles.y + 90, this.transform.parent.eulerAngles.z);
        //this.transform.LookAt(this.transform.parent.position);
        //this.transform.eulerAngles = new Vector3(target.transform.eulerAngles.x, target.transform.eulerAngles.x, target.transform.eulerAngles.z);
        //this.transform.eulerAngles = new Vector3(target.transform.eulerAngles.x, target.transform.eulerAngles.x, target.transform.eulerAngles.z);
    }
}
