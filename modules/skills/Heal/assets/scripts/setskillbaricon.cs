function Heal::setskillbaricon(%this,%barslot)//state: 0=ready 1=cooldown
{
//need frames for:
//ready active, inactive
//cooldown active, inactive
if (%barslot.guihandle.Active)
{
if (!%barslot.skillstate)//ready
{
%barslot.guihandle.Image="Heal:image_bariconreadyactive";
%barslot.guihandle.setAnimation("Heal:anim_bariconreadyactive");
}
else//cd
{
%barslot.guihandle.Image="Heal:image_bariconcdactive";
%barslot.guihandle.setAnimation("Heal:anim_bariconcdactive");
}
}
else//inactive
{
if (!%barslot.skillstate)//ready
{
%barslot.guihandle.Image="Heal:image_bariconreadyinactive";
%barslot.guihandle.setAnimation("Heal:anim_bariconreadyinactive");
}
else//cd
{
%barslot.guihandle.Image="Heal:image_bariconcdinactive";
%barslot.guihandle.setAnimation("Heal:anim_bariconcdinactive");
}
}
}
