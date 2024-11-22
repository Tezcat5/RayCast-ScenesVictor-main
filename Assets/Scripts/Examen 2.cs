using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Examen2 : MonoBehaviour
{
    public Text cuentaAtrasTexto;
    
    public int cuentaAtrasDuracion = 5;
    
    public string[] Objetos;
    
    public string[] Escenas;
    
    private bool Cuenta = false;



    void Update()
    {
        if (Input.GetButtonDown("Fire1"))

        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                for (int i = 0; i < Objetos.Length; i++)
                {
                    if (hit.transform.name == Objetos[i] && !Cuenta)
                    {
                        StartCoroutine(CuentaAtras(Escenas[i]));
                        break;
                    }
                }
            }
        }
    }

    IEnumerator CuentaAtras(string escenaDestino)
    {
        Cuenta = true;

        for (int i = cuentaAtrasDuracion; i >= 0; i--)
        {
            cuentaAtrasTexto.text = i.ToString();
            yield return new WaitForSeconds(1);
        }

        SceneManager.LoadScene(escenaDestino);
        Cuenta = false
    }
}
