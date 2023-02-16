using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class LegoPlayer : MonoBehaviourPunCallbacks
{
    public GameObject projectile;
    
    void Start()
    {
        if(photonView.IsMine)
        {
            transform.GetChild(1).gameObject.GetComponent<Renderer>().material.color = Color.green;
            transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = "Me";
        }
    }

    // [PunRPC]
    // void RPC_TriggerProjectile()
    // {
    //     if(!photonView.IsMine){
    //         GameObject ball = Instantiate(projectile, transform.position, transform.rotation);
    //         ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(300f, 0, 0));
    //     }
    // }
}