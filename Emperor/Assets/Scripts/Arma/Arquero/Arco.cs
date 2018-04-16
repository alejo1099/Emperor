using UnityEngine;

namespace Emperor
{
    public class Arco : MonoBehaviour
    {
        private Transform posicionFlecha;
        private Transform flecha;

        private Transform target;

        private void Awake()
        {
            posicionFlecha = transform.GetChild(0);
        }

        private void Start()
        {
            target = new GameObject("Target").transform;
            target.SetParent(SpawnArmas.Singleton.transform);
        }

        public void Atacar(Vector3 posicionObjetivo)
        {
            target.position = posicionObjetivo;
            SpawnArmas.Singleton.SpawnFlecha(posicionFlecha, ref flecha);
            flecha.GetComponent<EffectSettings>().Target = target.gameObject;
        }
    }
}