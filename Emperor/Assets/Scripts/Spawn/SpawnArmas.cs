using UnityEngine;
using Spawner;

namespace Emperor
{
    public class SpawnArmas : Spawn
    {
        public static SpawnArmas Singleton;
        public GameObject prefabFlecha;
        private GameObject[] flechas;

        private Transform miTransform;

        private void Awake()
        {
            AsignacionEventos.ConvertirSingleton(ref Singleton, this);
            miTransform = transform;
            cantidadInstanciar = 50;
            InstanciarArmas();
        }

        private void InstanciarArmas()
        {
            InstanciarObjeto(ref flechas, prefabFlecha, miTransform);
        }

        public void SpawnFlecha(Transform posicionPooling, ref Transform referenciaFlecha)
        {
            PoolingObjeto(posicionPooling, ref referenciaFlecha, flechas);
        }
    }
}