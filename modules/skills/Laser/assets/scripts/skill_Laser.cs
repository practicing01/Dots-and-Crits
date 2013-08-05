function Laser::skill_Laser(%this,%scheduleobject,%user,%iteration)//and any other custom skill params
{
%player=$players.getObject(%user);
if (!isObject(%player.sprite))
{
$skillschedules.remove(%scheduleobject);
%scheduleobject.delete();
return;
}

//if on turn off and return
%customfieldobj=Laser.customplayerfields.getObject(%user);

if (%customfieldobj.firing)
{
%customfieldobj.firing=false;
%customfieldobj.spritehandle.safeDelete();
cancel(%customfieldobj.schedulehandle);

%player.cancast=true;//use iteration to determine the number of seconds before player can cast again.
keycleanup(%user);

$skillschedules.remove(%scheduleobject);
%scheduleobject.delete();
return;
}

setskillanimation(%player,%player.skillanimtype);//animtype: 0:selfcast 1:targetcast 2:melee 3:emote

////////////////////////////////////////////////////////////////////////////
//get target

%dest=%player.sprite.Position;

if (%player.curdir==0)//up
{
%dest.Y+=ScaleVectorToCam("0" SPC $resolution.Y).Y;
}
else if (%player.curdir==1)//down
{
%dest.Y-=ScaleVectorToCam("0" SPC $resolution.Y).Y;
}
else if (%player.curdir==2)//left
{
%dest.X-=ScaleVectorToCam($resolution.X SPC "0").X;
}
else if (%player.curdir==3)//right
{
%dest.X+=ScaleVectorToCam($resolution.X SPC "0").X;
}

%objlist=DotsandCritsscene.pickRayCollision(%player.sprite.Position,%dest,
bit(!%user)|bit(25)|bit(26)|bit(30),"");//26=world objects, 25=npc's, 30=walls

//get first objects position
%closestid=getWord(%objlist,0);
%closestpos=getWord(%objlist,1) SPC getWord(%objlist,2);

//string is divided into 7-string chunks, since we got the first (0-6 pieces) we start at the second chunk (7-13)
for (%x=7;%x<getWordCount(%objlist);%x+=7)
{

%pos=getWord(%objlist,%x+1) SPC getWord(%objlist,%x+2);//0 piece is id, 1 and 2 are x,y collision point

if (Vector2Distance(%player.sprite.Position,%pos)
<
Vector2Distance(%player.sprite.Position,%closestpos))
{

%closestid=getWord(%objlist,%x);
%closestpos=%pos;
echo(%closestid SPC %closestpos);
}

}

if (!isObject(%closestid))
{
%player.cancast=true;//use iteration to determine the number of seconds before player can cast again.
keycleanup(%user);

$skillschedules.remove(%scheduleobject);
%scheduleobject.delete();
return;
}
//////////////////
//create sprite for casting animation, it schedules a self-deletion
//the sprite doesn't have to attach to the character, it can be a regular sprite that stays at the casting spot
%spriteid=%player.sprite.addSprite();

%idobj=new ScriptObject()
{
spriteid=%spriteid;
rotates=true;
name="Laser";
centeroffset=0;
};
%player.mountedspriteids.add(%idobj);

%ass=0;
if ($view==0)
{
%ass=Laser.top_explosionass;
%player.sprite.setSpriteAnimation("Laser:anim_topdown_explosion");
}
else
{
%ass=Laser.side_explosionass;
%player.sprite.setSpriteAnimation("Laser:anim_sideview_explosion");
}

%player.sprite.setSpriteLocalPosition(0,0);
%player.sprite.setSpriteSize(ScaleAssSizeVectorToCam(%ass));
%player.sprite.SetSpriteDepth(0);//in front of character
%player.sprite.setSpriteBlendAlpha(0.1);
%player.sprite.selectSpriteId(%player.spriteid);//important so anim-setting functions can work
schedule(1000,0,"removespritefromcomposite",%player,%spriteid);
rotatecompositesprites(%user);
//////////////////
%img=0;
if ($view==0)
{
%ass=Laser.top_Laserass;
%img="Laser:image_topdown_Laser";
}
else
{
%ass=Laser.side_Laserass;
%img="Laser:image_sideview_Laser";
}

///////////////////////////////////////////////////////////////////////////
//set this Laser's sprite
%Lasersprite=new Sprite()
{
Position=%player.sprite.Position;
Size=ScaleAssSizeVectorToCam(%ass);//have to rescale collision shape after rescaling sprite
Image=%img;
class="class_Laser";
parenthandle=0;
CollisionCallback="true";
SceneLayer=16;
GravityScale="0";
};
%Lasersprite.setBlendAlpha(0.25);

if (!%player.sprite.SceneGroup)//player 0 casted
{
%Lasersprite.SceneGroup=28;//player 0 Lasers
%Lasersprite.setCollisionGroups(1,25,26,29,30);//1=player 2, 29=player 2 Lasers, 30=walls, 26=world objects
}
else//player 1 casted
{
%Lasersprite.SceneGroup=29;//player 1 Lasers
%Lasersprite.setCollisionGroups(0,25,26,28,30);//0=player 1, 28=player 1 Lasers, 30=walls, 26=world objects
}

DotsandCritsscene.add(%Lasersprite);
//////////////////////////////////////////////////////////////////////////////

%origin=0;
%originindex=0;

if (%player.curdir==0)//up
{
////////////
//set position based on custom sprite Laser origins
%dirset=%player.projectileorigindirset.getObject(0);
%originindex=getRandom(0,%dirset.getCount()-1);
%origin=%dirset.getObject(%originindex);
///////////
}
else if (%player.curdir==1)//down
{
////////////
//set position based on custom sprite Laser origins
%dirset=%player.projectileorigindirset.getObject(1);
%originindex=getRandom(0,%dirset.getCount()-1);
%origin=%dirset.getObject(%originindex);
///////////
}
else if (%player.curdir==2)//left
{
////////////
//set position based on custom sprite Laser origins
%dirset=%player.projectileorigindirset.getObject(2);
%originindex=getRandom(0,%dirset.getCount()-1);
%origin=%dirset.getObject(%originindex);
///////////
}
else if (%player.curdir==3)//right
{
////////////
//set position based on custom sprite Laser origins
%dirset=%player.projectileorigindirset.getObject(3);
%originindex=getRandom(0,%dirset.getCount()-1);
%origin=%dirset.getObject(%originindex);
///////////
}

%customfieldobj.size=%Lasersprite.Size;

%Lasersprite.Position.X=%player.sprite.Position.X+%origin.x;
%Lasersprite.Position.Y=%player.sprite.Position.Y+%origin.y;

//scale y and set angle
%Lasersprite.Size.Y+=Vector2Distance(%Lasersprite.Position,%closestpos);
%Lasersprite.Angle=Vector2AngleToPoint(%Lasersprite.Position,%closestpos);
%vec2dir=Vector2Direction(%Lasersprite.Angle,%Lasersprite.Size.Y/2);
%Lasersprite.Position.X+=%vec2dir.X;
%Lasersprite.Position.Y+=-%vec2dir.Y;
%shapeindex=%Lasersprite.createPolygonBoxCollisionShape(%Lasersprite.Size);
%Lasersprite.setCollisionShapeIsSensor(%shapeindex,true);

%customfieldobj.firing=true;
%customfieldobj.originindex=%originindex;
%customfieldobj.dest=%closestpos;
%customfieldobj.spritehandle=%Lasersprite;
%customfieldobj.schedulehandle=schedule(62,0,"updatetransformation",%user);

//////////////////
%player.cancast=true;//use iteration to determine the number of seconds before player can cast again.
keycleanup(%user);

$skillschedules.remove(%scheduleobject);
%scheduleobject.delete();
return;
//////////////////
}
