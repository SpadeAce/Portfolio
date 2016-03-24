using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using SAL.Curve;

[CustomEditor(typeof(CurveData))]
public class CurveDataEditor : Editor
{
    private CurveData data;
    private string curveName;

    void OnEnable()
    {
        data = target as CurveData;

        if (data.curveList == null)
            data.curveList = new List<CurveObject>();
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.BeginHorizontal();

        curveName = EditorGUILayout.TextField("Curve Name", curveName);

        if (GUILayout.Button("Add Curve"))
        {
            CurveObject curve = new CurveObject();
            curve.name = curveName;
            curve.value = new AnimationCurve(new Keyframe(0f, 0f, 0f, 1f), new Keyframe(1f, 1f, 1f, 0f));
            data.curveList.Add(curve);
        }
        EditorGUILayout.EndHorizontal();

        for (int i = 0; i < data.curveList.Count; i++)
        {
            if (DrawHeader(data.curveList[i].name, data.curveList[i].name,false,false))
            {
                BeginContents(false);

                EditorGUIUtility.labelWidth = 110f;

                data.curveList[i].value = EditorGUILayout.CurveField("Animation Curve", data.curveList[i].value, GUILayout.Width(170f), GUILayout.Height(62f));

                GUILayout.BeginHorizontal();

                if (GUILayout.Button("Remove", GUILayout.Width(100f), GUILayout.Height(32f)))
                {
                    data.curveList.RemoveAt(i);
                }

                EditorGUILayout.EndHorizontal();

                EndContents();
            }
        }
    }

    #region curve frame

    static bool mEndHorizontal = false;

    static public bool DrawHeader(string text, string key, bool forceOn, bool minimalistic)
    {
        bool state = EditorPrefs.GetBool(key, true);

        if (!minimalistic) GUILayout.Space(3f);
        if (!forceOn && !state) GUI.backgroundColor = new Color(0.8f, 0.8f, 0.8f);
        GUILayout.BeginHorizontal();
        GUI.changed = false;

        if (minimalistic)
        {
            if (state) text = "\u25BC" + (char)0x200a + text;
            else text = "\u25BA" + (char)0x200a + text;

            GUILayout.BeginHorizontal();
            GUI.contentColor = EditorGUIUtility.isProSkin ? new Color(1f, 1f, 1f, 0.7f) : new Color(0f, 0f, 0f, 0.7f);
            if (!GUILayout.Toggle(true, text, "PreToolbar2", GUILayout.MinWidth(20f))) state = !state;
            GUI.contentColor = Color.white;
            GUILayout.EndHorizontal();
        }
        else
        {
            text = "<b><size=11>" + text + "</size></b>";
            if (state) text = "\u25BC " + text;
            else text = "\u25BA " + text;
            if (!GUILayout.Toggle(true, text, "dragtab", GUILayout.MinWidth(20f))) state = !state;
        }

        if (GUI.changed) EditorPrefs.SetBool(key, state);

        if (!minimalistic) GUILayout.Space(2f);
        GUILayout.EndHorizontal();
        GUI.backgroundColor = Color.white;
        if (!forceOn && !state) GUILayout.Space(3f);
        return state;
    }

    static public void BeginContents(bool minimalistic)
    {
        if (!minimalistic)
        {
            mEndHorizontal = true;
            GUILayout.BeginHorizontal();
            EditorGUILayout.BeginHorizontal("AS TextArea", GUILayout.MinHeight(10f));
        }
        else
        {
            mEndHorizontal = false;
            EditorGUILayout.BeginHorizontal(GUILayout.MinHeight(10f));
            GUILayout.Space(10f);
        }
        GUILayout.BeginVertical();
        GUILayout.Space(2f);
    }

    static public void EndContents()
    {
        GUILayout.Space(3f);
        GUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();

        if (mEndHorizontal)
        {
            GUILayout.Space(3f);
            GUILayout.EndHorizontal();
        }

        GUILayout.Space(3f);
    }

    #endregion
}
