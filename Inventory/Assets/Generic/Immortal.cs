using UnityEngine;
using System.Collections;

public class Immortal<T> : MonoBehaviour where T : Immortal<T>
{

    private static T m_Instance = null;
    public static T instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = GameObject.FindObjectOfType(typeof(T)) as T;

                if (m_Instance == null)
                {
                    if (canCreate)
                        m_Instance = new GameObject(typeof(T).ToString(), typeof(T)).GetComponent<T>();

                    if (m_Instance == null)
                    {
                        Debug.LogError("Immortal Instance Init ERROR - " + typeof(T).ToString());
                    }
                }
                else
                    m_Instance.Init();
            }
            return m_Instance;
        }
    }

    public int InstanceID;
    public new Transform transform { get; private set; }
    public new GameObject gameObject { get; private set; }
    static bool canCreate = true;

    public virtual void Awake()
    {
        Init();
    }

    protected virtual void Init()
    {
        if (m_Instance == null)
        {
            //base.Awake();
            transform = base.transform;
            gameObject = base.gameObject;
            InstanceID = GetInstanceID();

            //Debug.Log( "Instance Set : " + +GetInstanceID() );
            m_Instance = this as T;
            DontDestroyOnLoad(base.gameObject);
            //m_Instance.Init();
        }
        else
        {
            if (m_Instance != this)
                //Debug.Log( "Instance Already : " + GetInstanceID() );
                DestroyImmediate(base.gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        canCreate = false;
        //m_Instance = null;
    }
}
