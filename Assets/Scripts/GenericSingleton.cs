using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericSingleton<T> : MonoBehaviour where T : GenericSingleton<T>
{

    private static T instance;
    public static T Instance{get{return instance;}}

    void Awake()
    {
        if(instance == null)
        {
            instance = (T)this;
        }
        else{
            Destroy(this.gameObject);
            Debug.Log("Singleton try to create "+(T)this+" second Instance");
        }
    }



}
