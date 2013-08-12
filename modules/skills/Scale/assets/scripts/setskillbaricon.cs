function Scale::setskillbaricon(%this,%barslot)//state: 0=ready 1=cooldown
{
//need frames for:
//ready active, inactive
//cooldown active, inactive
if (%barslot.guihandle.Active)
{
if (!%barslot.skillstate)//ready
{
%barslot.guihandle.Image="Scale:image_bariconreadyactive";
%barslot.guihandle.setAnimation("Scale:anim_bariconreadyactive");
}
else//cd
{
%barslot.guihandle.Image="Scale:image_bariconcdactive";
%barslot.guihandle.setAnimation("Scale:anim_bariconcdactive");
}
}
else//inactive
{
if (!%barslot.skillstate)//ready
{
%barslot.guihandle.Image="Scale:image_bariconreadyinactive";
%barslot.guihandle.setAnimation("Scale:anim_bariconreadyinactive");
}
else//cd
{
%barslot.guihandle.Image="Scale:image_bariconcdinactive";
%barslot.guihandle.setAnimation("Scale:anim_bariconcdinactive");
}
}
}
