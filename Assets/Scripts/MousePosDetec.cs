using UnityEditor;
using UnityEngine;

public class MousePosDetec : MonoBehaviour
{
    [SerializeField] private Camera m_Camera;
    public GameObject TargetedObject;
    Color originalColor;
    [SerializeField] public bool OFC = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Camera = FindAnyObjectByType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;

        Ray myRay = m_Camera.ScreenPointToRay(mousePosition);
        {
            RaycastHit hit;

            if  (Physics.Raycast(myRay, out hit, Mathf.Infinity))
            {
                Debug.DrawRay(myRay.origin, myRay.direction * 1000, Color.yellow);
                Debug.Log("objet touché");
                

                if (hit.collider.CompareTag("ObjFocusCam"))
                {

                    TargetedObject = hit.collider.gameObject;
                    hit.collider.GetComponent<Renderer>().material.color = Color.red;
                    OFC = true;
                    Debug.Log(TargetedObject.name);
                }
                else OFC = false;

            }
        }
    }
}
