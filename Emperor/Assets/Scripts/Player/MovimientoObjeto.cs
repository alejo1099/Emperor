using UnityEngine;

namespace Emperor
{
    [RequireComponent(typeof(Rigidbody))]
    public class MovimientoObjeto : MonoBehaviour
    {
        private ControladorAnimacionesArquero controladorAnimaciones;
        private Vector3 desplazamientoJugador;

        private Transform transformPlayer;
        private Transform transformCamara;
        private Rigidbody rigidbodyPlayer;

        public float velocidadMovimiento;
        public float velocidadRotacion;
        public float fuerzaSalto;
        private float guardarvelocidadMovimiento;
        private float x, y;
        private float mouseX;

        private bool rotando;
        private bool saltando;

        private void Awake()
        {
            transformCamara = GetComponentInChildren<Camera>().transform;
        }

        private void Start()
        {
            controladorAnimaciones = GetComponent<ControladorAnimacionesArquero>();
            transformPlayer = transform;
            rigidbodyPlayer = GetComponent<Rigidbody>();
            guardarvelocidadMovimiento = velocidadRotacion;
        }

        private void Update()
        {
            if (Time.timeScale == 0)
                return;
                
            RotarAnimator();
            MovimientoRigidbody();
            RotacionRigidbody();
            Saltar();
            MoverAnimator();
        }

        private void MoverAnimator()
        {
            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");
            controladorAnimaciones.CaminarPlayer(x, y);
        }

        private void RotarAnimator()
        {
            if (!rotando && (x == 0 && y == 0))
            {
                rotando = true;
                controladorAnimaciones.rotar = true;
            }
            else if (rotando && (x != 0 || y != 0))
            {
                controladorAnimaciones.rotar = false;
                rotando = false;
            }

            if (rotando)
            {
                mouseX = Input.GetAxis("Mouse X");
                controladorAnimaciones.Rotar(mouseX);
            }
        }

        private void MovimientoRigidbody()
        {
            desplazamientoJugador = ((transformPlayer.forward *
            Input.GetAxis("Vertical")) + (transformPlayer.right * Input.GetAxis("Horizontal"))) * velocidadMovimiento;

            rigidbodyPlayer.MovePosition(transformPlayer.position + desplazamientoJugador);
        }

        private void RotacionRigidbody()
        {
            rigidbodyPlayer.MoveRotation(transformPlayer.rotation * Quaternion.Euler(0f, Input.GetAxis("Mouse X")
            * velocidadRotacion, 0f));

            transformCamara.localRotation *= Quaternion.Euler(Input.GetAxis("Mouse Y") * -velocidadRotacion, 0f, 0f);

            velocidadRotacion = (transformCamara.localRotation.x >= 0.3826f && Input.GetAxis("Mouse Y") < -0.1f)
             || (transformCamara.localRotation.x <= -0.5f && Input.GetAxis("Mouse Y") > 0.1f) ? 0 : guardarvelocidadMovimiento;
        }

        private void Saltar()
        {
            if (Input.GetKeyDown(KeyCode.Space) && !saltando)
            {
                rigidbodyPlayer.AddForce(transformPlayer.up * fuerzaSalto);
                saltando = true;
            }
            if (saltando && Physics.Raycast(transform.position, -transform.up, 0.05f))
            {
                saltando = false;
            }
        }
    }
}