using UnityEngine;

namespace Emperor
{
    public class Distancia : MonoBehaviour
    {
        public AnimationCurve animationCurve;

        public Transform inicio;
        public Transform final;
        private float interVector;

        private void Update()
        {
            if (interVector >= 1) return;
            Vector3 relativo = Vector3.Lerp(inicio.position, final.position, interVector);
            float varY = animationCurve.Evaluate(interVector);
            varY *= 100f;
            float variaY = relativo.y;
            relativo.y = variaY + varY;
            //Vector3 rotRelativo = new Vector3()
            transform.LookAt(relativo);

            interVector += 0.01f;
            transform.position = relativo;
            //transform.position = 
        }
    }
}