using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausaJuego : MonoBehaviour
{
    public GameObject elementosPausa;

    private void Start()
    {
        BloquearMouse(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            PausarJuego();
    }

    public void PausarJuego()
    {
        BloquearMouse(true);
        Time.timeScale = 0f;
        elementosPausa.SetActive(true);
    }

    public void ReanudarJuego()
    {
		BloquearMouse(false);
        elementosPausa.SetActive(false);
        Time.timeScale = 1f;
    }

    private void BloquearMouse(bool valorCursor)
    {
        Cursor.visible = valorCursor;
        Cursor.lockState = valorCursor == false ? CursorLockMode.Locked : CursorLockMode.None;
    }
}