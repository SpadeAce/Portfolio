using UnityEngine;
using System.Collections;
using SAL.Curve;

public class Demo : MonoBehaviour {

    public Transform From;
    public Transform To;

    public GameObject Cube;

    public string CurveName;

    public float Speed = 1.0f;

    private AnimationCurve curve;
    private bool playCurve = false;
    private float time = 0.0f;
    
    void Update()
    {
        if (!playCurve || curve == null) return;

        time += Time.deltaTime * Speed;

        Cube.transform.position = From.position + ((To.position - From.position) * curve.Evaluate(time));

        if (time >= 1.0f)
        {
            playCurve = false;
            return;
        }
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 200, 100), "Start"))
        {
            curve = CurveCenter.instance.GetCurve(CurveName);
            Play();
        }
    }


    void Play()
    {
        playCurve = true;
        time = 0.0f;
    }
}
