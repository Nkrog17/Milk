using UnityEngine;
using UnityEngine.AI;

public class InvestigatingScript : MonoBehaviour
{

    public Camera cam;
    public NavMeshAgent agent;
    public float timer;


    // Update is called once per frame
    void Update()
    {
        //If there is a noise. Move. The input is position on the 2d plane of the screen.
        if (NoiseScript.noiseOn == true) {
            Ray ray = cam.ScreenPointToRay(new Vector3(533, 409, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
            timer = timer + Time.deltaTime;

            //After ten seconds NPC will return to position.
            if (timer > 10) {
                timer = 0;
                NoiseScript.noiseOn = false;
                Debug.Log(NoiseScript.noiseOn);
                
            }
        }

        if (NoiseScript.noiseOn == false) {
            Ray ray = cam.ScreenPointToRay(new Vector3(400, 100, 0));
            RaycastHit hit;
            Debug.Log("OMW Back");
            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
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
    }
}
