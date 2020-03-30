using UnityEngine;
using UnityEngine.AI;

public class InvestigatingScript : MonoBehaviour
{

    public Camera cam;
    public NavMeshAgent agent;
    public float timer;
    public Transform player;
    float taberTimer;

    // Update is called once per frame
    void Update()
    {
        //If there is a noise. Move. The input is position on the 2d plane of the screen.
        if (NoiseScript.noiseOn == true)
        {

            agent.SetDestination(new Vector3(0.15f, 3, 1.5f));
            timer = timer + Time.deltaTime;
            /*  Ray ray = cam.ScreenPointToRay(new Vector3(533, 409, 0));
              RaycastHit hit;
              if (Physics.Raycast(ray, out hit))
              {
                  agent.SetDestination(hit.point);
              }

              */


            Debug.Log(timer);
            //After ten seconds NPC will return to position.
            if (timer > 10)
            {
                NoiseScript.noiseOn = false;
                timer = 0;

            }
            Debug.Log(NoiseScript.noiseOn);
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



        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }

        //Looks towards person if he gets too close.
        if (Vector3.Distance(player.position, this.transform.position) < 1.5f)
        {
            Vector3 direction = player.position - this.transform.position;
            direction.y = 0;
            //Debug.Log(direction);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
            taberTimer = taberTimer + Time.deltaTime;
            if (taberTimer > 5)
            {
                Debug.Log("GAME OVER, BITCH!");
            }
        }
        else
        {
            taberTimer = 0;
        }
    }
}
