function M4Carbine::skill_M4Carbine(%this,%scheduleobject,%user,%iteration)//and any other custom skill params
{
%player=$players.getObject(%user);
if (!isObject(%player.sprite))
{
$skillschedules.remove(%scheduleobject);
%scheduleobject.delete();
return;
}

setskillanimation(%player,%player.skillanimtype);//animtype: 0:selfcast 1:targetcast 2:melee 3:emote
%player.cancast=true;
keycleanup(%user);
//////////////////

%customfieldobj=M4Carbine.customplayerfields.getObject(%user);

for (%x=0;%x<%player.mountedspriteids.getCount();%x++)
{
%idobj=%player.mountedspriteids.getObject(%x);
if (%idobj.name$="M4Carbine")
{
%player.mountedspriteids.remove(%idobj);

%player.sprite.selectSpriteName("M4Carbine");
%player.sprite.removeSprite();
%player.sprite.selectSpriteId(%player.spriteid);//reselect character sprite

if (isObject(%customfieldobj.mousecaptureobj))
{
%customfieldobj.mousecaptureobj.Active=false;
}

return;
}
}

//not found, toggle on

if (isObject(%customfieldobj.mousecaptureobj))
{
%customfieldobj.mousecaptureobj.Active=true;
}

%spritesize=%player.sprite.getSpriteSize();

%localpos="0 0";
%localpos.Y-=%spritesize.Y/2;

%spriteid=%player.sprite.addSprite();

%player.sprite.setSpriteName("M4Carbine");
%player.sprite.setSpriteAnimation("M4Carbine:anim_M4Carbine");
%player.sprite.setSpriteSize(ScaleAssSizeVectorToCam(M4Carbine.M4Carbineass));
%spritesize=%player.sprite.getSpriteSize();
%localpos.Y-=%spritesize.Y/2;
%player.sprite.setSpriteLocalPosition(%localpos);
%player.sprite.SetSpriteDepth(0);
%player.sprite.selectSpriteId(%player.spriteid);//important so anim-setting functions can work

%idobj=new SimObject()
{
spriteid=%spriteid;
rotates=true;
name="M4Carbine";
centeroffset=mAbs(%localpos.Y);
};
%player.mountedspriteids.add(%idobj);

rotatecompositesprites(%user);
//////////////////
}
