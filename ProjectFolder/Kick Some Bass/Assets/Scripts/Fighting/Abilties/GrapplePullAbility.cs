using UnityEngine;
using UnityEditor;
using AbilitySpace;
using UnityEngine.Assertions;
using System.Collections;

public class GrapplePullAbility : IFightAbility, IUtilityAI
{
    bool m_veto = false;
    //A cycle in this case is basiclly going from Begin to Stopped state after achiving the goal of the abilty
    bool cycledFinished=true;
    public override void PerformAction(IFighterCharacter fighter, AbilityState requestedActionState)
    {
        Debug.Log(GetAbilityName());

        Assert.IsNotNull(fighter);
        Assert.IsNotNull(fighter.GetComponent<LineRenderer>());
        StartCoroutine(SwitchStateWithDelay(AbilityState.Stopped, 2));
        
        //Keypress up for this ability will reset the ability
        if (requestedActionState == AbilityState.Stopped)
        {
            LineRenderer lineRenderer = fighter.GetComponent<LineRenderer>();
            lineRenderer.positionCount = 0;

            cycledFinished = true;
            m_state = AbilityState.Stopped;
            return;
        }

        if (m_state == AbilityState.Stopped)
        {
            //if still in the previous cycel with state set to stopped(timer),finish 
            if(!cycledFinished)
            {
                //dont execute anything and wait for key to be released in this case
                return;
            }

            m_state = AbilityState.running;

        }

        if (m_state == AbilityState.running)
        {
            LineRenderer lineRenderer = fighter.GetComponent<LineRenderer>();

            lineRenderer.positionCount = 2;

            lineRenderer.SetPosition(0, fighter.transform.position + (fighter.transform.forward*.3f) + fighter.transform.up + fighter.transform.right);
            lineRenderer.SetPosition(1, fighter.GetOpponent().transform.position + fighter.GetOpponent().transform.up + fighter.GetOpponent().transform.forward);

            Vector3 directionFromToOppnent = (fighter.transform.position - fighter.GetOpponent().transform.position);
            fighter.GetOpponent().GetComponent<Rigidbody>().AddForce(directionFromToOppnent * Time.deltaTime*200);
            

            if(directionFromToOppnent.sqrMagnitude<5*5)
            {
                lineRenderer.positionCount = 0;
                m_state = AbilityState.Stopped;
            }
        }

    }


    public override void Animation(IFighterCharacter fighter)
    {
    }

    public override string GetAbilityName()
    {
        return "GrapplePull";
    }

    public float EvaulateAbilityUtility(IFighterCharacter Fighter)
    {
        return 0;
    }

    public bool GetVeto() { return m_veto; }

    public override IFightAbility GetInstance(GameObject Owner)
    {
        return Owner.AddComponent<ShootAbility>();
    }
}
