function playerjump(%player,%phase)
{
if (!%phase)
{
%player.sprite.setGravityScale(0);
%player.sprite.setLinearVelocityY(%player.speed);
}
else
{
%player.sprite.setGravityScale(1);
}
}

function moveplayerup(%playerindex)
{
%player=$players.getObject(%playerindex);
if (isObject(%player.sprite))
{
if (!$view)
{
//if (!alxIsPlaying(%player.playerfootsteps)){%player.playerfootsteps=alxPlay(audio_playerfootsteps);}
%player.sprite.setLinearDamping(0);
%player.sprite.setLinearVelocityY(%player.speed);
%player.keysdown[0]=true;
%player.curdir=0;
}
else if (%player.canjump)
{
%player.canjump=false;
//if (!alxIsPlaying(%player.playerfootsteps)){%player.playerfootsteps=alxPlay(audio_playerfootsteps);}
if (%player.schedule_jumpfall)
{
cancel(%player.schedule_jumpfall);
}
playerjump(%player,0);
%player.schedule_jumpfall=schedule(1000,0,"playerjump",%player,1);
%player.keysdown[0]=true;
%player.curdir=0;
}
keycleanup(%playerindex);
//updategrabpos(%playerindex,%player.objgrabbed);
}
}
function moveplayerupstop(%playerindex)
{
%player=$players.getObject(%playerindex);
if (isObject(%player.sprite))
{
%player.keysdown[0]=false;
if (%player.keysdown[1]){%player.curdir=1;}
else if (%player.keysdown[2]){%player.curdir=2;}
else if (%player.keysdown[3]){%player.curdir=3;}
keycleanup(%playerindex);
//updategrabpos(%playerindex,%player.objgrabbed);
}
}

function moveplayerdown(%playerindex)
{
%player=$players.getObject(%playerindex);
if (isObject(%player.sprite))
{
//if (!alxIsPlaying(%player.playerfootsteps)){%player.playerfootsteps=alxPlay(audio_playerfootsteps);}
%player.sprite.setLinearDamping(0);
%player.sprite.setLinearVelocityY(-%player.speed);
%player.keysdown[1]=true;
%player.curdir=1;
keycleanup(%playerindex);
//updategrabpos(%playerindex,%player.objgrabbed);
}
}
function moveplayerdownstop(%playerindex)
{
%player=$players.getObject(%playerindex);
if (isObject(%player.sprite))
{
%player.keysdown[1]=false;
if (%player.keysdown[0]){%player.curdir=0;}
else if (%player.keysdown[2]){%player.curdir=2;}
else if (%player.keysdown[3]){%player.curdir=3;}
keycleanup(%playerindex);
//updategrabpos(%playerindex,%player.objgrabbed);
}
}

function moveplayerleft(%playerindex)
{
%player=$players.getObject(%playerindex);
if (isObject(%player.sprite))
{
//if (!alxIsPlaying(%player.playerfootsteps)){%player.playerfootsteps=alxPlay(audio_playerfootsteps);}
%player.sprite.setLinearDamping(0);
%player.sprite.setLinearVelocityX(-%player.speed);
%player.keysdown[2]=true;
%player.curdir=2;
keycleanup(%playerindex);
}
}
function moveplayerleftstop(%playerindex)
{
%player=$players.getObject(%playerindex);
if (isObject(%player.sprite))
{
%player.keysdown[2]=false;
if (%player.keysdown[0]){%player.curdir=0;}
else if (%player.keysdown[1]){%player.curdir=1;}
else if (%player.keysdown[3]){%player.curdir=3;}
keycleanup(%playerindex);
//updategrabpos(%playerindex,%player.objgrabbed);
}
}

function moveplayerright(%playerindex)
{
%player=$players.getObject(%playerindex);
if (isObject(%player.sprite))
{
//if (!alxIsPlaying(%player.playerfootsteps)){%player.playerfootsteps=alxPlay(audio_playerfootsteps);}
%player.sprite.setLinearDamping(0);
%player.sprite.setLinearVelocityX(%player.speed);
%player.keysdown[3]=true;
%player.curdir=3;
keycleanup(%playerindex);
//updategrabpos(%player.objgrabbed);
}
}
function moveplayerrightstop(%playerindex)
{
%player=$players.getObject(%playerindex);
if (isObject(%player.sprite))
{
%player.keysdown[3]=false;
if (%player.keysdown[0]){%player.curdir=0;}
else if (%player.keysdown[1]){%player.curdir=1;}
else if (%player.keysdown[2]){%player.curdir=2;}
keycleanup(%playerindex);
//updategrabpos(%playerindex,%player.objgrabbed);
}
}
