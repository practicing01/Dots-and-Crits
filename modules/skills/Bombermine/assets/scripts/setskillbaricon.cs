function Bombermine::setskillbaricon(%this,%slot)//state: 0=ready 1=cooldown
{
//need frames for:
//ready active, inactive
//cooldown active, inactive
if (%slot.guihandle.Active)
{
if (!%slot.skillstate)//ready
{
%slot.guihandle.Image="Bombermine:image_bariconreadyactive";
%slot.guihandle.setAnimation("Bombermine:anim_bariconreadyactive");
}
else//cd
{
%slot.guihandle.Image="Bombermine:image_bariconcdactive";
%slot.guihandle.setAnimation("Bombermine:anim_bariconcdactive");
}
}
else//inactive
{
if (!%slot.skillstate)//ready
{
%slot.guihandle.Image="Bombermine:image_bariconreadyinactive";
%slot.guihandle.setAnimation("Bombermine:anim_bariconreadyinactive");
}
else//cd
{
%slot.guihandle.Image="Bombermine:image_bariconcdinactive";
%slot.guihandle.setAnimation("Bombermine:anim_bariconcdinactive");
}
}
}
