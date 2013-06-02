function keycleanup(%playerindex)
{
%player=$players.getObject(%playerindex);
if (isObject(%player.sprite))
{

%wasdup=0;
if (!%player.keysdown[0]&&!%player.keysdown[1])
{if (!$view){%player.sprite.setLinearVelocityY(0);}%wasdup++;}
if (!%player.keysdown[2]&&!%player.keysdown[3])
{%player.sprite.setLinearVelocityX(0);%wasdup++;}

if (%wasdup==1||%wasdup==0)
{
if (%player.curdir==0)
{
if (%player.cancast)
{
%player.sprite.setSpriteAnimation(%player.anim_run_up);
}
else
{
setskillanimation(%player,%player.skillanimtype);
}
}
else if (%player.curdir==1)
{
if (%player.cancast)
{
%player.sprite.setSpriteAnimation(%player.anim_run_down);
}
else
{
setskillanimation(%player,%player.skillanimtype);
}
}
else if (%player.curdir==2)
{
if (%player.cancast)
{
%player.sprite.setSpriteAnimation(%player.anim_run_left);
}
else
{
setskillanimation(%player,%player.skillanimtype);
}
}
else if (%player.curdir==3)
{
if (%player.cancast)
{
%player.sprite.setSpriteAnimation(%player.anim_run_right);
}
else
{
setskillanimation(%player,%player.skillanimtype);
}
}
}
else if (%wasdup==2)
{
if (%player.curdir==0)
{
if (%player.cancast)
{
%player.sprite.setSpriteAnimation(%player.anim_stand_up);
}
else
{
setskillanimation(%player,%player.skillanimtype);
}
}
else if (%player.curdir==1)
{
if (%player.cancast)
{
%player.sprite.setSpriteAnimation(%player.anim_stand_down);
}
else
{
setskillanimation(%player,%player.skillanimtype);
}
}
else if (%player.curdir==2)
{
if (%player.cancast)
{
%player.sprite.setSpriteAnimation(%player.anim_stand_left);
}
else
{
setskillanimation(%player,%player.skillanimtype);
}
}
else if (%player.curdir==3)
{
if (%player.cancast)
{
%player.sprite.setSpriteAnimation(%player.anim_stand_right);
}
else
{
setskillanimation(%player,%player.skillanimtype);
}
}
//alxStop(%player.playerfootsteps);
%player.sprite.setLinearDamping(%player.linear_damping);
}//end wasdup
if ($view)
{
if (!%player.keysdown[0]&&%player.schedule_jumpfall)
{
cancel(%player.schedule_jumpfall);
%player.schedule_jumpfall=schedule(0,0,"playerjump",%player,1);
}
}

rotatecompositesprites(%playerindex);
callskilltransform(%playerindex);

}
}//end cleanup
