using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Emperor
{
    public class Enemigo : Salud
    {
        private ControladorAnimatorEnemigos controladorAnimaciones;

        public Transform posicionFlecha;
        private Transform flecha;

        private Transform player;
        private Transform target;

        private WaitForSeconds waitArrow = new WaitForSeconds(0.2f);

        public float tasaDeDisparo;
        private float tiempoAcumulado;
        private IEnumerator corutina;

        private void Awake()
        {
            controladorAnimaciones = GetComponent<ControladorAnimatorEnemigos>();
        }

        private void Start()
        {
            target = new GameObject("Target").transform;
            target.SetParent(SpawnArmas.Singleton.transform);
        }

        private void Update()
        {
            VerEnemigo();
        }

        private void VerEnemigo()
        {
            if (player != null)
            {
                Vector3 resta = player.position;
                resta.y = transform.position.y;
                transform.LookAt(resta);
                Disparar();
            }
        }

        private void Disparar()
        {
            if (Time.time > tiempoAcumulado)
            {
                controladorAnimaciones.Atacar();
                tiempoAcumulado = Time.time + tasaDeDisparo;

                if (player != null)
                {
                    Vector3 offset = player.position + new Vector3(0f, 1f, 0f);
                    target.position = offset;
                }

                if (corutina != null) StopCoroutine(corutina);
                corutina = Ataque();
                StartCoroutine(corutina);
            }
        }

        private IEnumerator Ataque()
        {
            yield return waitArrow;
            ControladorMusica.Singleton.ReproducirFlecha();
            AtaqueArco();
        }

        private void AtaqueArco()
        {
            if (player != null)
            {
                Vector3 offset = player.position + new Vector3(0f, 1f, 0f);
                target.position = offset;
            }

            SpawnArmas.Singleton.SpawnFlecha(posicionFlecha, ref flecha);
            flecha.GetComponent<EffectSettings>().Target = target.gameObject;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.CompareTag("Player"))
            {
                if (player == null)
                    player = other.transform;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.transform.CompareTag("Player"))
            {
                if (player != null)
                    player = null;
            }
        }
    }
}
