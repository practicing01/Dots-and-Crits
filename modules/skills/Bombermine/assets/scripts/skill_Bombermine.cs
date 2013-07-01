function Bombermine::skill_Bombermine(%this,%scheduleobject,%user,%iteration)//and any other custom skill params
{
%player=$players.getObject(%user);
if (!isObject(%player.sprite))
{
$skillschedules.remove(%scheduleobject);
%scheduleobject.delete();
return;
}

if (%iteration==0)
{

setskillanimation(%player,%player.skillanimtype);//animtype: 0:selfcast 1:targetcast 2:melee 3:emote
//////////////////

%ass=Bombermine.Bombermineass;
%img="Bombermine:image_Bombermine";

////////////////////////////////////////////////////////////////////////////
//set this Bombermine's sprite
%Bomberminesprite=new Sprite()
{
Position=%player.sprite.Position;
Size=ScaleAssSizeVectorToCam(%ass);
Image=%img;
class="class_Bombermine";
parenthandle=0;
CollisionCallback="true";
SceneLayer=16;
health=100;
};

%Bomberminesprite.playAnimation("Bombermine:anim_idle");

if (!%player.sprite.SceneGroup)//player 0 casted
{
%Bomberminesprite.SceneGroup=28;//player 0 Bombermines
%Bomberminesprite.setCollisionGroups(1,25,26,27,29,30);//1=player 2, 29=player 2 Bombermines, 30=walls, 26=world objects, 27=portals
}
else//player 1 casted
{
%Bomberminesprite.SceneGroup=29;//player 1 Bombermines
%Bomberminesprite.setCollisionGroups(0,25,26,27,28,30);//0=player 1, 28=player 1 Bombermines, 30=walls, 26=world objects, 27=portals
}

DotsandCritsscene.add(%Bomberminesprite);
%Bomberminesprite.createPolygonBoxCollisionShape(ScaleAssSizeVectorToCam(%ass));
//////////////////////////////////////////////////////////////////////////////

%spritesize=%player.sprite.getSpriteSize();

if (%player.curdir==0)//up
{
////////////
//set position based on custom sprite Bombermine origins
%dirset=%player.projectileorigindirset.getObject(0);
%origin=%dirset.getObject(getRandom(0,%dirset.getCount()-1));
%Bomberminesprite.Position.X+=%origin.x;
%Bomberminesprite.Position.Y+=%origin.y;
///////////
}
else if (%player.curdir==1)//down
{
////////////
//set position based on custom sprite Bombermine origins
%dirset=%player.projectileorigindirset.getObject(1);
%origin=%dirset.getObject(getRandom(0,%dirset.getCount()-1));
%Bomberminesprite.Position.X+=%origin.x;
%Bomberminesprite.Position.Y+=%origin.y;
///////////
}
else if (%player.curdir==2)//left
{
////////////
//set position based on custom sprite Bombermine origins
%dirset=%player.projectileorigindirset.getObject(2);
%origin=%dirset.getObject(getRandom(0,%dirset.getCount()-1));
%Bomberminesprite.Position.X+=%origin.x;
%Bomberminesprite.Position.Y+=%origin.y;
///////////
}
else if (%player.curdir==3)//right
{
////////////
//set position based on custom sprite Bombermine origins
%dirset=%player.projectileorigindirset.getObject(3);
%origin=%dirset.getObject(getRandom(0,%dirset.getCount()-1));
%Bomberminesprite.Position.X+=%origin.x;
%Bomberminesprite.Position.Y+=%origin.y;
///////////
}

}//end iteration 0
else if (%iteration==1)//give it at least 1 second of casting animation
{
%player.cancast=true;//use iteration to determine the number of seconds before player can cast again.
keycleanup(%user);
$skillschedules.remove(%scheduleobject);
%scheduleobject.delete();
return;
}

//////////////////
%iteration++;
%scheduleobject.schedulehandle=schedule(1000,0,"Bombermine::skill_Bombermine",%this,%scheduleobject,%user,%iteration);
//////////////////
}
