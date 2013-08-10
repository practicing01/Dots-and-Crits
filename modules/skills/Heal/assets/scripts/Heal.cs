exec("./skill_Heal.cs");
exec("./setskillbaricon.cs");
exec("./useskill.cs");
exec("./ai.cs");

function Heal::displayskilldescription(%this,%skilllist,%slot)
{
%skilllist.setText("Heal over time.");
Heal.setskillbaricon(%slot);
}

function Heal::onlevelload(%this)
{
echo("Heal loaded");
}

function Heal::create(%this)
{
echo("created Heal");
}

function Heal::destroy(%this)
{
echo("deleted Heal");
}

function Heal::unloadskill(%this)
{
echo("unloaded Heal");
}

function Heal::transformobjects(%this,%playerindex)
{
return;
}
