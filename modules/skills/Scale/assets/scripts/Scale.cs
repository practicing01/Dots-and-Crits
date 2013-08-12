exec("./skill_Scale.cs");
exec("./setskillbaricon.cs");
exec("./useskill.cs");
exec("./ai.cs");

function Scale::displayskilldescription(%this,%skilllist,%slot)
{
%skilllist.setText("Scale based on your position and mouse position.");
Scale.setskillbaricon(%slot);
}

function Scale::onlevelload(%this)
{
echo("Scale loaded");
}

function Scale::create(%this)
{
echo("created Scale");
}

function Scale::destroy(%this)
{
echo("deleted Scale");
}

function Scale::unloadskill(%this)
{
echo("unloaded Scale");
}

function Scale::transformobjects(%this,%playerindex)
{
return;
}
