using System;
using System.Collections.Generic;
using CodeBase.Infrastraction.Factory;
using CodeBase.Logic;
using CodeBase.StateData;
using UnityEngine;


public class Meteorite : MonoBehaviour
{
    public GameObject ParticleEffect;
    public Sound Sound;
    
    public float Score { get; set; }
    
    private Heart _heart;
    public List<GameObject> EmptyPoint = new ();
    private SpawnMeteorite _spawnMeteorite;

    public void Construct(SpawnMeteorite spawnMeteorite)
    {
        _spawnMeteorite = spawnMeteorite;
    }

    private void Awake()
    {
        _heart = GetComponentInChildren<Heart>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Sound.PlayOneShot(SoundType.MeteoriteDamage);
        }
    }

    private void Start() => 
        _heart.Hit += Destroy;

    private void Destroy()
    {
        _spawnMeteorite.Destroy(Score);
        Instantiate(ParticleEffect, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnDisable() => 
        _heart.Hit -= Destroy;
}
