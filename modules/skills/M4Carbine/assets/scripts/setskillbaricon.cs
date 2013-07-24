function M4Carbine::setskillbaricon(%this,%slot)//state: 0=ready 1=cooldown
{
//need frames for:
//ready active, inactive
//cooldown active, inactive
if (%slot.guihandle.Active)
{
if (!%slot.skillstate)//ready
{
%slot.guihandle.Image="M4Carbine:image_bariconreadyactive";
%slot.guihandle.setAnimation("M4Carbine:anim_bariconreadyactive");
}
else//cd
{
%slot.guihandle.Image="M4Carbine:image_bariconcdactive";
%slot.guihandle.setAnimation("M4Carbine:anim_bariconcdactive");
}
}
else//inactive
{
if (!%slot.skillstate)//ready
{
%slot.guihandle.Image="M4Carbine:image_bariconreadyinactive";
%slot.guihandle.setAnimation("M4Carbine:anim_bariconreadyinactive");
}
else//cd
{
%slot.guihandle.Image="M4Carbine:image_bariconcdinactive";
%slot.guihandle.setAnimation("M4Carbine:anim_bariconcdinactive");
}
}
}
