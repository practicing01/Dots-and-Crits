////////////////////////////////////////////////////////////////////////////////
function setskillanimation(%player,%animtype,%animname)
{
if (isObject(%player.sprite))
{

if (!%player.curdir)//up
{
if (%player.keysdown.X)//keysdown is a 4 dimensional array. access the elements using X Y Z W
{//key down, player moving
////////////////////////////////
if (!%animtype)//0:selfcast
{

if (%animname)
{

for (%x=0;%x<%player.anim_run_up_selfcast.getCount();%x++)
{

%anim=%player.anim_run_up_selfcast.getObject(%x);
if (%anim.animname$=%animname)
{
%player.sprite.setSpriteAnimation(%anim);
return;
}

}

}
%player.sprite.setSpriteAnimation(%player.anim_run_up_selfcast.getObject(getRandom(0,%player.anim_run_up_selfcast.getCount()-1)).anim);

}
else if (%animtype==1)//1:targetcast
{

if (%animname)
{

for (%x=0;%x<%player.anim_run_up_targetcast.getCount();%x++)
{

%anim=%player.anim_run_up_targetcast.getObject(%x);
if (%anim.animname$=%animname)
{
%player.sprite.setSpriteAnimation(%anim);
return;
}

}

}
%player.sprite.setSpriteAnimation(%player.anim_run_up_targetcast.getObject(getRandom(0,%player.anim_run_up_targetcast.getCount()-1)).anim);

}
else if (%animtype==2)//2:melee
{

if (%animname)
{

for (%x=0;%x<%player.anim_run_up_melee.getCount();%x++)
{

%anim=%player.anim_run_up_melee.getObject(%x);
if (%anim.animname$=%animname)
{
%player.sprite.setSpriteAnimation(%anim);
return;
}

}

}
%player.sprite.setSpriteAnimation(%player.anim_run_up_melee.getObject(getRandom(0,%player.anim_run_up_melee.getCount()-1)).anim);

}
else if (%animtype==3)//3:emote
{

if (%animname)
{

for (%x=0;%x<%player.anim_run_up_emote.getCount();%x++)
{

%anim=%player.anim_run_up_emote.getObject(%x);
if (%anim.animname$=%animname)
{
%player.sprite.setSpriteAnimation(%anim);
return;
}

}

}
%player.sprite.setSpriteAnimation(%player.anim_run_up_emote.getObject(getRandom(0,%player.anim_run_up_emote.getCount()-1)).anim);

}
////////////////////////////////
}
else//key up, player standing
{
////////////////////////////////
if (!%animtype)//0:selfcast
{

if (%animname)
{

for (%x=0;%x<%player.anim_stand_up_selfcast.getCount();%x++)
{

%anim=%player.anim_stand_up_selfcast.getObject(%x);
if (%anim.animname$=%animname)
{
%player.sprite.setSpriteAnimation(%anim);
return;
}

}

}
%player.sprite.setSpriteAnimation(%player.anim_stand_up_selfcast.getObject(getRandom(0,%player.anim_stand_up_selfcast.getCount()-1)).anim);

}
else if (%animtype==1)//1:targetcast
{

if (%animname)
{

for (%x=0;%x<%player.anim_stand_up_targetcast.getCount();%x++)
{

%anim=%player.anim_stand_up_targetcast.getObject(%x);
if (%anim.animname$=%animname)
{
%player.sprite.setSpriteAnimation(%anim);
return;
}

}

}
%player.sprite.setSpriteAnimation(%player.anim_stand_up_targetcast.getObject(getRandom(0,%player.anim_stand_up_targetcast.getCount()-1)).anim);

}
else if (%animtype==2)//2:melee
{

if (%animname)
{

for (%x=0;%x<%player.anim_stand_up_melee.getCount();%x++)
{

%anim=%player.anim_stand_up_melee.getObject(%x);
if (%anim.animname$=%animname)
{
%player.sprite.setSpriteAnimation(%anim);
return;
}

}

}
%player.sprite.setSpriteAnimation(%player.anim_stand_up_melee.getObject(getRandom(0,%player.anim_stand_up_melee.getCount()-1)).anim);

}
else if (%animtype==3)//3:emote
{

if (%animname)
{

for (%x=0;%x<%player.anim_stand_up_emote.getCount();%x++)
{

%anim=%player.anim_stand_up_emote.getObject(%x);
if (%anim.animname$=%animname)
{
%player.sprite.setSpriteAnimation(%anim);
return;
}

}

}
%player.sprite.setSpriteAnimation(%player.anim_stand_up_emote.getObject(getRandom(0,%player.anim_stand_up_emote.getCount()-1)).anim);

}
}
/////////////////////////////////
}
else if (%player.curdir==1)//down
{
if (%player.keysdown.Y)//keysdown is a 4 dimensional array. access the elements using X Y Z W
{//key down, player moving
////////////////////////////////
if (!%animtype)//0:selfcast
{

if (%animname)
{

for (%x=0;%x<%player.anim_run_down_selfcast.getCount();%x++)
{

%anim=%player.anim_run_down_selfcast.getObject(%x);
if (%anim.animname$=%animname)
{
%player.sprite.setSpriteAnimation(%anim);
return;
}

}

}
%player.sprite.setSpriteAnimation(%player.anim_run_down_selfcast.getObject(getRandom(0,%player.anim_run_down_selfcast.getCount()-1)).anim);

}
else if (%animtype==1)//1:targetcast
{

if (%animname)
{

for (%x=0;%x<%player.anim_run_down_targetcast.getCount();%x++)
{

%anim=%player.anim_run_down_targetcast.getObject(%x);
if (%anim.animname$=%animname)
{
%player.sprite.setSpriteAnimation(%anim);
return;
}

}

}
%player.sprite.setSpriteAnimation(%player.anim_run_down_targetcast.getObject(getRandom(0,%player.anim_run_down_targetcast.getCount()-1)).anim);

}
else if (%animtype==2)//2:melee
{

if (%animname)
{

for (%x=0;%x<%player.anim_run_down_melee.getCount();%x++)
{

%anim=%player.anim_run_down_melee.getObject(%x);
if (%anim.animname$=%animname)
{
%player.sprite.setSpriteAnimation(%anim);
return;
}

}

}
%player.sprite.setSpriteAnimation(%player.anim_run_down_melee.getObject(getRandom(0,%player.anim_run_down_melee.getCount()-1)).anim);

}
else if (%animtype==3)//3:emote
{

if (%animname)
{

for (%x=0;%x<%player.anim_run_down_emote.getCount();%x++)
{

%anim=%player.anim_run_down_emote.getObject(%x);
if (%anim.animname$=%animname)
{
%player.sprite.setSpriteAnimation(%anim);
return;
}

}

}
%player.sprite.setSpriteAnimation(%player.anim_run_down_emote.getObject(getRandom(0,%player.anim_run_down_emote.getCount()-1)).anim);

}
////////////////////////////////
}
else//key up, player standing
{
////////////////////////////////
if (!%animtype)//0:selfcast
{

if (%animname)
{

for (%x=0;%x<%player.anim_stand_down_selfcast.getCount();%x++)
{

%anim=%player.anim_stand_down_selfcast.getObject(%x);
if (%anim.animname$=%animname)
{
%player.sprite.setSpriteAnimation(%anim);
return;
}

}

}
%player.sprite.setSpriteAnimation(%player.anim_stand_down_selfcast.getObject(getRandom(0,%player.anim_stand_down_selfcast.getCount()-1)).anim);

}
else if (%animtype==1)//1:targetcast
{

if (%animname)
{

for (%x=0;%x<%player.anim_stand_down_targetcast.getCount();%x++)
{

%anim=%player.anim_stand_down_targetcast.getObject(%x);
if (%anim.animname$=%animname)
{
%player.sprite.setSpriteAnimation(%anim);
return;
}

}

}
%player.sprite.setSpriteAnimation(%player.anim_stand_down_targetcast.getObject(getRandom(0,%player.anim_stand_down_targetcast.getCount()-1)).anim);

}
else if (%animtype==2)//2:melee
{

if (%animname)
{

for (%x=0;%x<%player.anim_stand_down_melee.getCount();%x++)
{

%anim=%player.anim_stand_down_melee.getObject(%x);
if (%anim.animname$=%animname)
{
%player.sprite.setSpriteAnimation(%anim);
return;
}

}

}
%player.sprite.setSpriteAnimation(%player.anim_stand_down_melee.getObject(getRandom(0,%player.anim_stand_down_melee.getCount()-1)).anim);

}
else if (%animtype==3)//3:emote
{

if (%animname)
{

for (%x=0;%x<%player.anim_stand_down_emote.getCount();%x++)
{

%anim=%player.anim_stand_down_emote.getObject(%x);
if (%anim.animname$=%animname)
{
%player.sprite.setSpriteAnimation(%anim);
return;
}

}

}
%player.sprite.setSpriteAnimation(%player.anim_stand_down_emote.getObject(getRandom(0,%player.anim_stand_down_emote.getCount()-1)).anim);

}
}
/////////////////////////////////
}
else if (%player.curdir==2)//left
{
if (%player.keysdown.Z)//keysdown is a 4 dimensional array. access the elements using X Y Z W
{//key down, player moving
////////////////////////////////
if (!%animtype)//0:selfcast
{

if (%animname)
{

for (%x=0;%x<%player.anim_run_left_selfcast.getCount();%x++)
{

%anim=%player.anim_run_left_selfcast.getObject(%x);
if (%anim.animname$=%animname)
{
%player.sprite.setSpriteAnimation(%anim);
return;
}

}

}
%player.sprite.setSpriteAnimation(%player.anim_run_left_selfcast.getObject(getRandom(0,%player.anim_run_left_selfcast.getCount()-1)).anim);

}
else if (%animtype==1)//1:targetcast
{

if (%animname)
{

for (%x=0;%x<%player.anim_run_left_targetcast.getCount();%x++)
{

%anim=%player.anim_run_left_targetcast.getObject(%x);
if (%anim.animname$=%animname)
{
%player.sprite.setSpriteAnimation(%anim);
return;
}

}

}
%player.sprite.setSpriteAnimation(%player.anim_run_left_targetcast.getObject(getRandom(0,%player.anim_run_left_targetcast.getCount()-1)).anim);

}
else if (%animtype==2)//2:melee
{

if (%animname)
{

for (%x=0;%x<%player.anim_run_left_melee.getCount();%x++)
{

%anim=%player.anim_run_left_melee.getObject(%x);
if (%anim.animname$=%animname)
{
%player.sprite.setSpriteAnimation(%anim);
return;
}

}

}
%player.sprite.setSpriteAnimation(%player.anim_run_left_melee.getObject(getRandom(0,%player.anim_run_left_melee.getCount()-1)).anim);

}
else if (%animtype==3)//3:emote
{

if (%animname)
{

for (%x=0;%x<%player.anim_run_left_emote.getCount();%x++)
{

%anim=%player.anim_run_left_emote.getObject(%x);
if (%anim.animname$=%animname)
{
%player.sprite.setSpriteAnimation(%anim);
return;
}

}

}
%player.sprite.setSpriteAnimation(%player.anim_run_left_emote.getObject(getRandom(0,%player.anim_run_left_emote.getCount()-1)).anim);

}
////////////////////////////////
}
else//key up, player standing
{
////////////////////////////////
if (!%animtype)//0:selfcast
{

if (%animname)
{

for (%x=0;%x<%player.anim_stand_left_selfcast.getCount();%x++)
{

%anim=%player.anim_stand_left_selfcast.getObject(%x);
if (%anim.animname$=%animname)
{
%player.sprite.setSpriteAnimation(%anim);
return;
}

}

}
%player.sprite.setSpriteAnimation(%player.anim_stand_left_selfcast.getObject(getRandom(0,%player.anim_stand_left_selfcast.getCount()-1)).anim);

}
else if (%animtype==1)//1:targetcast
{

if (%animname)
{

for (%x=0;%x<%player.anim_stand_left_targetcast.getCount();%x++)
{

%anim=%player.anim_stand_left_targetcast.getObject(%x);
if (%anim.animname$=%animname)
{
%player.sprite.setSpriteAnimation(%anim);
return;
}

}

}
%player.sprite.setSpriteAnimation(%player.anim_stand_left_targetcast.getObject(getRandom(0,%player.anim_stand_left_targetcast.getCount()-1)).anim);

}
else if (%animtype==2)//2:melee
{

if (%animname)
{

for (%x=0;%x<%player.anim_stand_left_melee.getCount();%x++)
{

%anim=%player.anim_stand_left_melee.getObject(%x);
if (%anim.animname$=%animname)
{
%player.sprite.setSpriteAnimation(%anim);
return;
}

}

}
%player.sprite.setSpriteAnimation(%player.anim_stand_left_melee.getObject(getRandom(0,%player.anim_stand_left_melee.getCount()-1)).anim);

}
else if (%animtype==3)//3:emote
{

if (%animname)
{

for (%x=0;%x<%player.anim_stand_left_emote.getCount();%x++)
{

%anim=%player.anim_stand_left_emote.getObject(%x);
if (%anim.animname$=%animname)
{
%player.sprite.setSpriteAnimation(%anim);
return;
}

}

}
%player.sprite.setSpriteAnimation(%player.anim_stand_left_emote.getObject(getRandom(0,%player.anim_stand_left_emote.getCount()-1)).anim);

}
}
/////////////////////////////////
}
else if (%player.curdir==3)//right
{
if (%player.keysdown.W)//keysdown is a 4 dimensional array. access the elements using X Y Z W
{//key down, player moving
////////////////////////////////
if (!%animtype)//0:selfcast
{

if (%animname)
{

for (%x=0;%x<%player.anim_run_right_selfcast.getCount();%x++)
{

%anim=%player.anim_run_right_selfcast.getObject(%x);
if (%anim.animname$=%animname)
{
%player.sprite.setSpriteAnimation(%anim);
return;
}

}

}
%player.sprite.setSpriteAnimation(%player.anim_run_right_selfcast.getObject(getRandom(0,%player.anim_run_right_selfcast.getCount()-1)).anim);

}
else if (%animtype==1)//1:targetcast
{

if (%animname)
{

for (%x=0;%x<%player.anim_run_right_targetcast.getCount();%x++)
{

%anim=%player.anim_run_right_targetcast.getObject(%x);
if (%anim.animname$=%animname)
{
%player.sprite.setSpriteAnimation(%anim);
return;
}

}

}
%player.sprite.setSpriteAnimation(%player.anim_run_right_targetcast.getObject(getRandom(0,%player.anim_run_right_targetcast.getCount()-1)).anim);

}
else if (%animtype==2)//2:melee
{

if (%animname)
{

for (%x=0;%x<%player.anim_run_right_melee.getCount();%x++)
{

%anim=%player.anim_run_right_melee.getObject(%x);
if (%anim.animname$=%animname)
{
%player.sprite.setSpriteAnimation(%anim);
return;
}

}

}
%player.sprite.setSpriteAnimation(%player.anim_run_right_melee.getObject(getRandom(0,%player.anim_run_right_melee.getCount()-1)).anim);

}
else if (%animtype==3)//3:emote
{

if (%animname)
{

for (%x=0;%x<%player.anim_run_right_emote.getCount();%x++)
{

%anim=%player.anim_run_right_emote.getObject(%x);
if (%anim.animname$=%animname)
{
%player.sprite.setSpriteAnimation(%anim);
return;
}

}

}
%player.sprite.setSpriteAnimation(%player.anim_run_right_emote.getObject(getRandom(0,%player.anim_run_right_emote.getCount()-1)).anim);

}
////////////////////////////////
}
else//key up, player standing
{
////////////////////////////////
if (!%animtype)//0:selfcast
{

if (%animname)
{

for (%x=0;%x<%player.anim_stand_right_selfcast.getCount();%x++)
{

%anim=%player.anim_stand_right_selfcast.getObject(%x);
if (%anim.animname$=%animname)
{
%player.sprite.setSpriteAnimation(%anim);
return;
}

}

}
%player.sprite.setSpriteAnimation(%player.anim_stand_right_selfcast.getObject(getRandom(0,%player.anim_stand_right_selfcast.getCount()-1)).anim);

}
else if (%animtype==1)//1:targetcast
{

if (%animname)
{

for (%x=0;%x<%player.anim_stand_right_targetcast.getCount();%x++)
{

%anim=%player.anim_stand_right_targetcast.getObject(%x);
if (%anim.animname$=%animname)
{
%player.sprite.setSpriteAnimation(%anim);
return;
}

}

}
%player.sprite.setSpriteAnimation(%player.anim_stand_right_targetcast.getObject(getRandom(0,%player.anim_stand_right_targetcast.getCount()-1)).anim);

}
else if (%animtype==2)//2:melee
{

if (%animname)
{

for (%x=0;%x<%player.anim_stand_right_melee.getCount();%x++)
{

%anim=%player.anim_stand_right_melee.getObject(%x);
if (%anim.animname$=%animname)
{
%player.sprite.setSpriteAnimation(%anim);
return;
}

}

}
%player.sprite.setSpriteAnimation(%player.anim_stand_right_melee.getObject(getRandom(0,%player.anim_stand_right_melee.getCount()-1)).anim);

}
else if (%animtype==3)//3:emote
{

if (%animname)
{

for (%x=0;%x<%player.anim_stand_right_emote.getCount();%x++)
{

%anim=%player.anim_stand_right_emote.getObject(%x);
if (%anim.animname$=%animname)
{
%player.sprite.setSpriteAnimation(%anim);
return;
}

}

}
%player.sprite.setSpriteAnimation(%player.anim_stand_right_emote.getObject(getRandom(0,%player.anim_stand_right_emote.getCount()-1)).anim);

}
}
/////////////////////////////////
}

}
}
////////////////////////////////////////////////////////////////////////////////
