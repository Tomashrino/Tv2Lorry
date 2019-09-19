using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public static Player Instance;
    [SerializeField]
    private CanvasGroup blackCanvas;
    public Action<TransportPoint> OnPlayerTeleported;
    private TransportPoint currentPoint;

    public Material entrance, frontGarden, gardenHouse, midGarden;


    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("More than one player present in scene, make sure you just have 1! ", this);
            return;
        }
        Instance = this;
    }


    public void Transport(TransportPoint point)
    {
        currentPoint = point;

        //switch (currentPoint.tag)
        //{
        //    case "Untagged":
        //        Debug.LogWarning("Found tag: Untagged");
        //        break;
        //    case "Entrance":
        //        Debug.LogWarning("Found tag: Entrance");
        //        RenderSettings.skybox = entrance;
        //        break;
        //    case "FrontGarden":
        //        Debug.LogWarning("Found tag: FrontGarden");
        //        RenderSettings.skybox = frontGarden;
        //        break;
        //    case "GardenHouse":
        //        Debug.LogWarning("Found tag: GardenHouse");
        //        RenderSettings.skybox = gardenHouse;
        //        break;
        //    case "MidGarden":
        //        Debug.LogWarning("Found tag: MidGarden");
        //        RenderSettings.skybox = midGarden;
        //        break;
        //    default:
        //        Debug.LogWarning("default case hit");
        //        break;
        //}

            

        if (blackCanvas != null)
            StartCoroutine(CommenceTransport(point.transform.position + point.transportOffset, point.transform.rotation));
    }

    IEnumerator CommenceTransport(Vector3 toPosition, Quaternion toRotation)
    {
        while (blackCanvas.alpha < 1)
        {
            blackCanvas.alpha += Time.deltaTime * 10f;
            yield return null;
        }
        transform.position = toPosition;
        transform.rotation = toRotation;

        if (OnPlayerTeleported != null)
            OnPlayerTeleported(currentPoint);
        while (blackCanvas.alpha > 0)
        {
            blackCanvas.alpha -= Time.deltaTime * 10f;
            yield return null;
        }
    }
}
