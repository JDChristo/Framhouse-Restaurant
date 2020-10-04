using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static bool m_destoryed = false;
    private static object m_lock = new object();
    private static T m_instance;
 
    public static T Instance
    {
        get
        {
            if (m_destoryed)
            {
                Debug.LogWarning("[Singleton] Instance '" + typeof(T) +
                    "' already destroyed. Returning null.");
                return null;
            }
 
            lock (m_lock)
            {
                if (m_instance == null)
                {
                    m_instance = (T)FindObjectOfType(typeof(T));
 
                    if (m_instance == null)
                    {
                        var singletonObj = new GameObject();
                        m_instance = singletonObj.AddComponent<T>();
                    }
                }
 
                return m_instance;
            }
        }
    }
    private void OnDestroy()
    {
        m_destoryed = true;
    }
}
