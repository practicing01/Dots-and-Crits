function Lightsaber::setskillbaricon(%this,%barslot)//state: 0=ready 1=cooldown
{
//need frames for:
//ready active, inactive
//cooldown active, inactive
if (%barslot.guihandle.Active)
{
if (!%barslot.skillstate)//ready
{
%barslot.guihandle.Image="Lightsaber:image_bariconreadyactive";
%barslot.guihandle.setAnimation("Lightsaber:anim_bariconreadyactive");
}
else//cd
{
%barslot.guihandle.Image="Lightsaber:image_bariconcdactive";
%barslot.guihandle.setAnimation("Lightsaber:anim_bariconcdactive");
}
}
else//inactive
{
if (!%barslot.skillstate)//ready
{
%barslot.guihandle.Image="Lightsaber:image_bariconreadyinactive";
%barslot.guihandle.setAnimation("Lightsaber:anim_bariconreadyinactive");
}
else//cd
{
%barslot.guihandle.Image="Lightsaber:image_bariconcdinactive";
%barslot.guihandle.setAnimation("Lightsaber:anim_bariconcdinactive");
}
}
}
