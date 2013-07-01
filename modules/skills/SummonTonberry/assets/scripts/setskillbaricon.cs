function SummonTonberry::setskillbaricon(%this,%barslot)//state: 0=ready 1=cooldown
{
//need frames for:
//ready active, inactive
//cooldown active, inactive
if (%barslot.guihandle.Active)
{
if (!%barslot.skillstate)//ready
{
%barslot.guihandle.Image="SummonTonberry:image_bariconreadyactive";
%barslot.guihandle.setAnimation("SummonTonberry:anim_bariconreadyactive");
}
else//cd
{
%barslot.guihandle.Image="SummonTonberry:image_bariconcdactive";
%barslot.guihandle.setAnimation("SummonTonberry:anim_bariconcdactive");
}
}
else//inactive
{
if (!%barslot.skillstate)//ready
{
%barslot.guihandle.Image="SummonTonberry:image_bariconreadyinactive";
%barslot.guihandle.setAnimation("SummonTonberry:anim_bariconreadyinactive");
}
else//cd
{
%barslot.guihandle.Image="SummonTonberry:image_bariconcdinactive";
%barslot.guihandle.setAnimation("SummonTonberry:anim_bariconcdinactive");
}
}
}
