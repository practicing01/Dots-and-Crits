function Volley::setskillbaricon(%this,%slot)//state: 0=ready 1=cooldown
{
//need frames for:
//ready active, inactive
//cooldown active, inactive
if (%slot.guihandle.Active)
{
if (!%slot.skillstate)//ready
{
%slot.guihandle.Image="Volley:image_bariconreadyactive";
%slot.guihandle.setAnimation("Volley:anim_bariconreadyactive");
}
else//cd
{
%slot.guihandle.Image="Volley:image_bariconcdactive";
%slot.guihandle.setAnimation("Volley:anim_bariconcdactive");
}
}
else//inactive
{
if (!%slot.skillstate)//ready
{
%slot.guihandle.Image="Volley:image_bariconreadyinactive";
%slot.guihandle.setAnimation("Volley:anim_bariconreadyinactive");
}
else//cd
{
%slot.guihandle.Image="Volley:image_bariconcdinactive";
%slot.guihandle.setAnimation("Volley:anim_bariconcdinactive");
}
}
}
