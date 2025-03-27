using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cemara : MonoBehaviour
{

    [SerializeField] private Transform player;
    //[SerializeField] private Transform chicat;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        //transform.position = new Vector3(chicat.position.x, chicat.position.y, transform.position.z);
    }
}
