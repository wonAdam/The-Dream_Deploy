using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ADAM.Movement
{
    public class Pencil : MonoBehaviour
    {
        [SerializeField] public  float speed;
        public Vector2 dir = Vector2.zero;
        Rigidbody2D myRB;
        // Start is called before the first frame update
        void Start()
        {
            myRB = GetComponent<Rigidbody2D>();
        }
        private void Update() {
            myRB.velocity = dir * speed * Time.deltaTime;
        }

    }
}
