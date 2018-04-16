using UnityEngine;

namespace Emperor
{
    public class ControladorAnimacionesArquero : MonoBehaviour
    {
        private Animator animator;

        private int atackTohash = Animator.StringToHash("Atacar");
        private int varX = Animator.StringToHash("x");
        private int varY = Animator.StringToHash("y");
        private int rotX = Animator.StringToHash("RotacionX");

        private int apuntar = Animator.StringToHash("Apuntar");
        private int girar = Animator.StringToHash("Girar");

        private bool pRotar;
        public bool rotar
        {
            get { return pRotar; }
            set
            {
                animator.SetBool(girar, value);
                pRotar = value;
            }
        }

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void Atacar()
        {
            animator.SetTrigger(atackTohash);
        }

        public void CaminarPlayer(float x, float y)
        {
            animator.SetFloat(varX, x);
            animator.SetFloat(varY, y);
        }

        public void Apuntar(bool valor)
        {
            animator.SetBool(apuntar, valor);
        }

        public void Rotar(float mouseX)
        {
            animator.SetFloat(rotX, mouseX);
        }
    }
}