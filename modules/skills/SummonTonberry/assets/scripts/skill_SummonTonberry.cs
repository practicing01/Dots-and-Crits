function SummonTonberry::skill_SummonTonberry(%this,%scheduleobject,%user,%iteration)//and any other custom skill params
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

%tonberry=new Sprite()
{
Position=%player.sprite.Position;
Size=ScaleAssSizeVectorToCam(SummonTonberry.tonberryass);
Image="SummonTonberry:image_tonberry";
class="class_tonberry";
health=100;
CollisionCallback=true;
SceneGroup=25;//npc
FixedAngle=true;
gui_skillbar=0;
//if listeners are true, the tonberry will wait for a click
listen4move=false;
listen4follow=false;
listen4snare=false;
listen4shank=false;
prevmousepos=DotsandCritswindow.getMousePosition();
curmousepos="0 0";
curdir=0;
obj2follow=0;
schedule_follow=0;
obj2snare=0;
schedule_snare=0;
obj2shank=0;
schedule_shank=0;
normalspeed=10;
speed=10;
snareiteration=0;
};
DotsandCritsscene.add(%tonberry);
%tonberry.createPolygonBoxCollisionShape(ScaleAssSizeVectorToCam(SummonTonberry.tonberryass));

if (!%user)//player 0 casted
{
%tonberry.setUseInputEvents(true);

DotsandCritswindow.addInputListener(%tonberry);
scenewindow_player1.addInputListener(%tonberry);
}
else
{
$joycallbackobjlist.add(%tonberry);
}

%tonberry.gui_skillbar=createtonberryskillbar();

gui_tonberry_skillbar.setName("");

Canvas.pushDialog(%tonberry.gui_skillbar);
%tonberry.attachGui(%tonberry.gui_skillbar,DotsandCritswindow,false,"0 -50");//have to deal with other windows

for (%x=0;%x<%tonberry.gui_skillbar.getCount();%x++)
{
%butt=%tonberry.gui_skillbar.getObject(%x);
if (%butt.getName()$="movebutt")
{
%butt.command="movebutt("@%tonberry@",0);";
}
else if (%butt.getName()$="followbutt")
{
%butt.command="followbutt("@%tonberry@",0);";
}
else if (%butt.getName()$="snarebutt")
{
%butt.command="snarebutt("@%tonberry@",0);";
}
else if (%butt.getName()$="shankbutt")
{
%butt.command="shankbutt("@%tonberry@",0);";
}

%butt.setName("");
}

//////////////////
%playerspritesize=%player.sprite.getSpriteSize();
%spritesize=%tonberry.getSize();

//set position
if (%player.curdir==0)//up
{
%tonberry.Position.Y-=(%playerspritesize.Y/2)+(%spritesize.Y/2);
%tonberry.playAnimation("SummonTonberry:anim_standup");
%tonberry.curdir=0;
}
else if (%player.curdir==1)//down
{
%tonberry.Position.Y+=(%playerspritesize.Y/2)+(%spritesize.Y/2);
%tonberry.playAnimation("SummonTonberry:anim_standdown");
%tonberry.curdir=1;
}
else if (%player.curdir==2)//left
{
%tonberry.Position.X+=(%playerspritesize.X/2)+(%spritesize.X/2);
%tonberry.playAnimation("SummonTonberry:anim_standleft");
%tonberry.curdir=2;
}
else if (%player.curdir==3)//right
{
%tonberry.Position.X-=(%playerspritesize.X/2)+(%spritesize.X/2);
%tonberry.playAnimation("SummonTonberry:anim_standright");
%tonberry.curdir=3;
}
//////////////////
//store for deletion
SummonTonberry.tonberries.add(%tonberry);
//////////////////
$skillschedules.remove(%scheduleobject);
%scheduleobject.delete();
%player.cancast=true;//use iteration to determine the number of seconds before player can cast again.
keycleanup(%user);
return;
//////////////////
}
