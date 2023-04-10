using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sector : MonoBehaviour
{
    public bool IsGood = true;
    public Material GoodMaterial;
    public Material BadMaterial;
    public Material BrokenMaterial;
    private bool broken = false;
    public Game Game;
    private AudioSource _audio;
    public GameObject Lose;
    public GameObject Broken;
    private void Awake()
    {
        UpdateMaterial();
    }
 

 
    private void OnCollisionEnter(Collision collision)
    {

        if (!collision.collider.TryGetComponent(out Player player)) return;
        
        Vector3 normal = -collision.contacts[0].normal.normalized;
        float dot = Vector3.Dot(normal, Vector3.up);
        if (dot < 0.5) return;

        if (IsGood)
        {
            player.Bounce();
            //Меняем цвет разбитому сектору и увеличиваем очки
            if (!broken)
            {
                broken = true;
                GetComponent<Renderer>().sharedMaterial = BrokenMaterial;
                Game.CountIndex++;
                //звук разбитой платформы
                _audio = GetComponent<AudioSource>();
                _audio.Play();
                //система частиц разбитой платформы
                Broken.GetComponent<ParticleSystem>().Play();

            }
        }
        else
        {
            //система частиц проигрыша
            Lose.GetComponent<ParticleSystem>().Play();
            player.Die();
        }
    }
    void UpdateMaterial()
    {
        GetComponent<Renderer>().sharedMaterial = IsGood ? GoodMaterial : BadMaterial;
    }
    private void OnValidate()
    {
        UpdateMaterial();
    }
}
