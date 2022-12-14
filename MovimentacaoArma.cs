using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoArma : MonoBehaviour
{
    public float valor;
    public float suavizarValor;
    public float valorMaximo;
    private Vector3 posicaoInicial;
    // Start is called before the first frame update
    void Start()
    {
        posicaoInicial = transform.localPosition;
        
    }

    // Update is called once per frame
    void Update()
    {
        float movimentoX = -Input.GetAxis("Mouse X") * valor;
        float movimentoY = -Input.GetAxis("Mouse Y") * valor;

        movimentoX = Mathf.Clamp(movimentoX, -valorMaximo, valorMaximo);
        movimentoY = Mathf.Clamp(movimentoY, -valorMaximo, valorMaximo);

        Vector3 finalPosition = new Vector3(movimentoX, movimentoY, 0);

        transform.localPosition = Vector3.Lerp(transform.localPosition, finalPosition + posicaoInicial, Time.deltaTime * suavizarValor);


    }
}
