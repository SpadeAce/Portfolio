using UnityEngine;
using System.Collections;

public class Immortal<T> : MonoBehaviour where T : Immortal<T>
{
    protected static T m_Instance = null;
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

    public static bool Validate
    {
        get
        {
            return m_Instance != null;
        }
    }

    public int InstanceID;
    static bool canCreate = true;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        if (m_Instance == null)
        {
            InstanceID = GetInstanceID();

            m_Instance = this as T;
            DontDestroyOnLoad(base.gameObject);

            OnInit();
        }
        else
        {
            if (m_Instance != this && gameObject != null)
                DestroyImmediate(gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        canCreate = false;
    }

    protected virtual void OnInit()
    {
    }
}
