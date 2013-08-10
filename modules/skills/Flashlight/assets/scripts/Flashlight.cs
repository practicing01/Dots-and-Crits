exec("./skill_Flashlight.cs");
exec("./setskillbaricon.cs");
exec("./useskill.cs");
exec("./ai.cs");

function Flashlight::displayskilldescription(%this,%skilllist,%slot)
{
%skilllist.setText("Illuminate darkened areas.");
Flashlight.setskillbaricon(%slot);
}

function Flashlight::onlevelload(%this)
{
echo("Flashlight loaded");

Flashlight.flashlightass=AssetDatabase.acquireAsset("Flashlight:image_flashlight");

}

function Flashlight::create(%this)
{
echo("created Flashlight");
}

function Flashlight::destroy(%this)
{
echo("deleted Flashlight");
}

function Flashlight::unloadskill(%this)
{
echo("unloaded Flashlight");

AssetDatabase.releaseAsset(Flashlight.flashlightass.getAssetId());

}

function Flashlight::transformobjects(%this,%playerindex)
{
return;
}
