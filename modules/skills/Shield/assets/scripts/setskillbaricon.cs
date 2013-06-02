function Shield::setskillbaricon(%this,%barslot)//state: 0=ready 1=cooldown
{
//need frames for:
//ready active, inactive
//cooldown active, inactive
if (%barslot.guihandle.Active)
{
if (!%barslot.skillstate)//ready
{
%barslot.guihandle.Image="Shield:image_bariconreadyactive";
%barslot.guihandle.setAnimation("Shield:anim_bariconreadyactive");
}
else//cd
{
%barslot.guihandle.Image="Shield:image_bariconcdactive";
%barslot.guihandle.setAnimation("Shield:anim_bariconcdactive");
}
}
else//inactive
{
if (!%barslot.skillstate)//ready
{
%barslot.guihandle.Image="Shield:image_bariconreadyinactive";
%barslot.guihandle.setAnimation("Shield:anim_bariconreadyinactive");
}
else//cd
{
%barslot.guihandle.Image="Shield:image_bariconcdinactive";
%barslot.guihandle.setAnimation("Shield:anim_bariconcdinactive");
}
}
}
