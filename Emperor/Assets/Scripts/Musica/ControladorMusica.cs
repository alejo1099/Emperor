using System.Collections;
using UnityEngine;

namespace Emperor
{
    public class ControladorMusica : MonoBehaviour
    {
        public static ControladorMusica Singleton;
        public AudioSource[] reproductores;

        private void Awake()
        {
            AsignacionEventos.ConvertirSingleton(ref Singleton, this);
            DontDestroyOnLoad(gameObject);
        }

        public void ReproducirFlecha()
        {
            for (int i = 0; i < reproductores.Length; i++)
            {
                if (!reproductores[i].isPlaying)
                {
                    reproductores[i].Play();
                }
            }
        }
    }
}
