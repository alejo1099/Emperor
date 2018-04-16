using System;
using UnityEngine;

public static class AsignacionEventos
{
    ///<Summary>
    ///Metodo para convertir en singleton, con claseSingleton como la variable de referencia,
    ///clase referencia como la que se le va asignar a claseSingleton
    ///</Summary>
    public static void ConvertirSingleton<T>(ref T claseSingleton, T claseReferencia)
    {
        MonoBehaviour mono = claseReferencia as MonoBehaviour;
        if (claseSingleton == null)
            claseSingleton = claseReferencia;
        else
            UnityEngine.Object.Destroy(mono.gameObject);
    }

    private static bool VerificarMetodo(Action metodo, Action actionDelegado)
    {
        Delegate[] arrayMetodos = actionDelegado != null ? actionDelegado.GetInvocationList() : new Delegate[0];
        for (int i = 0; i < arrayMetodos.Length; i++)
        {
            if (arrayMetodos[i].Target == metodo.Target && arrayMetodos[i].GetHashCode() == metodo.GetHashCode())
                return false;
        }
        return true;
    }

    private static void RemoverMetodo(Action metodo, Action actionDelegado)
    {
        actionDelegado -= metodo;
    }

    ///<Summary>
    ///Metodo para verificar si un metodo ya ha sido agregado a un delegate, Action, etc
    ///y removerlo de este
    ///</Summary>
    public static void VerificarRemover(Action metodo, Action actionDelegado)
    {
        if (!VerificarMetodo(metodo, actionDelegado))
            RemoverMetodo(metodo, actionDelegado);
    }
}