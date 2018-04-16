using System.Collections;
using UnityEngine;

namespace Emperor
{
    public class Flecha : MonoBehaviour
    {
        private bool dañoRecibido;

        private void OnCollisionEnter(Collision other)
        {
            if (!dañoRecibido)
            {
                var hit = other.gameObject;
                var salud = hit.GetComponent<Salud>();
                if (salud != null)
                {
                    salud.CambiarSalud(-10);
                    dañoRecibido = true;
                }
            }
        }

        private void OnDisable()
        {
            dañoRecibido = false;
        }
    }
}