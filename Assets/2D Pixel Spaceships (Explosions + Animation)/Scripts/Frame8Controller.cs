using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AllShips
{
    public class Frame8Controller : BaseFrameController {

        public Transform parentShip;
        public Dropdown dropdown;

        Dictionary<string, string> partNames;


        // Use this for initialization
        void Start () {
            Init();

            partNames = new Dictionary<string, string>();
            partNames.Add("Left cabin", "Ship8CabinStaticLeft");
            partNames.Add("Right cabin", "Ship8CabinStaticRight");
            partNames.Add("Left turret", "Ship8TurretLeft");
            partNames.Add("Right turret", "Ship8TurretRight");
            partNames.Add("Left bomb carrier", "Ship8BombCarrierLeft");
            partNames.Add("Right bomb carrier", "Ship8BombCarrierRight");
            partNames.Add("Left static turret", "Ship8TurretStaticLeft");
            partNames.Add("Right static turret", "Ship8TurretStaticRight");
            partNames.Add("Cabin 1", "Ship8Cabin1");
            partNames.Add("Cabin 2", "Ship8Cabin2");
            partNames.Add("Cabin 3", "Ship8Cabin3");
            partNames.Add("Core", "Ship8Reactor");

        }

        public void Explosion()
        {
            string ddText = dropdown.captionText.text;
            if (ddText == "Base")
            {
                PartExplosion("StaticLeft");
                PartExplosion("StaticRight");
            } else
            {
                string stringPartName = partNames[ddText];
                TurnOffRepeatFireForPart(stringPartName);
                PartExplosion(stringPartName);
            }
        }

        public void StartAllExplosion()
        {
            StartCoroutine(AllExplosion());
        }

        IEnumerator AllExplosion()
        {
            foreach (string part in partNames.Values)
            {
                PartExplosion(part);
                yield return new WaitForSeconds(1.0f);
            }
            PartExplosion("StaticLeft");
            PartExplosion("StaticRight");
        }

        public void Shield()
        {
            GameObject shield = parentShip.Find("Ship8Shield").gameObject;
            shield.SetActive(!shield.activeSelf);
        }

        void PartExplosion(string partName)
        {
            Transform part = parentShip.Find(partName);
            if (part != null)
                part.GetComponent<Animator>().SetBool("expl", true);

        }

        void TurnOffRepeatFireForPart(string partName)
        {
            Transform part = parentShip.Find(partName);
            if (part != null)
            {
                BaseBulletStarter bbs = part.GetComponent<BaseBulletStarter>();
                if (bbs != null)
                    bbs.StopRepeatFire();
            }
        }
	
	    public void LaunchBomb()
        {
            AnimTriggerForPart("Ship8BombCarrierLeft", "BombLaunch");
            AnimTriggerForPart("Ship8BombCarrierRight", "BombLaunch");
        }

        public void OneShot()
        {
            OneShotForPart("Ship8TurretLeft");
            OneShotForPart("Ship8TurretRight");
            OneShotForPart("Ship8TurretStaticLeft");
            OneShotForPart("Ship8TurretStaticRight");
            AnimTriggerForPart("Ship8Cabin1", "fire");
        }

        void RepeatFireForPart(string partName)
        {
            Transform part = parentShip.Find(partName);
            if (part != null)
            {
                if (repeatFire)
                    part.GetComponent<BaseBulletStarter>().StartRepeateFire();
                else
                    part.GetComponent<BaseBulletStarter>().StopRepeatFire();
            }
        }

        void OneShotForPart(string partName)
        {
            Transform part = parentShip.Find(partName);
            if (part != null)
                part.GetComponent<BaseBulletStarter>().MakeOneShot();
        }

        void AnimTriggerForPart(string partName, string trigger)
        {
            Transform part = parentShip.Find(partName);
            if (part != null)
                part.GetComponent<Animator>().SetTrigger(trigger);
        }

        public void RepeatFire()
        {
            repeatFire = !repeatFire;
            RepeatFireForPart("Ship8TurretLeft");
            RepeatFireForPart("Ship8TurretRight");
            RepeatFireForPart("Ship8TurretStaticLeft");
            RepeatFireForPart("Ship8TurretStaticRight");
        }
    }
}
