exec("./skill_teleport.cs");
exec("./setskillbaricon.cs");
exec("./useskill.cs");
exec("./ai.cs");

function Teleport::displayskilldescription(%this,%skilllist,%slot)
{
%skilllist.setText("Teleport ahead in the direction you're facing.");
Teleport.setskillbaricon(%slot);
}

function Teleport::onlevelload(%this)
{
echo("Teleport loaded");
}

function Teleport::create(%this)
{
echo("created Teleport");
}

function Teleport::destroy(%this)
{
echo("deleted Teleport");
}

function Teleport::unloadskill(%this)
{
echo("unloaded Teleport");
}

function Teleport::transformobjects(%this,%playerindex)
{
return;
}
