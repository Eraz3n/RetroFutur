using UnityEngine;

public class CameraMouvements : MonoBehaviour
{
    public GameObject CamInitPos;
    private Vector3 CamToObject;
    public MousePosDetec mousePosDetec;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        transform.position = CamInitPos.transform.position;
        transform.rotation = CamInitPos.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (mousePosDetec.OFC == true && Input.GetMouseButton(0))
        {
            CamToObject = transform.position - mousePosDetec.TargetedObject.transform.position;
            transform.Translate(CamToObject * Time.deltaTime);
        }

        if (Input.GetMouseButton(1))
        {
            transform.position = CamInitPos.transform.position;
            transform.rotation = CamInitPos.transform.rotation;
        }

    }
}
