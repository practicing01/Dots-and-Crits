function Wave::skill_Wave(%this,%scheduleobject,%user,%iteration)//and any other custom skill params
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
//create sprite for casting animation, it schedules a self-deletion
//the sprite doesn't have to attach to the character, it can be a regular sprite that stays at the casting spot
%spriteid=%player.sprite.addSprite();

%idobj=new SimObject()
{
spriteid=%spriteid;
rotates=true;
name="Wave";
centeroffset=0;
};
%player.mountedspriteids.add(%idobj);

%ass=0;
if ($view==0)
{
%ass=Wave.top_explosionass;
%player.sprite.setSpriteAnimation("Wave:anim_topdown_explosion");
}
else
{
%ass=Wave.side_explosionass;
%player.sprite.setSpriteAnimation("Wave:anim_sideview_explosion");
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
%ass=Wave.top_Waveass;
%img="Wave:image_topdown_Wave";
}
else
{
%ass=Wave.side_Waveass;
%img="Wave:image_sideview_Wave";
}

for (%x=0;%x<1;%x++)
{
////////////////////////////////////////////////////////////////////////////
//set this Wave's sprite
%Wavesprite=new Sprite()
{
Position=%player.sprite.Position;
Size=ScaleAssSizeVectorToCam(%ass);
Image=%img;
class="class_Wave";
parenthandle=0;
CollisionCallback="true";
SceneLayer=16;
GravityScale="0";
Bullet="true";
DefaultDensity=20;
FixedAngle=true;
};

if (!%player.sprite.SceneGroup)//player 0 casted
{
%Wavesprite.SceneGroup=28;//player 0 Waves
%Wavesprite.setCollisionGroups(1,25,26,29,30);//1=player 2, 29=player 2 Waves, 30=walls, 26=world objects
}
else//player 1 casted
{
%Wavesprite.SceneGroup=29;//player 1 Waves
%Wavesprite.setCollisionGroups(0,25,26,28,30);//0=player 1, 28=player 1 Waves, 30=walls, 26=world objects
}

DotsandCritsscene.add(%Wavesprite);
%Wavesprite.createPolygonBoxCollisionShape(ScaleAssSizeVectorToCam(%ass));

//////////////////////////////////////////////////////////////////////////////
//create vector list for this Waves path
%wavevectors=new SimSet();

%dest="0 0";

%spritesize=%player.sprite.getSpriteSize();

if (%player.curdir==0)//up
{
////////////
//set position based on custom sprite Wave origins
%dirset=%player.projectileorigindirset.getObject(0);
%origin=%dirset.getObject(getRandom(0,%dirset.getCount()-1));
%Wavesprite.Position.X+=%origin.x;
%Wavesprite.Position.Y+=%origin.y;
///////////

//%Wavesprite.Position.Y+=%spritesize.Y/2;
%pos=ScaleCamVectorToRes(%Wavesprite.Position);
%dest.X=%pos.X;
%dest.Y=%pos.Y+$resolution.Y;
}
else if (%player.curdir==1)//down
{
%Wavesprite.setAngle(180);

////////////
//set position based on custom sprite Wave origins
%dirset=%player.projectileorigindirset.getObject(1);
%origin=%dirset.getObject(getRandom(0,%dirset.getCount()-1));
%Wavesprite.Position.X+=%origin.x;
%Wavesprite.Position.Y+=%origin.y;
///////////

//%Wavesprite.Position.Y-=%spritesize.Y/2;
%pos=ScaleCamVectorToRes(%Wavesprite.Position);
%dest.X=%pos.X;
%dest.Y=%pos.Y-$resolution.Y;
}
else if (%player.curdir==2)//left
{
%Wavesprite.setAngle(270);
%Wavesprite.FlipY=true;

////////////
//set position based on custom sprite Wave origins
%dirset=%player.projectileorigindirset.getObject(2);
%origin=%dirset.getObject(getRandom(0,%dirset.getCount()-1));
%Wavesprite.Position.X+=%origin.x;
%Wavesprite.Position.Y+=%origin.y;
///////////

//%Wavesprite.Position.X-=%spritesize.X/2;
%pos=ScaleCamVectorToRes(%Wavesprite.Position);
%dest.X=%pos.X-$resolution.X;
%dest.Y=%pos.Y;
}
else if (%player.curdir==3)//right
{
%Wavesprite.setAngle(270);

////////////
//set position based on custom sprite Wave origins
%dirset=%player.projectileorigindirset.getObject(3);
%origin=%dirset.getObject(getRandom(0,%dirset.getCount()-1));
%Wavesprite.Position.X+=%origin.x;
%Wavesprite.Position.Y+=%origin.y;
///////////

//%Wavesprite.Position.X+=%spritesize.X/2;
%pos=ScaleCamVectorToRes(%Wavesprite.Position);
%dest.X=%pos.X+$resolution.X;
%dest.Y=%pos.Y;
}

///////////////////////////////

%dest=ScaleVectorToCam(%dest);
%vector=new SimObject()
{
x=%dest.X;
y=%dest.Y;
};
%wavevectors.add(%vector);

/////////////////////////////////////////////////////////////////////////////
//create Wave object that holds all the info and add it to the Wave list
%Wave=new SimObject()
{
//sprite (holds animation, position, collision shape, class)
sprite=%Wavesprite;
//list of points to move to
wavevectors=%wavevectors;
//index to above list
current_destination_vector=0;
//caster handle for collision detection
parenthandle=%player.sprite;
schedule_decay=0;
};
%Wave.sprite.parenthandle=%Wave;//needed cus onMoveToComplete() is for the sprite

//////////////////////////////////////////////
//start first moveTo()
%dest="0 0";
%dest.X=%Wave.wavevectors.getObject(%Wave.current_destination_vector).x;
%dest.Y=%Wave.wavevectors.getObject(%Wave.current_destination_vector).y;
%Wave.sprite.moveTo(%dest,10,0,0);

%speed=10;
%time=((Vector2Distance(%Wave.sprite.Position,%dest)/%speed)*1000)+1000;
%Wave.schedule_decay=schedule(%time,0,"Wavedecay",%Wave.sprite);

/////////////////////////////////////////////////
}//end for
//////////////////
%player.cancast=true;//use iteration to determine the number of seconds before player can cast again.
keycleanup(%user);

$skillschedules.remove(%scheduleobject);
%scheduleobject.delete();
return;
//////////////////
}
