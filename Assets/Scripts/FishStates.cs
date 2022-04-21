using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class SwimState : State
{
    public override void Enter()
    {
        owner.GetComponent<FollowPath>().enabled = true;
        owner.GetComponent<FishJump>().enabled = true;

    }

    public override void Think()
    {
        if (owner.GetComponent<FishJump>().shouldJump)
        {
            owner.ChangeState(new JumpState());
        }
    }
    
    public override void Exit()
    {
        owner.GetComponent<FollowPath>().enabled = false;
    }
}

public class JumpState : State
{
    public override void Enter()
    {
        Debug.Log("I am now in the jump state");
        owner.GetComponent<FollowPath>().path.waypoints = owner.GetComponent<FishJump>().waypoints;
        owner.GetComponent<FollowPath>().isLooped = false;
        //owner.GetComponent<Pursue>().target = owner.GetComponent<Fighter>().enemy.GetComponent<Boid>();
        //owner.GetComponent<Pursue>().enabled = true;
    }

    public override void Think()
    {
        
        /*Vector3 toEnemy = owner.GetComponent<Fighter>().enemy.transform.position - owner.transform.position; 
        if (Vector3.Angle(owner.transform.forward, toEnemy) < 45 && toEnemy.magnitude < 20)
        {
            GameObject bullet = GameObject.Instantiate(owner.GetComponent<Fighter>().bullet, owner.transform.position + owner.transform.forward * 2, owner.transform.rotation);
            owner.GetComponent<Fighter>().ammo --;        
        }
        if (Vector3.Distance(
            owner.GetComponent<Fighter>().enemy.transform.position,
            owner.transform.position) > 30)
        {
            owner.ChangeState(new PatrolState());
        }*/
        if(owner.GetComponent<FollowPath>().IsLast())
            owner.ChangeState(new SwimState());
    }

    public override void Exit()
    {
        owner.GetComponent<FishJump>().shouldJump = false;
    }

}