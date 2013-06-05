function Deathball::skill_Deathball(%this,%scheduleobject,%user,%iteration)//and any other custom skill params
{
%player=$players.getObject(%user);
if (!isObject(%player.sprite))
{
$skillschedules.remove(%scheduleobject);
%scheduleobject.delete();
return;
}

setskillanimation(%player,%player.skillanimtype);//animtype: 0:selfcast 1:targetcast 2:melee 3:emote
//////////////////

%deathball=new Sprite()
{
Position=%player.sprite.Position;
Size=ScaleAssSizeVectorToCam(Deathball.deathballass);
Image="Deathball:dbForward";
class="class_deathball";
CollisionCallback="true";
SceneLayer=16;
health=100;
//DefaultDensity=0;
//DefaultRestitution=1;
};

%deathball.playAnimation("Deathball:dbForwardAnim");

if (!$view)
{
%deathball.GravityScale="0";
}

%deathball.SceneGroup=26;//26=world objects
%deathball.setCollisionGroups(0,1,25,26,30);//0=player 0, 1=player 2, 30=walls, 26=world objects, 25=npc's

DotsandCritsscene.add(%deathball);

%spritesize=%player.sprite.getSpriteSize();

%squaresize=ScaleAssSizeVectorToCam(Deathball.deathballass);
%radius=0;
if (%squaresize.X>%squaresize.Y){%radius=%squaresize.X/2;}else{%radius=%squaresize.Y/2;}

%deathball.createCircleCollisionShape(%radius);

if (%player.curdir==0)//up
{
%deathball.Position.Y+=(%squaresize.Y/2)+(%spritesize.Y/2);
}
else if (%player.curdir==1)//down
{
%deathball.Position.Y-=(%squaresize.Y/2)+(%spritesize.Y/2);
}
else if (%player.curdir==2)//left
{
%deathball.Position.X-=(%squaresize.X/2)+(%spritesize.X/2);
}
else if (%player.curdir==3)//right
{
%deathball.Position.X+=(%squaresize.X/2)+(%spritesize.X/2);
}

//////////////////
$skillschedules.remove(%scheduleobject);
%scheduleobject.delete();
%player.cancast=true;//use iteration to determine the number of seconds before player can cast again.
keycleanup(%user);
return;
//////////////////
}
