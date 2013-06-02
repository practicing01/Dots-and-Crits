function SineVolley::setskillbaricon(%this,%slot)//state: 0=ready 1=cooldown
{
//need frames for:
//ready active, inactive
//cooldown active, inactive
if (%slot.guihandle.Active)
{
if (!%slot.skillstate)//ready
{
%slot.guihandle.Image="SineVolley:image_bariconreadyactive";
%slot.guihandle.setAnimation("SineVolley:anim_bariconreadyactive");
}
else//cd
{
%slot.guihandle.Image="SineVolley:image_bariconcdactive";
%slot.guihandle.setAnimation("SineVolley:anim_bariconcdactive");
}
}
else//inactive
{
if (!%slot.skillstate)//ready
{
%slot.guihandle.Image="SineVolley:image_bariconreadyinactive";
%slot.guihandle.setAnimation("SineVolley:anim_bariconreadyinactive");
}
else//cd
{
%slot.guihandle.Image="SineVolley:image_bariconcdinactive";
%slot.guihandle.setAnimation("SineVolley:anim_bariconcdinactive");
}
}
}
