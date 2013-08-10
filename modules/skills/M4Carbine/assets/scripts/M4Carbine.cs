exec("./skill_M4Carbine.cs");
exec("./setskillbaricon.cs");
exec("./useskill.cs");
exec("./ai.cs");
exec("./ontouchdown.cs");

function M4Carbine::displayskilldescription(%this,%skilllist,%slot)
{
%skilllist.setText("Shoot with a chance to crit.");
M4Carbine.setskillbaricon(%slot);
}

function M4Carbine::onlevelload(%this)
{
echo("M4Carbine loaded");

%player1=$players.getObject(0);
%player2=$players.getObject(1);
if (%player1.ammo<10){%player1.ammo=10;}else if (%player1.ammo>10){%player1.ammo+=10;}
if (%player2.ammo<10){%player2.ammo=10;}else if (%player2.ammo>10){%player2.ammo+=10;}

M4Carbine.M4Carbineass=AssetDatabase.acquireAsset("M4Carbine:image_M4Carbine");

M4Carbine.customplayerfields=new SimSet();

for (%x=0;%x<$numofplayers;%x++)//one ScriptObject per player, containing all custom fields for this skill
{
%fields=new ScriptObject()
{
mousecaptureobj=0;
sound_m4_fire=0;
sound_m4_reload=0;
};

M4Carbine.customplayerfields.add(%fields);

%fields.mousecaptureobj=new SceneObject()
{
size="1 1";
Position="0 0";
Visible="false";
Active="false";
class="class_M4Carbine";
BodyType="static";
};
DotsandCritsscene.add(%fields.mousecaptureobj);

if (!%x)//player 0 casted
{
%fields.mousecaptureobj.setUseInputEvents(true);

DotsandCritswindow.addInputListener(%fields.mousecaptureobj);
scenewindow_player1.addInputListener(%fields.mousecaptureobj);
}
else
{
$joycallbackobjlist.add(%fields.mousecaptureobj);
}

%fields.sound_m4_fire=new audiere_soundhandle();
Audiere_OpenSound(%fields.sound_m4_fire,expandPath("./../audio/m4_fire.ogg"));

%fields.sound_m4_reload=new audiere_soundhandle();
Audiere_OpenSound(%fields.sound_m4_reload,expandPath("./../audio/m4_reload.ogg"));

}

}

function M4Carbine::create(%this)
{
echo("created M4Carbine");
}

function M4Carbine::destroy(%this)
{
echo("deleted M4Carbine");
}

function M4Carbine::unloadskill(%this)
{
echo("unloaded M4Carbine");

AssetDatabase.releaseAsset(M4Carbine.M4Carbineass.getAssetId());

for (%x=0;%x<$numofplayers;%x++)
{
%customfieldobj=M4Carbine.customplayerfields.getObject(%x);

Audiere_Stop(%customfieldobj.sound_m4_fire);
Audiere_Stop(%customfieldobj.sound_m4_reload);

%customfieldobj.mousecaptureobj.safeDelete();

}

M4Carbine.customplayerfields.deleteObjects();
M4Carbine.customplayerfields.delete();

}

function M4Carbine::transformobjects(%this,%playerindex)
{
return;
}
