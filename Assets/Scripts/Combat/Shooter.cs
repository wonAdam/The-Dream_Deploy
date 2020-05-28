using System.Collections;
using System.Collections.Generic;
using ADAM.Movement;
using ADAM.UI;
using UnityEngine;
using UnityEngine.UI;

namespace ADAM.Combat
{
    public class Shooter : MonoBehaviour
    {

        [SerializeField] GameObject pencil;
        [SerializeField] Transform gun;
        [SerializeField] int pencilCount = 0;
        PencilUI pencilUI;
        Button shootBtn;

        private void Start() {

            pencilUI = FindObjectOfType<PencilUI>();
            pencilUI.UpdatePencilCount(pencilCount);
            shootBtn = FindObjectOfType<ShootBtn>().GetComponent<Button>();
            shootBtn.onClick.AddListener(Shoot);
        }

        public void Shoot()
        {
            if(pencilCount < 1) return;

            pencilCount--;
            pencilUI.UpdatePencilCount(pencilCount);

            GameObject inst = Instantiate(pencil, gun.position, gun.localRotation);
            inst.GetComponent<Pencil>().dir = gun.right;

        }
    }
}
