function snarebutt(%tonberry,%phase)
{
//echo(%tonberry SPC "snared butt");

if (%phase==0)//set listener phase
{

if (!%tonberry.listen4snare)
{
%tonberry.listen4snare=true;
}
else
{
%tonberry.listen4snare=false;
}

}
else if (%phase==1)
{

if (%tonberry.listen4snare)
{

%objlist=DotsandCritsscene.pickPoint(
%tonberry.curmousepos,
bit(0)|bit(1)|bit(25)|bit(26),"","oobb");//25=npc, 26=dynamic world object

if (getWordCount(%objlist)==0){return;}//make sure something got clicked on

%obj=getWord(%objlist,0);//get first object

if (%obj!=%tonberry.obj2snare)//new target
{
if (%tonberry.obj2snare.Class$="class_player")
{
%targplayer=$players.getObject(%tonberry.obj2snare.playerindex);

%targplayer.speed+=$normalplayerspeed;

restartmove(%targplayer);
}
else if (%tonberry.obj2snare.SceneGroup==25)//npcs
{

%tonberry.obj2snare.speed+=%tonberry.obj2snare.normalspeed;

}
cancel(%tonberry.schedule_snare);
%tonberry.schedule_snare=0;
}

%tonberry.obj2snare=%obj;

if (%tonberry.obj2snare.Class$="class_player")
{

%targplayer=$players.getObject(%tonberry.obj2snare.playerindex);

if (%targplayer.speed>0){%targplayer.speed-=$normalplayerspeed;}
if (%targplayer.speed<0){%targplayer.speed=0;}

restartmove(%targplayer);

}
else if (%tonberry.obj2snare.SceneGroup==25)//npcs
{

if (%tonberry.obj2snare.speed>0){%tonberry.obj2snare.speed-=%tonberry.obj2snare.normalspeed;}
if (%tonberry.obj2snare.speed<0){%tonberry.obj2snare.speed=0;}
%tonberry.obj2snare.cancelMoveTo();

}

//play cast animation

if (%tonberry.curdir==0)
{
%tonberry.playAnimation("SummonTonberry:anim_castup");
}
else if (%tonberry.curdir==1)
{
%tonberry.playAnimation("SummonTonberry:anim_castdown");
}
else if (%tonberry.curdir==2)
{
%tonberry.playAnimation("SummonTonberry:anim_castleft");
}
else if (%tonberry.curdir==3)
{
%tonberry.playAnimation("SummonTonberry:anim_castright");
}

//reschedule
%tonberry.snareiteration=0;

%tonberry.schedule_snare=schedule(1000,0,"snarebutt",%tonberry,2);//phase 2=update snare

%tonberry.listen4snare=false;
}

}
else if (%phase==2)
{

%tonberry.snareiteration++;

if (%tonberry.snareiteration>=10)
{
if (%tonberry.obj2snare.Class$="class_player")
{
%targplayer=$players.getObject(%tonberry.obj2snare.playerindex);

%targplayer.speed+=$normalplayerspeed;

restartmove(%targplayer);
}
else if (%tonberry.obj2snare.SceneGroup==25)//npcs
{

%tonberry.obj2snare.speed+=%tonberry.obj2snare.normalspeed;

}

cancel(%tonberry.schedule_snare);
%tonberry.schedule_snare=0;
%tonberry.obj2snare=0;
return;
}

if (%tonberry.obj2snare.Class$="class_player")
{

%targplayer=$players.getObject(%tonberry.obj2snare.playerindex);

if (%targplayer.speed>0){%targplayer.speed-=$normalplayerspeed;}
if (%targplayer.speed<0){%targplayer.speed=0;}

restartmove(%targplayer);

}
else if (%tonberry.obj2snare.SceneGroup==25)//npcs
{

if (%tonberry.obj2snare.speed>0){%tonberry.obj2snare.speed-=%tonberry.obj2snare.normalspeed;}
if (%tonberry.obj2snare.speed<0){%tonberry.obj2snare.speed=0;}
%tonberry.obj2snare.cancelMoveTo();

}

%tonberry.schedule_snare=schedule(1000,0,"snarebutt",%tonberry,2);//phase 2=update snare

}

}
