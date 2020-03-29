using UnityEngine;

public class CameraFollower : MonoBehaviour
{
   	public GameObject player;
   	public float yOffset;
   	Vector3 offset;

   	void Start(){
   		 offset = new Vector3(0,yOffset,0);
   	}

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
