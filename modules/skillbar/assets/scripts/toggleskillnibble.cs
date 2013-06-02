function toggleskillnibble(%skillbar)
{
if (!%skillbar)//player 1 skillbar
{

for (%x=0;%x<$player1skillbar.getCount();%x++)
{

%slot=$player1skillbar.getObject(%x);
%slot.guihandle.Active=!%slot.guihandle.Active;

if (isObject(%slot.moduleid))
{
%slot.moduleid.ScopeSet.setskillbaricon(%slot);
}
else
{

if (%slot.guihandle.Active)
{
%slot.guihandle.Image="DotsandCrits:image_noskillset";
%slot.guihandle.setAnimation("DotsandCrits:anim_noskillset");
}
else
{
%slot.guihandle.Image="DotsandCrits:image_noskillsetinactive";
%slot.guihandle.setAnimation("DotsandCrits:anim_noskillsetinactive");
}

}

}

$player1activeskillbarnibble=!$player1skillbar.getObject(0).guihandle.Active;

}
else//player 2 skillbar
{

for (%x=0;%x<$player2skillbar.getCount();%x++)
{

%slot=$player2skillbar.getObject(%x);
%slot.guihandle.Active=!%slot.guihandle.Active;

if (isObject(%slot.moduleid))
{
%slot.moduleid.ScopeSet.setskillbaricon(%slot);
}
else
{

if (%slot.guihandle.Active)
{
%slot.guihandle.Image="DotsandCrits:image_noskillset";
%slot.guihandle.setAnimation("DotsandCrits:anim_noskillset");
}
else
{
%slot.guihandle.Image="DotsandCrits:image_noskillsetinactive";
%slot.guihandle.setAnimation("DotsandCrits:anim_noskillsetinactive");
}

}

}

$player2activeskillbarnibble=!$player2skillbar.getObject(0).guihandle.Active;

}

}
