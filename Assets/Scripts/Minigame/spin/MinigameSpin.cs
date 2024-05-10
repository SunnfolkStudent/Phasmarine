using UnityEngine;
using Random = UnityEngine.Random;
using FMODUnity;
using FMOD.Studio;
using STOP_MODE = FMOD.Studio.STOP_MODE;

namespace Minigame.spin
{
    public class MinigameSpin : MonoBehaviour
    {
        private EventInstance minigameMusicEventInstance;
        private MiniGameManager _miniGameManager;
        
        // speed er mengden grader pilen roteres per frame
        [SerializeField]private  float speed = 3;
        [SerializeField]private float klrange = 20;

        [SerializeField]private bool irange = false;

        [SerializeField]private float pilpos;

        [SerializeField]private float spotpos;
        
        //audio
        [SerializeField] private EventReference klokkeRiktig;
        
        [SerializeField] private EventReference klokkeFeil;
        

// rangev1 er fra pilposisjon - klrange til pilposisjon
// rangev2 er fra pilposisjon til pilposisjon + klrange
        private Vector2 rangev1 = new Vector2(0, 0);
        private Vector2 rangev2 = new Vector2(0, 0);

        [SerializeField]private RectTransform pilTransform;
        [SerializeField]private RectTransform spotTransform;
        
        private int score;
        
        //audio
        private void Start()
        {
            AudioManager.instance.minigameMusicEventInstance.start();
            _miniGameManager = GetComponent<MiniGameManager>();
        }

        private void Update()
        {
            
            // finne range
            rangev1 = new Vector2(spotpos - klrange, spotpos);
            rangev2 = new Vector2(spotpos, spotpos + klrange);
            // sjekke om minimum er under 0 eller maximum er over 359
            if (rangev1.x < 0)
            {
                rangev1 = new Vector2(rangev1.x + 360, 359);
                rangev2 = new Vector2(0, rangev2.y);
           
            }

            if (rangev2.y > 359)
            {
                rangev1 = new Vector2(rangev1.x, 359);
                rangev2 = new Vector2(0, rangev2.y - 360);
            }
           
               
            // pil innenfor spotrange?
            if ((pilpos >= rangev1.x && pilpos <= rangev1.y) || (pilpos >= rangev2.x && pilpos <= rangev2.y))
            { 
                irange = true;
            }
            else
            {
                irange = false;
            }
        
            // dersom spilleren trykker, sette ny posisjon av spot
            if (Input.GetKeyDown("space") && irange == true)
            {
                global::AudioManager.instance.PlayOneShot(klokkeRiktig, this.transform.position);
                spotpos += Random.Range(60, 300);
                score++;
            }

            if (Input.GetKeyDown("space") && irange == false)
            {
                global::AudioManager.instance.PlayOneShot(klokkeFeil, this.transform.position);
            }
            

            if (score >= 3)
            {
                minigameMusicEventInstance.stop(STOP_MODE.ALLOWFADEOUT);
                GraveScript.StartTresure = true;
                StatickSceneControler.SpinMiniGameDown();
            }

            if (spotpos > 360)
            {
                spotpos -= 360;
            } 
            spotTransform.eulerAngles = new Vector3(0, 0, spotpos);
            if (irange == false)
            {
                print("miss");
            }
        
            // bevege pilpos med speed, så sette spritens rotasjon til pilpos
            pilpos -= speed * Time.deltaTime;
            if (pilpos < 0)
            {
                pilpos += 360;
            }
            // rotere spriten
            pilTransform.eulerAngles = new Vector3(0, 0, pilpos);
            
        }

    }
}
