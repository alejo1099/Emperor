using UnityEngine;

namespace Emperor
{
    public class EleccionAzarSiguienteNivel : MonoBehaviour
    {
        public float rango;
        private bool edificioEncontrado;
        private int num;

        private void Start()
        {
            EleccionAzar();
        }

        private void EleccionAzar()
        {
            while (!edificioEncontrado)
            {
                num++;
                transform.position = new Vector3(Random.Range(-rango, rango), 0, Random.Range(-rango, rango));
                Collider[] casas = Physics.OverlapSphere(transform.position, 10f, Physics.AllLayers, QueryTriggerInteraction.Collide);
                for (int i = 0; i < casas.Length; i++)
                {
                    if (casas[i].GetComponent<IrHabitacion>() != null)
                    {
                        Destroy(casas[i].GetComponent<IrHabitacion>());
                        casas[i].gameObject.AddComponent<SiguienteNivel>();
                        casas[i].gameObject.GetComponent<SiguienteNivel>().nivelSiguiente = 2;
                        return;
                    }
                }
                if (num > 1000)
                {
                    return;
                }
            }
        }
    }
}