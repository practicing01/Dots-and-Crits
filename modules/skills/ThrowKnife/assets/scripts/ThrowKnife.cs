exec("./ThrowKnifedecay.cs");
exec("./oncollision.cs");
exec("./onmovetocomplete.cs");
exec("./skill_ThrowKnife.cs");
exec("./setskillbaricon.cs");
exec("./useskill.cs");
exec("./ai.cs");

function ThrowKnife::displayskilldescription(%this,%skilllist,%slot)
{
%skilllist.setText("Throw a knife that deals damage.");
ThrowKnife.setskillbaricon(%slot);
}

function ThrowKnife::onlevelload(%this)
{
echo("loaded ThrowKnife ThrowKnifes");

if (!$view)
{
ThrowKnife.top_ThrowKnifeass=AssetDatabase.acquireAsset("ThrowKnife:image_topdown_ThrowKnife");
ThrowKnife.top_explosionass=AssetDatabase.acquireAsset("ThrowKnife:image_topdown_explosion");
}
else
{
ThrowKnife.side_ThrowKnifeass=AssetDatabase.acquireAsset("ThrowKnife:image_sideview_ThrowKnife");
ThrowKnife.side_explosionass=AssetDatabase.acquireAsset("ThrowKnife:image_sideview_explosion");
}

}

function ThrowKnife::create(%this)
{
echo("created ThrowKnife");
}

function ThrowKnife::destroy(%this)
{
echo("deleted ThrowKnife");
}

function ThrowKnife::unloadskill(%this)
{
echo("unloaded ThrowKnife");

if (!$view)
{
AssetDatabase.releaseAsset(ThrowKnife.top_ThrowKnifeass.getAssetId());
AssetDatabase.releaseAsset(ThrowKnife.top_explosionass.getAssetId());
}
else
{
AssetDatabase.releaseAsset(ThrowKnife.side_ThrowKnifeass.getAssetId());
AssetDatabase.releaseAsset(ThrowKnife.side_explosionass.getAssetId());
}

}

function ThrowKnife::transformobjects(%this,%playerindex)
{
return;
}
