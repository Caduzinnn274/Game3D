using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BASA
{


    public class PlayerController : MonoBehaviour
    {
        [Header("Config Personagem")]
        public CharacterController controle;
        public float velocidade = 6f;
        public float alturaPulo = 3f;
        public float gravidade = -20f;
        public bool estaCorrendo;

        [Header("Verifica chao")]
        public Transform checaChao;
        public float raioEsfera = 0.4f;
        public LayerMask chaoMask;
        public bool estaNoChao;
        Vector3 velocidadeCai;

        [Header("Verifica Abaixado")]
        public Transform cameraTransform;
        public bool estaAbaixado;
        public bool levantarBloquado;
        public float alturaLevantado, alturaAbaixado, posicaoCameraEmPe, posicaoCameraAbaixado;
        float velocidadeCorrente = 1f;
        RaycastHit hit;

        [Header("Status Personagem")]
        public float hp = 100;
        public float stamina = 100;
        public bool cansado;


        // Start is called before the first frame update
        void Start()
        {
            cansado = false;
            estaCorrendo = false;
            controle = GetComponent<CharacterController>();
            estaAbaixado = false;

        }

        // Update is called once per frame
        void Update()
        {
            Verificacoes();
            MovimentoAbaixa();
            Inputs();
            CondicaoPlayer();

        }

        void Verificacoes()
        {
            estaNoChao = Physics.CheckSphere(checaChao.position, raioEsfera, chaoMask);

            if (estaNoChao && velocidadeCai.y < 0)
            {
                velocidadeCai.y = -2f;
            }
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");


            Vector3 move = (transform.right * x + transform.forward * z).normalized;

            controle.Move(move * velocidade * Time.deltaTime);

            velocidadeCai.y += gravidade * Time.deltaTime;


            controle.Move(velocidadeCai * Time.deltaTime);


        }


        void MovimentoAbaixa()
        {

            controle.center = Vector3.down * (alturaLevantado - controle.height) / 2f;
            if (estaAbaixado)
            {
                controle.height = Mathf.Lerp(controle.height, alturaAbaixado, Time.deltaTime * 3);
                float novoY = Mathf.SmoothDamp(cameraTransform.localPosition.y, posicaoCameraAbaixado, ref velocidadeCorrente, Time.deltaTime * 3);
                cameraTransform.localPosition = new Vector3(0, novoY, 0);
                velocidade = 3f;
                ChecaBloqueioAbaixado();
            }
            else
            {
                controle.height = Mathf.Lerp(controle.height, alturaLevantado, Time.deltaTime * 3);
                float novoY = Mathf.SmoothDamp(cameraTransform.localPosition.y, posicaoCameraEmPe, ref velocidadeCorrente, Time.deltaTime * 3);
                cameraTransform.localPosition = new Vector3(0, novoY, 0);
                velocidade = 6f;

            }

        }

        void Inputs()
        {
            if (Input.GetKey(KeyCode.LeftShift) && estaNoChao && !estaAbaixado && !cansado)
            {
                estaCorrendo = true;
                velocidade = 9f;
                stamina -= 0.3f;
                stamina = Mathf.Clamp(stamina, 0, 100);
            }
            else
            {
                estaCorrendo = false;
                stamina += 0.1f;
                stamina = Mathf.Clamp(stamina, 0, 100);
            }
            if (Input.GetButtonDown("Jump") && estaNoChao)
            {
                velocidadeCai.y = Mathf.Sqrt(alturaPulo * -2f * gravidade);
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                Abaixa();
            }

        }


        void Abaixa()
        {

            if (levantarBloquado || estaNoChao == false)
                return;


            estaAbaixado = !estaAbaixado;


        }

        void ChecaBloqueioAbaixado()
        {
            Debug.DrawRay(cameraTransform.position, Vector3.up * 1.1f, Color.red);
            if (Physics.Raycast(cameraTransform.position, Vector3.up, out hit, 1.1f))
            {
                levantarBloquado = true;
            }
            else
            {
                levantarBloquado = false;
            }
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(checaChao.position, raioEsfera);
        }

        void CondicaoPlayer()
        {
            if(stamina == 0)
            {
                cansado = true;

            }

            if(stamina > 20)
            {
                cansado = false;
            }
        }
    }

    
}
