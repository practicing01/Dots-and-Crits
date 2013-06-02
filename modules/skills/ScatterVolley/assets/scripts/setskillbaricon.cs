function ScatterVolley::setskillbaricon(%this,%slot)//state: 0=ready 1=cooldown
{
//need frames for:
//ready active, inactive
//cooldown active, inactive
if (%slot.guihandle.Active)
{
if (!%slot.skillstate)//ready
{
%slot.guihandle.Image="ScatterVolley:image_bariconreadyactive";
%slot.guihandle.setAnimation("ScatterVolley:anim_bariconreadyactive");
}
else//cd
{
%slot.guihandle.Image="ScatterVolley:image_bariconcdactive";
%slot.guihandle.setAnimation("ScatterVolley:anim_bariconcdactive");
}
}
else//inactive
{
if (!%slot.skillstate)//ready
{
%slot.guihandle.Image="ScatterVolley:image_bariconreadyinactive";
%slot.guihandle.setAnimation("ScatterVolley:anim_bariconreadyinactive");
}
else//cd
{
%slot.guihandle.Image="ScatterVolley:image_bariconcdinactive";
%slot.guihandle.setAnimation("ScatterVolley:anim_bariconcdinactive");
}
}
}
