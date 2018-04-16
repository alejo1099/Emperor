using UnityEngine;

namespace Emperor
{
    public class Salud : MonoBehaviour
    {
        private const int saludMaxima = 300;
        public int cantidadSalud = saludMaxima;
        public bool destroyOnZero;
        private Vector3 respawnPlayer = new Vector3(30f, 0, -240f);

        /// <summary>
        /// La variable entera debe ir negativa si se quiere rebajar la salud
        /// </summary>
        public void CambiarSalud(int cantidadCambio)
        {
            cantidadSalud += cantidadCambio;
            if (cantidadSalud <= 0)
            {
                if (destroyOnZero)
                {
                    cantidadSalud = saludMaxima;
                    RespawnPersonajes.Singleton.ReactivacionObjeto(gameObject);
                }
                else
                {
                    cantidadSalud = saludMaxima;
                    transform.position = respawnPlayer;
                }
            }
        }
    }
}