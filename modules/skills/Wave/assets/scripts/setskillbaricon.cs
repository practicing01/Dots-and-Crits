function Wave::setskillbaricon(%this,%slot)//state: 0=ready 1=cooldown
{
//need frames for:
//ready active, inactive
//cooldown active, inactive
if (%slot.guihandle.Active)
{
if (!%slot.skillstate)//ready
{
%slot.guihandle.Image="Wave:image_bariconreadyactive";
%slot.guihandle.setAnimation("Wave:anim_bariconreadyactive");
}
else//cd
{
%slot.guihandle.Image="Wave:image_bariconcdactive";
%slot.guihandle.setAnimation("Wave:anim_bariconcdactive");
}
}
else//inactive
{
if (!%slot.skillstate)//ready
{
%slot.guihandle.Image="Wave:image_bariconreadyinactive";
%slot.guihandle.setAnimation("Wave:anim_bariconreadyinactive");
}
else//cd
{
%slot.guihandle.Image="Wave:image_bariconcdinactive";
%slot.guihandle.setAnimation("Wave:anim_bariconcdinactive");
}
}
}
