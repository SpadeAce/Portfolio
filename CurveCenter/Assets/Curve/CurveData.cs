using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SAL.Curve
{
    public class CurveData : MonoBehaviour
    {
        public List<CurveObject> curveList;
    }

    [System.Serializable]
    public class CurveObject
    {
        public string name;
        public AnimationCurve value;
    }
}