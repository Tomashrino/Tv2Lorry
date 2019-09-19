using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TransportPoint : MonoBehaviour
{
    public Color normalColor = new Color(0.8f, 0.8f, 0.8f);
    public Color highlightColor = new Color(0.9f, 0.5f, 0.5f);
    public Color targetHighlightColor = new Color(0.2f, 0.9f, 0.2f);
    public Vector3 transportOffset = new Vector3(0, 1f, 0);
    public bool useGaze = false;
    [Range(1f, 5f)]
    public float gazeTime = 2f;

    LineRenderer lineRenderer;
    ParticleSystemRenderer particle;
    Renderer mRenderer;
    bool isGazedAt = false;
    private float currentGazeTimer = 0f;

    private void Start()
    {
        particle = GetComponent<ParticleSystemRenderer>();
        lineRenderer = GetComponentInChildren<LineRenderer>();

        mRenderer = GetComponent<Renderer>();
        SetGazedAt(false);
        Player.Instance.OnPlayerTeleported += OnPlayerTeleported;

        EventTrigger trigger = gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry.callback.AddListener((data) => { this.SetGazedAt(true); });
        trigger.triggers.Add(entry);

        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerExit;
        entry.callback.AddListener((data) => { this.SetGazedAt(false); });
        trigger.triggers.Add(entry);


        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener((data) => { this.TransportToPoint(); });
        trigger.triggers.Add(entry);
    }


    public void SetGazedAt(bool gazedAt)
    {
        isGazedAt = gazedAt;
        if (particle != null)
        {
            if (gazedAt)
                particle.material.SetColor("_TintColor", highlightColor);
            else
                particle.material.SetColor("_TintColor", normalColor);
        }
        else
        {
            if (gazedAt)
            {
                mRenderer.material.color = highlightColor;
                lineRenderer.startColor = highlightColor;
            }
            else
            {
                mRenderer.material.color = normalColor;
                lineRenderer.startColor = normalColor;
            }
        }
    }

    public void TransportToPoint()
    {
        Player.Instance.Transport(this);
    }

    void OnPlayerTeleported(TransportPoint point)
    {
        SetGazedAt(false);
        if (point == this)
            gameObject.SetActive(false);
        else
            gameObject.SetActive(true);
    }

    private void Update()
    {
        if (useGaze && isGazedAt)
        {
            currentGazeTimer += Time.deltaTime;
            mRenderer.material.color = Color.Lerp(highlightColor, targetHighlightColor, (currentGazeTimer / gazeTime));
            lineRenderer.startColor = Color.Lerp(highlightColor, targetHighlightColor, (currentGazeTimer / gazeTime));

            if (currentGazeTimer >= gazeTime)
            {
                currentGazeTimer = 0f;
                TransportToPoint();
            }
        }
        else
        {
            currentGazeTimer = 0f;
        }
    }

}
