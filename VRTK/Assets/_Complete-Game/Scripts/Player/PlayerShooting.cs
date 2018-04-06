using UnityEngine;
//using UnitySampleAssets.CrossPlatformInput;

namespace CompleteProject
{
    public class PlayerShooting : MonoBehaviour
    {        
        //public float timeBetweenBullets = 0.15f;        // The time between each shot.
        //public float range = 100f;                      // The distance the gun can fire.

        bool _gunIsFiring; // To know if the flamethrower is on

        [SerializeField]
        GameObject _fireCollider; //to damage the enemies


        public VRTK.VRTK_ControllerEvents _controllerEvents; // to use inputs

        //float timer;                                    // A timer to determine when to fire.
        //Ray shootRay = new Ray();                       // A ray from the gun end forwards.
        //RaycastHit shootHit;                            // A raycast hit to get information about what was hit.
        int shootableMask;                              // A layer mask so the raycast only hits things on the shootable layer.

        [SerializeField]
        ParticleSystem _fireParticles;                    // Reference to the particle system.
        //LineRenderer gunLine;                           // Reference to the line renderer.
        AudioSource _gunAudio;                           // Reference to the audio source.
        //Light gunLight;                                 // Reference to the light component.
        //public Light faceLight;								// Duh
        //float effectsDisplayTime = 0.2f;                // The proportion of the timeBetweenBullets that the effects will display for.


        void Awake()
        {
            // Create a layer mask for the Shootable layer.
            shootableMask = LayerMask.GetMask("Shootable");

            // Set up the references.
            //gunParticles = GetComponent<ParticleSystem>();
            //gunLine = GetComponent<LineRenderer>();
            _gunAudio = GetComponent<AudioSource>();
            //gunLight = GetComponent<Light>();
            //faceLight = GetComponentInChildren<Light> ();
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



        void Shoot ()
        {
            _gunIsFiring = true;
            _gunAudio.Play();
            _fireCollider.SetActive(true);
            
            _fireParticles.Play ();            
        }

        public void StopShooting()
        {
            _gunIsFiring = false;
            _gunAudio.Stop();
            _fireCollider.SetActive(false);
            _fireParticles.Stop();
        }
    }
}