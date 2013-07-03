exec("./skill_SummonTonberry.cs");
exec("./setskillbaricon.cs");
exec("./useskill.cs");
exec("./ai.cs");
exec("./movebutt.cs");
exec("./followbutt.cs");
exec("./snarebutt.cs");
exec("./shankbutt.cs");
exec("./ontouchdown.cs");
exec("./../gui/gui_tonberry_skillbar.cs");
exec("./onmovetocomplete.cs");
exec("./ondelete.cs");
exec("./onanimationend.cs");
exec("./reattachgui.cs");

function SummonTonberry::displayskilldescription(%this,%skilllist,%slot)
{
%skilllist.setText("SummonTonberry ahead in the direction you're facing.");
SummonTonberry.setskillbaricon(%slot);
}

function SummonTonberry::onlevelload(%this)
{
echo("SummonTonberry loaded");

SummonTonberry.tonberryass=AssetDatabase.acquireAsset("SummonTonberry:image_tonberry");

SummonTonberry.tonberries=new SimSet();

}

function SummonTonberry::create(%this)
{
echo("created SummonTonberry");
}

function SummonTonberry::destroy(%this)
{
echo("deleted SummonTonberry");
}

function SummonTonberry::unloadskill(%this)
{
echo("unloaded SummonTonberry");

AssetDatabase.releaseAsset(SummonTonberry.tonberryass.getAssetId());

for (%x=0;%x<SummonTonberry.tonberries.getCount();%x++)
{
%tonberry=SummonTonberry.tonberries.getObject(%x);
if (isObject(%tonberry))
{
%tonberry.onDelete();
}
}
SummonTonberry.tonberries.deleteObjects();
SummonTonberry.tonberries.delete();

}

function SummonTonberry::transformobjects(%this,%playerindex)
{
return;
}

function class_tonberry::updatehealth(%this)
{
if (%this.health<=0){%this.onDelete();%this.safeDelete();}
}
