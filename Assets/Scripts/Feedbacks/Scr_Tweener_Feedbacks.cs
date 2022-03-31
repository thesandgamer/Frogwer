using UnityEngine;

public class Scr_Tweener_Feedbacks : MonoBehaviour
{
    public LeanTweenType inEaseType;
    public AnimationCurve curve;

    public AnimationCurve strechCurve;
    public AnimationCurve sizeUpAndZeroCurve;
    
    /// <summary>
    /// Pour étirer un objet
    /// </summary>
    /// <param name="scale at end"></param>
    /// <param name="time"></param>
    /// <param name="delayToStart"></param>
    public void Stretch(GameObject objetRef,Vector3 scale,float time,float delayToStart)
    {
        LeanTween.scale(objetRef, scale, time).setDelay(0).setEase(strechCurve);
        //LeanTween.scale(objetRef, new Vector3(1,1,1), time).setDelay(delayToStart).setEase(strechCurve);


        /*
        if (inEaseType == LeanTweenType.animationCurve)
        {
            LeanTween.scale(objetRef, scale, time).setDelay(delayToStart).setEase(strechCurve);
        }
        else
        {
            LeanTween.scale(objetRef, scale, time).setDelay(delayToStart).setEase(inEaseType);
        }
        */

    }
    public void NotGood(GameObject objetRef,Vector3 scale,float time)
    {
        LeanTween.scale(objetRef, scale, time).setEase(LeanTweenType.easeInBack);
        LeanTween.scale(objetRef, Vector3.one, time).setDelay(time).setEase(LeanTweenType.easeInBack);


    }
    
    
    public void SizeUpAndDispawn(GameObject objetRef,float time,float delayToStart)
    {
       //LeanTween.scale(objetRef, Vector3.zero, time).setDelay(delayToStart).setEase(sizeUpAndZeroCurve);
        LeanTween.scale(objetRef, Vector3.zero, time).setDelay(delayToStart).setEase(LeanTweenType.easeInBack);

    }

    public void Squash(GameObject objetRef, Vector3 scale, float time, float delayToStart)
    {
        LeanTween.scale(objetRef, scale, time).setDelay(0).setEase(strechCurve);
        LeanTween.scale(objetRef, new Vector3(1,1,1), time).setDelay(time).setEase(strechCurve);
    }


    public void PopUp(GameObject objetRef,Vector3 scale, float time, float delayToStart,LeanTweenType type)
    {
        LeanTween.scale(objetRef, scale, time).setDelay(time).setEase(type);

    }


}
