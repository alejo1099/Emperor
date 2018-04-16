using UnityEngine;

namespace Emperor
{
    public class IrHabitacion : MonoBehaviour
    {
        public Transform posHabitacion;
        public Transform posRespawn;

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.CompareTag("Player"))
            {
                other.transform.position = posHabitacion.position;
                VolverCiudad.Singleton.posVolver = posRespawn;
            }
        }
    }
}