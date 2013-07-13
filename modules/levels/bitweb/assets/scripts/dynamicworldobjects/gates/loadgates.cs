function bitweb::loadgates(%this)
{
%this.gatecolboxsize=ScaleVectorToCam("50 4");

%this.gateass=AssetDatabase.acquireAsset("bitweb:image_beam");

%this.simset_gates=new SimSet();

for (%y=0;%y<800;%y+=50)
{

for (%x=0;%x<1250;%x+=50)//15 because remainder of 1280/50=30  (30/2 for center alignment)
{

%upgate=new Sprite()
{
Position=ScalePositionVectorToCam((%x+25)+15 SPC %y+(%this.gateass.getCellHeight()/2));
Size=ScaleAssSizeVectorToCam(%this.gateass);
Image="bitweb:image_beam";
SceneLayer=16;
GravityScale=0;
SceneGroup=26;
BodyType="static";
Frame=2;
class="class_gate";
state=0;//closed
localpoint=0;
};
%upgate.localpoint=%upgate.getLocalPoint(%upgate.Position.X,
%upgate.Position.Y-ScaleVectorToCam("0 20").Y);

%upgate.setCollisionGroups(0,1);//0/1 players
DotsandCritsscene.add(%upgate);

%upgate.createPolygonBoxCollisionShape(%this.gatecolboxsize,
%upgate.localpoint.X,%upgate.localpoint.Y);

%upgate.setAngle(180);

%downgate=new Sprite()
{
Position=ScalePositionVectorToCam((%x+25)+15 SPC (%y+50)-(%this.gateass.getCellHeight()/2));
Size=ScaleAssSizeVectorToCam(%this.gateass);
Image="bitweb:image_beam";
SceneLayer=16;
GravityScale=0;
SceneGroup=26;
BodyType="static";
Frame=2;
class="class_gate";
state=0;//closed
localpoint=0;
};
%downgate.localpoint=%downgate.getLocalPoint(%downgate.Position.X,
%downgate.Position.Y-ScaleVectorToCam("0 20").Y);

%downgate.setCollisionGroups(0,1);//0/1 players
DotsandCritsscene.add(%downgate);

%downgate.createPolygonBoxCollisionShape(%this.gatecolboxsize,
%downgate.localpoint.X,%downgate.localpoint.Y);

%leftgate=new Sprite()
{
Position=ScalePositionVectorToCam((%x+15)+(%this.gateass.getCellHeight()/2) SPC %y+25);
Size=ScaleAssSizeVectorToCam(%this.gateass);
Image="bitweb:image_beam";
SceneLayer=16;
GravityScale=0;
SceneGroup=26;
BodyType="static";
Frame=2;
class="class_gate";
state=0;//closed
localpoint=0;
};
%leftgate.localpoint=%leftgate.getLocalPoint(%leftgate.Position.X,
%leftgate.Position.Y-ScaleVectorToCam("0 20").Y);

%leftgate.setCollisionGroups(0,1);//0/1 players
DotsandCritsscene.add(%leftgate);

%leftgate.createPolygonBoxCollisionShape(%this.gatecolboxsize,
%leftgate.localpoint.X,%leftgate.localpoint.Y);

%leftgate.setAngle(270);

%rightgate=new Sprite()
{
Position=ScalePositionVectorToCam((%x+50)+15-(%this.gateass.getCellHeight()/2) SPC %y+25);
Size=ScaleAssSizeVectorToCam(%this.gateass);
Image="bitweb:image_beam";
SceneLayer=16;
GravityScale=0;
SceneGroup=26;
BodyType="static";
Frame=2;
class="class_gate";
state=0;//closed
localpoint=0;
};
%rightgate.localpoint=%rightgate.getLocalPoint(%rightgate.Position.X,
%rightgate.Position.Y-ScaleVectorToCam("0 20").Y);

%rightgate.setCollisionGroups(0,1);//0/1 players
DotsandCritsscene.add(%rightgate);

%rightgate.createPolygonBoxCollisionShape(%this.gatecolboxsize,
%rightgate.localpoint.X,%rightgate.localpoint.Y);

%rightgate.setAngle(90);

%tile=new SceneObject()
{
size=ScaleVectorToCam("50 50");
Position=ScalePositionVectorToCam((%x+25)+15 SPC %y+25);
GravityScale=0;
SceneLayer=17;
SceneGroup=3;
BodyType="static";
class="class_tile";
upgate=%upgate;
downgate=%downgate;
leftgate=%leftgate;
rightgate=%rightgate;
};
DotsandCritsscene.add(%tile);

%this.simset_gates.add(%tile);

}

}

//make a simset containing all of the numbers
//randomly pick and remove from that set and add to a seperate set
//that seperate set will contain the chosen gates
%xgates=new SimSet();
%ygates=new SimSet();
%xchosengates=new SimSet();
%ychosengates=new SimSet();

for (%x=0;%x<%this.simset_gates.getCount();%x++)
{
%tmpgate=new ScriptObject()
{
index=%x;
};
%xgates.add(%tmpgate);
%ygates.add(%tmpgate);
}

for (%x=0;%x<%this.simset_gates.getCount()/2;%x++)
{
%randomgate=%xgates.getObject(getRandom(0,%xgates.getCount()-1));
%xchosengates.add(%randomgate);
%xgates.remove(%randomgate);

%randomgate=%ygates.getObject(getRandom(0,%ygates.getCount()-1));
%ychosengates.add(%randomgate);
%ygates.remove(%randomgate);
}

%xgates.deleteObjects();%xgates.delete();
%ygates.deleteObjects();%ygates.delete();

//shuffle gates, open cus it's init
for (%x=0;%x<%xchosengates.getCount();%x++)
{

%gate=%this.simset_gates.getObject(%xchosengates.getObject(%x).index);

if (getRandom(0,1))
{
%gate.leftgate.state=true;//open
%gate.leftgate.setCollisionSuppress(true);//let player through
%gate.leftgate.frame=0;
}
else
{
%gate.rightgate.state=true;//open
%gate.rightgate.setCollisionSuppress(true);//let player through
%gate.rightgate.frame=0;
}

}

for (%x=0;%x<%ychosengates.getCount();%x++)
{

%gate=%this.simset_gates.getObject(%ychosengates.getObject(%x).index);

if (getRandom(0,1))
{
%gate.upgate.state=true;//open
%gate.upgate.setCollisionSuppress(true);//let player through
%gate.upgate.frame=0;
}
else
{
%gate.downgate.state=true;//open
%gate.downgate.setCollisionSuppress(true);//let player through
%gate.downgate.frame=0;
}

}

%xchosengates.deleteObjects();%xchosengates.delete();
%ychosengates.deleteObjects();%ychosengates.delete();

}
