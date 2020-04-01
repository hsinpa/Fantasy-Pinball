using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlippersController : MonoBehaviour
{

    public float power;

    private HingeJoint2D _hingeJoint;
    private JointMotor2D jointMotor;

    // Start is called before the first frame update
    void Start()
    {
        _hingeJoint = GetComponent<HingeJoint2D>();
        jointMotor = _hingeJoint.motor;

        //EnableFlipper(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            EnableFlipper(true);
        }
        else if (Input.GetKeyUp(KeyCode.Z))
        {
            EnableFlipper(false);
        }
    }

    void FixedUpdate()
    {
        SetFlipperMotor(jointMotor);
    }

    private void SetFlipperMotor(JointMotor2D jointMotor) {
        _hingeJoint.motor = jointMotor;
    }

    private void EnableFlipper(bool showTime) {
        if (showTime)
        {
            jointMotor.motorSpeed = -power;
        }
        else if (!showTime)
        {
            jointMotor.motorSpeed = power;
        }
    }
}
