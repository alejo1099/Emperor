using System;
using System.Collections;
using UnityEngine;

namespace Emperor
{
    public class Arquero : Salud
    {
        private ControladorAnimacionesArquero controladorAnimaciones;
        private Camera referenciaCamara;
        private Transform transformCamara;
        public Arco arco;

        private IEnumerator corutina;
        private WaitForSeconds waitArrow = new WaitForSeconds(0.2f);

        public float rangoFlecha = 40f;

        private bool valorAPuntar;
        private bool apuntando;

        private void Awake()
        {
            referenciaCamara = GetComponentInChildren<Camera>();
            transformCamara = referenciaCamara.transform;
            controladorAnimaciones = GetComponent<ControladorAnimacionesArquero>();
        }

        private void Update()
        {
            if (Time.timeScale == 0)
                return;
                
            Atacar();
            Apuntar();
        }

        private void Atacar()
        {
            if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.LeftControl))
            {
                controladorAnimaciones.Atacar();
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

        public void AtaqueArco()
        {
            Vector3 rayoCamara = referenciaCamara.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

            RaycastHit hit;
            if (Physics.Raycast(rayoCamara, transformCamara.forward, out hit, rangoFlecha, Physics.AllLayers, QueryTriggerInteraction.Ignore))
            {
                arco.Atacar(hit.point);
            }
            else
            {
                Vector3 pos = rayoCamara + (transformCamara.forward * rangoFlecha);
                arco.Atacar(pos);
            }
        }

        private void Apuntar()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                valorAPuntar = !valorAPuntar;
                controladorAnimaciones.Apuntar(valorAPuntar);
                apuntando = valorAPuntar;
            }
            else if (!apuntando && Input.GetMouseButton(0))
            {
                valorAPuntar = !valorAPuntar;
                controladorAnimaciones.Apuntar(valorAPuntar);
                apuntando = true;
            }
            else if (!apuntando && Input.GetKey(KeyCode.LeftControl))
            {
                valorAPuntar = !valorAPuntar;
                controladorAnimaciones.Apuntar(valorAPuntar);
                apuntando = true;
            }
        }
    }
}