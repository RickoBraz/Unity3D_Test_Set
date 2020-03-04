using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class DestroyItens : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        IGameobjectDestroy Itens = other.GetComponent<IGameobjectDestroy>();
        Itens?.DestroyGameobject();
    }
}
