function Shield::skill_Shield(%this,%scheduleobject,%user,%iteration)//and any other custom skill params
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

%collisiongroups=bit(!%user)|bit(2)|bit(3)|bit(4)|bit(5)|bit(6)|bit(7)|bit(8)|bit(9)|bit(10)|bit(11)
|bit(12)|bit(13)|bit(14)|bit(15)|bit(16)|bit(17)|bit(18)|bit(19)|bit(20)|bit(21)|bit(22)|bit(23)|bit(24)
|bit(25)|bit(26)|bit(27)|bit(29-%user)|bit(30);//28=p1 projectiles 29=p2 projectiles

%shield=new Sprite()
{
Position=%player.sprite.Position;
Size=ScaleAssSizeVectorToCam(Shield.shieldass);
Image="Shield:image_shield0";
GravityScale="0";
BodyType="static";
class="class_shield";
health=100;
CollisionCallback=true;
SceneGroup=28+%user;//28=p1 projectiles 29=p2 projectiles
CollisionGroups=%collisiongroups;
};
DotsandCritsscene.add(%shield);
%shield.setBlendAlpha(0.25);
%shield.createPolygonBoxCollisionShape(ScaleAssSizeVectorToCam(Shield.shieldass));

%playerspritesize=%player.sprite.getSpriteSize();
%spritesize=%shield.getSize();

%shield.mount(%player.sprite,-((%playerspritesize.X/2)+1+%spritesize.X/2) SPC (%playerspritesize.Y/2)+1+%spritesize.Y/2,0,true,0);

%shield=new Sprite()
{
Position=%player.sprite.Position;
Size=ScaleAssSizeVectorToCam(Shield.shieldass);
Image="Shield:image_shield0";
GravityScale="0";
BodyType="static";
FlipX=true;
class="class_shield";
health=100;
CollisionCallback=true;
SceneGroup=28+%user;//28=p1 projectiles 29=p2 projectiles
CollisionGroups=%collisiongroups;
};
DotsandCritsscene.add(%shield);
%shield.setBlendAlpha(0.25);
%shield.createPolygonBoxCollisionShape(ScaleAssSizeVectorToCam(Shield.shieldass));

%shield.mount(%player.sprite,(%playerspritesize.X/2)+1+%spritesize.X/2 SPC (%playerspritesize.Y/2)+1+%spritesize.Y/2,0,true,0);

%shield=new Sprite()
{
Position=%player.sprite.Position;
Size=ScaleAssSizeVectorToCam(Shield.shieldass);
Image="Shield:image_shield0";
GravityScale="0";
BodyType="static";
FlipY=true;
FlipX=true;
class="class_shield";
health=100;
CollisionCallback=true;
SceneGroup=28+%user;//28=p1 projectiles 29=p2 projectiles
CollisionGroups=%collisiongroups;
};
DotsandCritsscene.add(%shield);
%shield.setBlendAlpha(0.25);
%shield.createPolygonBoxCollisionShape(ScaleAssSizeVectorToCam(Shield.shieldass));

%shield.mount(%player.sprite,(%playerspritesize.X/2)+1+%spritesize.X/2 SPC -((%playerspritesize.Y/2)+1+%spritesize.Y/2),0,true,0);

%shield=new Sprite()
{
Position=%player.sprite.Position;
Size=ScaleAssSizeVectorToCam(Shield.shieldass);
Image="Shield:image_shield0";
GravityScale="0";
BodyType="static";
FlipY=true;
class="class_shield";
health=100;
CollisionCallback=true;
SceneGroup=28+%user;//28=p1 projectiles 29=p2 projectiles
CollisionGroups=%collisiongroups;
};
DotsandCritsscene.add(%shield);
%shield.setBlendAlpha(0.25);
%shield.createPolygonBoxCollisionShape(ScaleAssSizeVectorToCam(Shield.shieldass));

%shield.mount(%player.sprite,-((%playerspritesize.X/2)+1+%spritesize.X/2) SPC -((%playerspritesize.Y/2)+1+%spritesize.Y/2),0,true,0);

//////////////////
$skillschedules.remove(%scheduleobject);
%scheduleobject.delete();
%player.cancast=true;//use iteration to determine the number of seconds before player can cast again.
keycleanup(%user);
return;
//////////////////
}
