using UnityEngine;
using System.Collections;
//using UnitySampleAssets.CrossPlatformInput;

namespace CompleteProject
{
    public class PlayerShooting : MonoBehaviour
    {
        //to damage the enemies
        [SerializeField, Header("variables")]        
        GameObject _fireCollider;

        // Reference to the particle system.
        [SerializeField]        
        ParticleSystem _fireParticles;                    
        // Reference to the audio source.
        AudioSource _gunAudio;

        // to use inputs of the controller
        public VRTK.VRTK_ControllerEvents _controllerEvents;

        // A layer mask so the raycast only hits things on the shootable layer.
        int shootableMask;

        // To know if the flamethrower is on
        bool _gunIsFiring;


        // Reference to the light component.
        [SerializeField, Header("Light")]
        Light _gunLight;
        // change intensity speeds
        [SerializeField]
        float _turnOnLightSpeed, _turnOffLightSpeed;

        

        void Awake()
        {
            // Create a layer mask for the Shootable layer.
            shootableMask = LayerMask.GetMask("Shootable");

            // Set up the references.
            _gunAudio = GetComponent<AudioSource>();
        }


        void Update()
        {
            // If the trigger button is being press and it's time to fire...
            if (_controllerEvents.triggerPressed && !_gunIsFiring)
            {
                // shoot the gun.
                Shoot ();
            }
            else if (!_controllerEvents.triggerPressed && _gunIsFiring) 
            {
                StopShooting();
            }
        }
        
        // Start Fire
        void Shoot ()
        {
            _gunIsFiring = true;
            _gunAudio.Play();
            _fireCollider.SetActive(true);         
            _fireParticles.Play ();
            StopAllCoroutines();
            StartCoroutine(TurnGunLight(true, 1));
        }

        // Stop the fire
        public void StopShooting()
        {
            _gunIsFiring = false;
            _gunAudio.Stop();
            _fireCollider.SetActive(false);
            _fireParticles.Stop();
            StopAllCoroutines();
            StartCoroutine(TurnGunLight(false, 1));
        }

        // To enable light of the gun
        IEnumerator TurnGunLight(bool aState, float aDelay) // sTate = true to turn on
        {
            if (aState)
            {
                while (_gunLight.intensity < 1)
                {
                    _gunLight.intensity += Time.deltaTime * _turnOnLightSpeed;
                    yield return null;
                }
            }
            else
            {
                while (_gunLight.intensity > 0)
                {
                    _gunLight.intensity -= Time.deltaTime * _turnOffLightSpeed;
                    yield return null;
                }
            }
            yield return null;
        }
    }
}