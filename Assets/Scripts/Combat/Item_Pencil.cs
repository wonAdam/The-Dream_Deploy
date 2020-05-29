using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ADAM.Combat
{
    public class Item_Pencil : MonoBehaviour
    {
        [SerializeField] int pencilObtainCount = 5;

        private void OnTriggerEnter2D(Collider2D other) {
            if(other.gameObject.tag == "Player")
            {
                other.GetComponent<Shooter>().ObtainPencil(pencilObtainCount);
                Destroy(gameObject);
            }
        }
    }
}

