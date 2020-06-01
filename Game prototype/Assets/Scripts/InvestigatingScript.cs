using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class InvestigatingScript : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    public float timer;
    public Transform player;
    float taberTimer;
    public GameObject lossImage;
    float restartTimer = 300;

    // Update is called once per frame
    void Update()
    {
        //If there is a noise. Move. This is for squeeky floor only
        if (NoiseScript.noiseOn == true)
        {
            agent.SetDestination(NoiseScript.squeekyPos);
            timer = timer + Time.deltaTime;
            /*  Ray ray = cam.ScreenPointToRay(new Vector3(533, 409, 0));
              RaycastHit hit;
              if (Physics.Raycast(ray, out hit))
              {
                  agent.SetDestination(hit.point);
              }
              */


            //Debug.Log(timer);
            //After ten seconds NPC will return to position.
            if (timer > 4 && timer < 7)
            {
                this.transform.Rotate(new Vector3(0, 2, 0));
            }
            if (timer > 7 && timer < 10)
            {
                this.transform.Rotate(new Vector3(0, -2, 0));

            }
            if (timer > 10)
            {
                NoiseScript.noiseOn = false;
                timer = 0;

            }
         //   Debug.Log(NoiseScript.noiseOn);
        }

        if (NoiseScript.noiseOn == false)
        {
            agent.SetDestination(new Vector3(-3.15f, 0, -3.32f));
            /* Ray ray = cam.ScreenPointToRay(new Vector3(400, 100, 0));
             RaycastHit hit;
             Debug.Log("OMW Back");
             if (Physics.Raycast(ray, out hit))
             {
                 agent.SetDestination(hit.point);
             }
             */
        }

        //Makes NPC move towards noise on interactable objects. (Danny's objects)
        if (ObjectInteractions.startInvestigate == true)
        {
            agent.SetDestination(ObjectInteractions.objectPosition);
            timer = timer + Time.deltaTime;
            //Timer stuff and turning to look around once NPC gets to the source of the sound.
            if (timer > 4.3 && timer < 4.5)
            {
                ObjectInteractions.objectPosition = this.transform.position;
            }
                
            if (timer > 4.5 && timer < 7)
            {

                this.transform.Rotate(new Vector3(0, 2, 0));
            }
            if (timer > 7 && timer < 10)
            {
                this.transform.Rotate(new Vector3(0, -2, 0));
            }
            if (timer > 10)
            {
                ObjectInteractions.startInvestigate = false;
                timer = 0;

            }
        }

        /*Makes NPC move based on mouseclicks. Remove before build.
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
        */


        //Looks towards person if he gets too close.
        //TurnAngle is the angle of which the player is needed to be inside of (from NPC) For the NPC to rotate towards player.
        int turnAngle = 130;
        if (Vector3.Distance(player.position, this.transform.position) < 1.8f && Vector3.Angle(this.transform.forward, player.transform.position - this.transform.position) < turnAngle)
        {
            Vector3 direction = player.position - this.transform.position;
            direction.y = 0;
            //Debug.Log(direction);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.2f);

            //This is the lose determination. You can change the angle
            int loseAngle = 45;
            if (Vector3.Angle(this.transform.forward, player.transform.position - this.transform.position) < loseAngle)
            {
                taberTimer = taberTimer + Time.deltaTime;
                if (taberTimer > 0.6)
                {
                    lossImage.SetActive(true);
                    if(restartTimer>10){
                        restartTimer = 0;
                    }
                    
                }
            
            }
        }
        else
        {
            taberTimer = 0;
        }

    restartTimer += Time.deltaTime;

    if (restartTimer > 5 && restartTimer < 8){
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);

         }
    }
}