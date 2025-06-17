using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class GazeManager : MonoBehaviour
{
    public event Action OnGazeSelection;
    // GPT
    public event Action OnGazeTelepor;

    public static GazeManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    [SerializeField] private GameObject gazeBarCanvas;
    [SerializeField] Image fillIndicator;
    [Tooltip("Time in seg")]
    [SerializeField] private float timeForSelection =2.5f;

    private float timeCounter;
    private float timeProggres;
    private bool runTimer;
    private bool runTeleporTimer;
    void Start()
    {
        gazeBarCanvas.SetActive(false);
        fillIndicator.fillAmount = Normalise();
    }


    public void Update()
    {
        if (runTimer)
        {
            timeProggres += Time.deltaTime;
            AddValue(timeProggres);
        }
        if (runTeleporTimer)
        {
            timeProggres += Time.deltaTime;
            AddTeleporValue(timeProggres);
        }
    }
    public void SetUpGaze(float timeForSelection) 
    {
        this.timeForSelection = timeForSelection;
    }
    public void StartGazeSelection()
    {
        gazeBarCanvas.SetActive(true);
        runTimer = true;
        timeProggres = 0;
    }
    public void StartGazeTelepor()
    {
        gazeBarCanvas.SetActive(true);
        runTeleporTimer = true;
        timeProggres = 0;
    }

    public void CancelGazeSelection()
    {
        gazeBarCanvas.SetActive(false);
        runTimer = false;
        timeProggres = 0;
        timeCounter = 0;
    }

    private void AddValue(float val) 
    {
        timeCounter = val;
        if (timeCounter >= timeForSelection)
        {
            timeCounter = 0;
            runTimer = false;
            OnGazeSelection?.Invoke();
        }

        fillIndicator.fillAmount = Normalise();
    }
    private void AddTeleporValue(float val) 
    {
        timeCounter = val;
        if (timeCounter >= timeForSelection)
        {
            timeCounter = 0;
            runTeleporTimer = false;
            OnGazeTelepor?.Invoke();
        }

        fillIndicator.fillAmount = Normalise();
    }
    private float Normalise() 
    {
        return (float)timeCounter / timeForSelection;
    }
}
