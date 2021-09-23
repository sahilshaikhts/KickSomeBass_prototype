using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyInterfaces
{
    public interface IControllable
    {
        void Initialize();
        void Deactivate();

        void Move(Vector3 aDirection);
        void SetRotation(Quaternion aRoatation);

        BaseCamera GetObjectCamera();
    }
}