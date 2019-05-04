using UnityEngine;

public class ArmPointer : MonoBehaviour
{
    public int rotationOffset = 90;

    void Awake()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        //subtracting player position from cursor position
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize(); //make numbers smaller for faster computing

        //finding angle converting to degree
        float rotZ = Mathf.Atan2(difference.y,difference.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffset);
    }
}
