using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class RotateTo : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 target;
    public static AudioSource audio2;

    private void Start()
    {
        audio2 = GetComponent<AudioSource>();
        audio2.Play();
    }

   

    private void Update()
    {
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(target), speed * Time.deltaTime);
       
    }
}
