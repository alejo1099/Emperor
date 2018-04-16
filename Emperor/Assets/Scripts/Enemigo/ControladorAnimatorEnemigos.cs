using UnityEngine;

namespace Emperor
{
    public class ControladorAnimatorEnemigos : MonoBehaviour
    {
        private Animator animator;
        private int atackTohash = Animator.StringToHash("Atacar");

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void Atacar()
        {
            animator.SetTrigger(atackTohash);
        }
    }
}
