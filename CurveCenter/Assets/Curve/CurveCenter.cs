using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SAL.Curve
{
    public class CurveCenter : Immortal<CurveCenter>
    {
        private CurveData _data;
        private CurveData data
        {
            get
            {
                if (_data == null)
                    _data = GetComponent<CurveData>();

                return _data;
            }
        }

        Dictionary<string, AnimationCurve> curveDictionary = new Dictionary<string, AnimationCurve>();

        protected override void OnInit()
        {
            curveDictionary.Clear();

            for (int i = 0; i < data.curveList.Count; i++)
            {
                if (!curveDictionary.ContainsKey(data.curveList[i].name))
                    curveDictionary.Add(data.curveList[i].name, data.curveList[i].value);
                else
                    Debug.LogError("CurveCenter : Already in the name");
            }
        }

        public AnimationCurve GetCurve(string name)
        {
            if (curveDictionary.ContainsKey(name))
                return curveDictionary[name];
            else
                Debug.LogWarning("CurveCenter : Not Found Curve Name (" + name + ")");
            return null;
        }
    }
}