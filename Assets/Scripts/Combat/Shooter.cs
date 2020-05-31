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
        [SerializeField] float shootDelayDuration = 1.2f;
        public bool isShootDelaying = false;
        public float tiktokForShootDelay = 0f;
        PencilUI pencilUI;
        Button shootBtn;

        private void Start() {

            pencilUI = FindObjectOfType<PencilUI>();
            pencilUI.UpdatePencilCount(pencilCount);
            shootBtn = FindObjectOfType<ShootBtn>().GetComponent<Button>();
            shootBtn.onClick.AddListener(Shoot);
        }
        private void Update() {
            if(isShootDelaying)
                TikTokForShootDelay();
        }

        private void TikTokForShootDelay()
        {
            tiktokForShootDelay += Time.deltaTime;

            if(tiktokForShootDelay >= shootDelayDuration)
            {
                tiktokForShootDelay = 0f;
                isShootDelaying = false;
            }
        }

        public void Shoot()
        {
            if(pencilCount < 1) return;
            if(isShootDelaying) return;

            pencilCount--;
            pencilUI.UpdatePencilCount(pencilCount);
            isShootDelaying = true;

            GameObject inst = Instantiate(pencil, gun.position, gun.localRotation);
            inst.GetComponent<Pencil>().dir = gun.right;

        }

        public void ObtainPencil(int count)
        {
            pencilCount += count;
            pencilUI.UpdatePencilCount(pencilCount);
        }
    }
}
