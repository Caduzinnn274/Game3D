using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BASA;

public class UIManager : MonoBehaviour
{

    public Slider sliderHP, sliderStamina;
    public PlayerController scriptMovimenta;
     
    // Start is called before the first frame update
    void Start()
    {
        scriptMovimenta = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        sliderHP.value = scriptMovimenta.hp;
        sliderStamina.value = scriptMovimenta.stamina;
        
    }
}
