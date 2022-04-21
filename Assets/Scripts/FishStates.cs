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
        Debug.Log("I am now in the swim state");

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
        
    }
}

public class JumpState : State
{
    private int currentWaypoint = 0;
    public override void Enter()
    {
        Debug.Log("I am now in the jump state");
        owner.GetComponent<FollowPath>().path = owner.GetComponent<FishJump>().jumpPath;
        owner.GetComponent<FollowPath>().isLooped = false;
        currentWaypoint = owner.GetComponent<FollowPath>().next;
        owner.GetComponent<FollowPath>().next = 0;
        owner.GetComponent<Boid>().maxSpeed = owner.GetComponent<Boid>().maxSpeed + 2f;
        //owner.GetComponent<Pursue>().target = owner.GetComponent<Fighter>().enemy.GetComponent<Boid>();
        //owner.GetComponent<Pursue>().enabled = true;
    }

    public override void Think()
    {
        if (owner.GetComponent<FollowPath>().IsLast())
        {
            owner.ChangeState(new SwimState());
        }
    }

    public override void Exit()
    {
        owner.GetComponent<FishJump>().shouldJump = false;
        owner.GetComponent<FollowPath>().path = owner.GetComponent<FishJump>().originalPath;
        owner.GetComponent<FollowPath>().next = currentWaypoint;
        owner.GetComponent<Boid>().maxSpeed = owner.GetComponent<Boid>().maxSpeed - 1.5f;
        owner.GetComponent<FollowPath>().isLooped = true;
    }

}