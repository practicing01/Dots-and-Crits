function Pointforce::setskillbaricon(%this,%barslot)//state: 0=ready 1=cooldown
{
//need frames for:
//ready active, inactive
//cooldown active, inactive
if (%barslot.guihandle.Active)
{
if (!%barslot.skillstate)//ready
{
%barslot.guihandle.Image="Pointforce:image_bariconreadyactive";
%barslot.guihandle.setAnimation("Pointforce:anim_bariconreadyactive");
}
else//cd
{
%barslot.guihandle.Image="Pointforce:image_bariconcdactive";
%barslot.guihandle.setAnimation("Pointforce:anim_bariconcdactive");
}
}
else//inactive
{
if (!%barslot.skillstate)//ready
{
%barslot.guihandle.Image="Pointforce:image_bariconreadyinactive";
%barslot.guihandle.setAnimation("Pointforce:anim_bariconreadyinactive");
}
else//cd
{
%barslot.guihandle.Image="Pointforce:image_bariconcdinactive";
%barslot.guihandle.setAnimation("Pointforce:anim_bariconcdinactive");
}
}
}
