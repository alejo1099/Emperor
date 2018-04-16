using UnityEngine;
using UnityEngine.SceneManagement;

namespace Emperor
{
    public class CambiarEscena : MonoBehaviour
    {
        public void IrMenuPrincipal()
        {
            SceneManager.LoadScene(0);
        }

        public void IrNivelJuego()
        {
            SceneManager.LoadScene(1);
        }

		public void SalirJuego()
		{
			Application.Quit();
		}
    }
}
