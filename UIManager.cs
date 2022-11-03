using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BASA;

namespace BASA
{



public class UIManager : MonoBehaviour
{

    public Slider sliderHP, sliderStamina;
    public PlayerController scriptMovimenta;
    public Text municao;
    public Image imagemModoTiro;
    public Sprite[] spriteModoTiro;
     
    // Start is called before the first frame update
    void Start()
    {
        scriptMovimenta = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
            municao.enabled = true;
            imagemModoTiro.enabled = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        sliderHP.value = scriptMovimenta.hp;
        sliderStamina.value = scriptMovimenta.stamina;
        
    }
}
}
