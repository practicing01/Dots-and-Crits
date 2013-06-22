exec("./skill_Portalgun.cs");
exec("./setskillbaricon.cs");
exec("./useskill.cs");
exec("./ai.cs");
exec("./oncollision.cs");
exec("./onmovetocomplete.cs");
exec("./projectiledecay.cs");
exec("./ontouchdown.cs");
exec("./portaloncollision.cs");

function Portalgun::displayskilldescription(%this,%skilllist,%slot)
{
%skilllist.setText("Portalgun to surprise or defend.");
Portalgun.setskillbaricon(%slot);
}

function Portalgun::onlevelload(%this)
{
echo("Portalgun loaded");

Portalgun.Portalgunass=AssetDatabase.acquireAsset("Portalgun:image_Portalgun");
Portalgun.portalinass=AssetDatabase.acquireAsset("Portalgun:image_portalin");
Portalgun.portaloutass=AssetDatabase.acquireAsset("Portalgun:image_portalout");
Portalgun.projectileinass=AssetDatabase.acquireAsset("Portalgun:image_projectilein");
Portalgun.projectileoutass=AssetDatabase.acquireAsset("Portalgun:image_projectileout");

Portalgun.customplayerfields=new SimSet();

for (%x=0;%x<$numofplayers;%x++)//one simobject per player, containing all custom fields for this skill
{
%fields=new SimObject()
{
portaltoshoot=0;//0 shoots the in portal, 1 shoots the out portal.  they cycle.  have to use this cus
//phone doesn't have lmb/rmb
mousecaptureobj=0;
portalinobj=0;
portaloutobj=0;
};

Portalgun.customplayerfields.add(%fields);

%fields.mousecaptureobj=new SceneObject()
{
size="1 1";
Position="0 0";
Visible="false";
Active="false";
class="class_Portalgun";
};
DotsandCritsscene.add(%fields.mousecaptureobj);

if (!%x)//player 0 casted
{
%fields.mousecaptureobj.setUseInputEvents(true);

DotsandCritswindow.addInputListener(%fields.mousecaptureobj);
scenewindow_player1.addInputListener(%fields.mousecaptureobj);
scenewindow_player2.addInputListener(%fields.mousecaptureobj);
}
else
{
$joycallbackobjlist.add(%fields.mousecaptureobj);
}

}

%size=0;
if (Portalgun.projectileinass.getCellWidth()==0)
{
%size=Portalgun.projectileinass.getImageSize();
}
else
{
%size.X=Portalgun.projectileinass.getCellWidth();
%size.Y=Portalgun.projectileinass.getCellHeight();
}

Portalgun.vectortable=new SimSet();

%degree=0;
%pos="0 0";
%dest="0 0";

for (%x=0;%x<=360;%x++)
{
%degree=%x;

%cx=%pos.X;
%cy=%pos.Y;

%c=mCos(mDegToRad(%degree));
%s=mSin(mDegToRad(%degree));

%dest="0 0";
%dest.X=%pos.X;
%dest.Y=%pos.Y+(%size.Y);

%dest.X-=%pos.X;
%dest.Y-=%pos.Y;
%xval=%dest.X*%c-%dest.Y*%s;
%yval=%dest.X*%s+%dest.Y*%c;
%dest.X=%xval+%pos.X;
%dest.Y=%yval+%pos.Y;

%dest=ScaleVectorToCam(%dest);
%vector=new SimObject()
{
x=%dest.X;
y=%dest.Y;
};
Portalgun.vectortable.add(%vector);

}

}

function Portalgun::create(%this)
{
echo("created Portalgun");
}

function Portalgun::destroy(%this)
{
echo("deleted Portalgun");
}

function Portalgun::unloadskill(%this)
{
echo("unloaded Portalgun");

AssetDatabase.releaseAsset(Portalgun.Portalgunass.getAssetId());
AssetDatabase.releaseAsset(Portalgun.portalinass.getAssetId());
AssetDatabase.releaseAsset(Portalgun.portaloutass.getAssetId());
AssetDatabase.releaseAsset(Portalgun.projectileinass.getAssetId());
AssetDatabase.releaseAsset(Portalgun.projectileoutass.getAssetId());

for (%x=0;%x<$numofplayers;%x++)
{
%customfieldobj=Portalgun.customplayerfields.getObject(%x);
%customfieldobj.mousecaptureobj.safeDelete();
if (isObject(%customfieldobj.portalinobj))
{
%customfieldobj.portalinobj.safeDelete();
}
if (isObject(%customfieldobj.portaloutobj))
{
%customfieldobj.portaloutobj.safeDelete();
}
}

Portalgun.customplayerfields.deleteObjects();
Portalgun.customplayerfields.delete();

Portalgun.vectortable.deleteObjects();
Portalgun.vectortable.delete();

}

function Portalgun::transformobjects(%this,%playerindex)
{
return;
}
