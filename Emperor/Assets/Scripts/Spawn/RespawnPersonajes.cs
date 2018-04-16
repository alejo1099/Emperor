using System.Collections;
using UnityEngine;

namespace Emperor
{
    public class RespawnPersonajes : MonoBehaviour
    {
        public static RespawnPersonajes Singleton;
        public WaitForSeconds waitForSeconds = new WaitForSeconds(60f);

        private void Awake()
        {
            AsignacionEventos.ConvertirSingleton(ref Singleton, this);
        }

        public void ReactivacionObjeto(GameObject objetoReactivar)
        {
            StartCoroutine(ReactivarObjeto(objetoReactivar));
        }

        private IEnumerator ReactivarObjeto(GameObject objetoReactivar)
        {
            objetoReactivar.SetActive(false);
            yield return waitForSeconds;
            objetoReactivar.SetActive(true);
        }
    }
}