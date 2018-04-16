using UnityEngine;

namespace Emperor
{
    public class VolverCiudad : MonoBehaviour
    {
        public static VolverCiudad Singleton;
        public Transform posVolver;

        private void Awake()
        {
            AsignacionEventos.ConvertirSingleton(ref Singleton, this);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.CompareTag("Player"))
                if (posVolver != null)
                    other.transform.position = posVolver.position;
        }
    }
}