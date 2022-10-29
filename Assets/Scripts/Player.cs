using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private FogWar _fogWar = null;
    [SerializeField]
    private Transform _visibleRange = null;
    [SerializeField]
    private GameObject _player = null;
    [SerializeField]
    private GameObject _mapPlayer = null;

    private float sightDistance = 2.0f;
    private float checkInterval = 0.25f;
    
    void Start()
    {
        StartCoroutine(CheckFogOfWar(checkInterval));
        _visibleRange.localScale = new Vector2(sightDistance, sightDistance) * 10f;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _mapPlayer.transform.position += transform.up * Time.deltaTime;
            _player.transform.position += (transform.up * Time.deltaTime) * 10;
        }
           
        if (Input.GetKey(KeyCode.S))
        {
            _mapPlayer.transform.position -= transform.up * Time.deltaTime;
            _player.transform.position -= (transform.up * Time.deltaTime) * 10;
        }
            
        if (Input.GetKey(KeyCode.A))
        {
            _mapPlayer.transform.position -= transform.right * Time.deltaTime;
            _player.transform.position -= (transform.right * Time.deltaTime) * 10;
        }
           
        if (Input.GetKey(KeyCode.D))
        {
            _mapPlayer.transform.position += transform.right * Time.deltaTime;
            _player.transform.position += (transform.right * Time.deltaTime) * 10;
        }
           
    }

    private IEnumerator CheckFogOfWar(float checkInterval)
    {
        while (true)
        {
            _fogWar.MakeHole(transform.position, sightDistance);
            yield return new WaitForSeconds(checkInterval);
        }
    }
}
