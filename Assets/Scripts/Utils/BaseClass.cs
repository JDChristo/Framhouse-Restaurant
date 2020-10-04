using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseClass : MonoBehaviour
{
    [SerializeField] protected GameObject view;
    [SerializeField] protected GameObject controller;
    [SerializeField] protected GameObject model;

    public T SetController<T>() where T : MonoBehaviour
    {
        return controller.GetComponentInChildren<T>();
    }

    public T SetView<T>() where T : MonoBehaviour
    {
        return view.GetComponentInChildren<T>();
    }
    public T SetModel<T>() where T : MonoBehaviour
    {
        return model.GetComponentInChildren<T>();
    }
}
