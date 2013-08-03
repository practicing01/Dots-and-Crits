function class_bahamut::onCollision(%this,%object,%collisionDetails)
{
if (%object.class$="class_player")
{
%player=$players.getObject(%object.playerindex);
%player.health-=10;
$levelmoduleid.ScopeSet.healthdisplay(%object.playerindex,%player.health);
}
else if (%object.SceneGroup==25||%object.SceneGroup==26)//npc's, dynamic world objects
{
if (%object.health>0)
{
%object.health-=10;
%object.updatehealth();
}
}
}

function class_bahamut::updatehealth(%this)
{
if (%this.health<=0)
{
cancel(%this.aischedule);
%this.safeDelete();
}
}

function bahamutai(%bahamut)
{//temporary ai
if (!isObject(%bahamut)){return;}

if (%bahamut.target==-1)//no target, acquire
{
for (%x=0;%x<$numofplayers;%x++)
{
%player=$players.getObject(%x);
if (!isObject(%player.sprite)){continue;}
if (Vector2Distance(%bahamut.Position,%player.sprite.Position)<=Vector2Distance("0 0",ScaleVectorToCam($resolution.X/2 SPC $resolution.Y/2)))
{
%bahamut.target=%player.sprite;
break;
}
}
}

if (!isObject(%bahamut.target)){%bahamut.target=-1;}
else
{
if (Vector2Distance(%bahamut.Position,%bahamut.target.Position)>Vector2Distance("0 0",ScaleVectorToCam($resolution.X/2 SPC $resolution.Y/2)))
{%bahamut.target=-1;}
else
{
%bahamut.moveTo(%bahamut.target.Position,%bahamut.speed,true,false);
}
}

%bahamut.aischedule=schedule(1000,0,"bahamutai",%bahamut);
}

//every npc class has an initialize function
//that gets called onlevelload
function class_bahamut::initialize(%this)
{
%this.health=100;
%this.target=-1;
%this.aischedule=schedule(1000,0,"bahamutai",%this);
%this.speed=5;
%this.normalspeed=5;
}
