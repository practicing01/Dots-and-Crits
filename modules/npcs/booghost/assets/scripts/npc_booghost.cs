function booghost::create(%this)
{
echo("created booghost");
}

function booghost::destroy(%this)
{
echo("freed booghost");
}

function class_booghost::updatehealth(%this)
{
if (%this.health<=0){%this.safeDelete();}
}

function class_booghost::onCollision(%this,%object,%collisionDetails)
{
if (%this.health<=0){return;}

if (%object.class$="class_player")
{
%player=$players.getObject(%object.playerindex);
%player.health-=1;
$levelmoduleid.ScopeSet.healthdisplay(%object.playerindex,%player.health);
}
else if (%object.SceneGroup==25)//npc's
{
if (%object.class!$="class_booghost")
{
if (%object.health>0)
{
%object.health-=1;
%object.updatehealth();
}
}
}

}

function class_booghost::booghostai(%this)
{//temporary ai
if (!isObject(%this)){return;}

if (%this.target==-1)//no target, acquire
{
for (%x=0;%x<$numofplayers;%x++)
{
%player=$players.getObject(%x);
if (!isObject(%player.sprite)){continue;}
if (Vector2Distance(%this.Position,%player.sprite.Position)<=Vector2Distance("0 0",ScaleVectorToCam($resolution.X/2 SPC $resolution.Y/2)))
{
%this.target=%player.sprite;
break;
}
}
}

if (!isObject(%this.target))
{

%this.target=-1;

}
else
{
if (Vector2Distance(%this.Position,%this.target.Position)>Vector2Distance("0 0",ScaleVectorToCam($resolution.X/2 SPC $resolution.Y/2)))
{%this.target=-1;}
else
{

%xdist=mAbs(%this.Position.X-%this.target.Position.X);
%ydist=mAbs(%this.Position.Y-%this.target.Position.Y);
if (%xdist>=%ydist)
{
if (%this.Position.X<=%this.target.Position.X)
{
%this.curdir=3;
%this.FlipX=true;
}
else
{
%this.curdir=2;
%this.FlipX=false;
}
}
else
{
if (%this.Position.Y<=%this.target.Position.Y)
{
%this.curdir=0;
}
else
{
%this.curdir=1;
}
}

%booscared=false;

if (%this.target.class!$="class_player")
{
if (%this.curdir==0)
{
if (%this.target.curdir==1){%booscared=true;}
}
else if (%this.curdir==1)
{
if (%this.target.curdir==0){%booscared=true;}
}
else if (%this.curdir==2)
{
if (%this.target.curdir==3){%booscared=true;}
}
else if (%this.curdir==3)
{
if (%this.target.curdir==2){%booscared=true;}
}
}
else
{
%targetplayer=$players.getObject(%this.target.playerindex);
if (%this.curdir==0)
{
if (%targetplayer.curdir==1){%booscared=true;}
}
else if (%this.curdir==1)
{
if (%targetplayer.curdir==0){%booscared=true;}
}
else if (%this.curdir==2)
{
if (%targetplayer.curdir==3){%booscared=true;}
}
else if (%this.curdir==3)
{
if (%targetplayer.curdir==2){%booscared=true;}
}
}

if (!%booscared)
{
if (%this.canscream){%audio_boo=alxPlay("booghost:audio_boo");%this.canscream=false;}
%this.Frame=1;
if (%this.speed!=0)
{
%this.moveTo(%this.target.Position,%this.speed,true,false);
}
}
else
{
%this.canscream=true;
%this.cancelMoveTo(true);
%this.Frame=0;
}

}
}

%this.aischedule=schedule(1000,0,"class_booghost::booghostai",%this);
}

//every npc class has an initialize function
//that gets called onlevelload
function class_booghost::initialize(%this)
{
%this.health=100;
%this.target=-1;
%this.curdir=0;//0=up,1=down,2=left,3=right
%this.normalspeed=2.5;
%this.speed=2.5;
%this.canscream=true;
%this.aischedule=schedule(1000,0,"class_booghost::booghostai",%this);
}

exec("./loadnpc.cs");
