using UnityEngine;

public class DeskSceneGenerator : MonoBehaviour
{
    void Start()
    {
        CreateDesk();
        CreateCalculator();
        CreateComputer();
    }

    void CreateDesk()
    {
        GameObject desk = GameObject.CreatePrimitive(PrimitiveType.Cube);

        desk.name = "Desk";
        desk.transform.position = new Vector3(0, 0, 0);
        desk.transform.localScale = new Vector3(4f, 0.2f, 2f);

        desk.GetComponent<Renderer>().material.color =
            new Color(0.25f, 0.15f, 0.05f);
    }

    void CreateCalculator()
    {
        GameObject calculator =
            GameObject.CreatePrimitive(PrimitiveType.Cube);

        calculator.name = "Calculator";
        calculator.transform.position =
            new Vector3(-0.8f, 0.15f, 0f);

        calculator.transform.localScale =
            new Vector3(0.3f, 0.05f, 0.5f);

        CreateAnchor(
            calculator,
            new Vector3(0f, 10f, -0.4f),
            Quaternion.Euler(50f, 0f, 0f)
        );
    }

    void CreateComputer()
    {
        GameObject screen =
            GameObject.CreatePrimitive(PrimitiveType.Cube);

        screen.name = "Computer";

        screen.transform.position =
            new Vector3(0.8f, 0.4f, 0f);

        screen.transform.localScale =
            new Vector3(0.8f, 0.5f, 0.05f);

        CreateAnchor(
            screen,
            new Vector3(0f, 0.5f, -20f),
            Quaternion.Euler(10f, 0f, 0f)
        );
    }

    void CreateAnchor(
        GameObject parent,
        Vector3 localPosition,
        Quaternion localRotation)
    {
        GameObject anchor = new GameObject("CameraAnchor");

        anchor.transform.SetParent(parent.transform);

        anchor.transform.localPosition = localPosition;
        anchor.transform.localRotation = localRotation;

        parent.AddComponent<ClickableObject>()
            .cameraAnchor = anchor.transform;
    }
}