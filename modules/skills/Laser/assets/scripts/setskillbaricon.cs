function Laser::setskillbaricon(%this,%slot)//state: 0=ready 1=cooldown
{
//need frames for:
//ready active, inactive
//cooldown active, inactive
if (%slot.guihandle.Active)
{
if (!%slot.skillstate)//ready
{
%slot.guihandle.Image="Laser:image_bariconreadyactive";
%slot.guihandle.setAnimation("Laser:anim_bariconreadyactive");
}
else//cd
{
%slot.guihandle.Image="Laser:image_bariconcdactive";
%slot.guihandle.setAnimation("Laser:anim_bariconcdactive");
}
}
else//inactive
{
if (!%slot.skillstate)//ready
{
%slot.guihandle.Image="Laser:image_bariconreadyinactive";
%slot.guihandle.setAnimation("Laser:anim_bariconreadyinactive");
}
else//cd
{
%slot.guihandle.Image="Laser:image_bariconcdinactive";
%slot.guihandle.setAnimation("Laser:anim_bariconcdinactive");
}
}
}
