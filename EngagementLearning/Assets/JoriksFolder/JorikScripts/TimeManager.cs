using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Timers;
using TMPro;

public class TimeManager : MonoBehaviour
{

    public TMP_Text timeScreen;
    public TMP_Text DateScreen;
    public AudioSource Audio;

    public AudioClip WinAudio;
    public AudioClip LoseAudio;
    public AudioClip AmbulanceAudio;

    public bool CallAmbulance= false;
    public bool administerEpiPen = false;

    Timer mytimer = new Timer(60000);
    bool Startlevel = true;

    public UIManager UIScreens;

    protected DateTime mytime = new DateTime(1, 1, 1, 11, 55, 00);
    // Start is called before the first frame update
    void Start()
    {
        SetDate();
        SetTime();
        if (Startlevel)
        {
            mytimer.Start();
            mytimer.Elapsed += OnTimedEvent;
        }
        
    }
    private void Update()
    {
        
        SetTime();
        if (administerEpiPen)
        {
            UIScreens.SavedPerson();
            Audio.clip = WinAudio;
            Audio.Play();
        }
        else if (mytime.Hour == 12)
        {
            if (CallAmbulance)
            {
                UIScreens.FailedChallenge();
                Audio.clip = AmbulanceAudio;
                Audio.Play();
            }
            else
            {
                Audio.clip = LoseAudio;
                Audio.Play();
            }
                

           

        }
    }
    private void OnTimedEvent(System.Object source, ElapsedEventArgs e)
    {
        mytime = mytime.AddMinutes(1);
    }
    private void SetTime()
    { 
        timeScreen.text = mytime.Hour.ToString()+ ":" + mytime.Minute.ToString();
    }
    private void SetDate()
    {
        DateScreen.text = DateTime.Now.DayOfWeek.ToString();
        switch (DateTime.Now.Month)
        {
            case 1:
                DateScreen.text = DateScreen.text + " Januari ";
                break;
            case 2:
                DateScreen.text = DateScreen.text + " Februari ";
                break;
            case 3:
                DateScreen.text = DateScreen.text + " March ";
                break;
            case 4:
                DateScreen.text = DateScreen.text + " April ";
                break;
            case 5:
                DateScreen.text = DateScreen.text + " May ";
                break;
            case 6:
                DateScreen.text = DateScreen.text + " June ";
                break;
            case 7:
                DateScreen.text = DateScreen.text + " July ";
                break;
            case 8:
                DateScreen.text = DateScreen.text + " August ";
                break;
            case 9:
                DateScreen.text = DateScreen.text + " September ";
                break;
            case 10:
                DateScreen.text = DateScreen.text + " Oktober ";
                break;
            case 11:
                DateScreen.text = DateScreen.text + " November ";
                break;
            case 12:
                DateScreen.text = DateScreen.text + " December ";
                break;
        }
        DateScreen.text= DateScreen.text + DateTime.Now.Day.ToString();
    }

    //TESTFUNCTIONS DELETE AFTER ALPHA
    public void WinGame()
    {
        CallAmbulance = true;
        administerEpiPen = true;
    }


    public void LoseGame()
    {
        mytime.AddMinutes(10);
    }

    public void CalledAmbulandeEnd()
    {
        CallAmbulance = true;
        mytime.AddMinutes(10);
    }

}
