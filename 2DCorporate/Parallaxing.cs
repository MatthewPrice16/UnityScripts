using UnityEngine;

public class Parallaxing : MonoBehaviour
{

    public Transform[] backgrounds; //list of all back and foregrounds to be paralax
    private float[] parallaxScales; //the proportion of the cameras movement
    public float smoothing = 1f;    //how smooth the parallax will be must be above 0

    private Transform cam;          //reference to the main camera
    private Vector3 previousCamPos; //stores position of camera from previous frame

    //great for references
    void Awake()
    {
        //set up reference to the camera
        cam = Camera.main.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Store the previous camera frame position
        previousCamPos = cam.position;

        //assigning coresponding parallaxScales
        parallaxScales = new float[backgrounds.Length];
        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z*-1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //for each background
        for(int i = 0; i < backgrounds.Length; i++)
        {
            //the parallax is the opposite of the camera movments because the previous frame is multiplied by the scale
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

            //set a target x positon which is current position plus the parallax
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            //create a target position which is the background current position with its target x position
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            //fade between current and target position using lerp
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);

        }
        //set previous camPos to the cameras positon at the end of the frame
        previousCamPos = cam.position;
        
    }

    
}
