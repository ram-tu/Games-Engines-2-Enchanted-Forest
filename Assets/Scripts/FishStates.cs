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
    public override void Enter()
    {
        Debug.Log("I am now in the jump state");
        owner.GetComponent<FollowPath>().path = owner.GetComponent<FishJump>().jumpPath;
        owner.GetComponent<FollowPath>().isLooped = false;
        owner.GetComponent<FollowPath>().next = 0;
        owner.GetComponent<Boid>().maxSpeed = 3;
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
    }

}