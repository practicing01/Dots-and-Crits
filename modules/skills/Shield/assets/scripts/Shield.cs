exec("./skill_Shield.cs");
exec("./setskillbaricon.cs");
exec("./useskill.cs");
exec("./ai.cs");
exec("./oncollision.cs");

function Shield::displayskilldescription(%this,%skilllist,%slot)
{
%skilllist.setText("Shield ahead in the direction you're facing.");
Shield.setskillbaricon(%slot);
}

function Shield::onlevelload(%this)
{
echo("Shield loaded");

Shield.shieldass=AssetDatabase.acquireAsset("Shield:image_shield0");

}

function Shield::create(%this)
{
echo("created Shield");
}

function Shield::destroy(%this)
{
echo("deleted Shield");
}

function Shield::unloadskill(%this)
{
echo("unloaded Shield");

AssetDatabase.releaseAsset(Shield.shieldass.getAssetId());

}

function Shield::transformobjects(%this,%playerindex)
{
return;
}
