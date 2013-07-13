function bitweb::shufflegates(%this)
{

Audiere_Reset(%this.sound_gatemovement);
Audiere_Play(%this.sound_gatemovement,0,1.0);

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

//shuffle gates
for (%x=0;%x<%xchosengates.getCount();%x++)
{

%gate=%this.simset_gates.getObject(%xchosengates.getObject(%x).index);

if (getRandom(0,1))//left
{
if (getRandom(0,1)&&!%gate.leftgate.state)//open, also check if not already open
{
%gate.leftgate.state=true;
%gate.leftgate.clearCollisionShapes();
%gate.leftgate.setCollisionSuppress(true);
%gate.leftgate.playAnimation("bitweb:anim_beam_open");
}
else if (%gate.leftgate.state)//close, also check if not already closed
{
%gate.leftgate.state=false;
%gate.leftgate.createPolygonBoxCollisionShape(%this.gatecolboxsize,
%gate.leftgate.localpoint.X,%gate.leftgate.localpoint.Y);
%gate.leftgate.setCollisionSuppress(false);
%gate.leftgate.playAnimation("bitweb:anim_beam_close");
}
}
else//right
{
if (getRandom(0,1)&&!%gate.rightgate.state)//open
{
%gate.rightgate.state=true;
%gate.rightgate.clearCollisionShapes();
%gate.rightgate.setCollisionSuppress(true);
%gate.rightgate.playAnimation("bitweb:anim_beam_open");
}
else if (%gate.rightgate.state)//close
{
%gate.rightgate.state=false;
%gate.rightgate.createPolygonBoxCollisionShape(%this.gatecolboxsize,
%gate.rightgate.localpoint.X,%gate.rightgate.localpoint.Y);
%gate.rightgate.setCollisionSuppress(false);
%gate.rightgate.playAnimation("bitweb:anim_beam_close");
}
}

}

for (%x=0;%x<%ychosengates.getCount();%x++)
{

%gate=%this.simset_gates.getObject(%ychosengates.getObject(%x).index);

if (getRandom(0,1))//up
{
if (getRandom(0,1)&&!%gate.upgate.state)//open
{
%gate.upgate.state=true;
%gate.upgate.clearCollisionShapes();
%gate.upgate.setCollisionSuppress(true);
%gate.upgate.playAnimation("bitweb:anim_beam_open");
}
else if (%gate.upgate.state)//close
{
%gate.upgate.state=false;
%gate.upgate.createPolygonBoxCollisionShape(%this.gatecolboxsize,
%gate.upgate.localpoint.X,%gate.upgate.localpoint.Y);
%gate.upgate.setCollisionSuppress(false);
%gate.upgate.playAnimation("bitweb:anim_beam_close");
}
}
else//down
{
if (getRandom(0,1)&&!%gate.downgate.state)//open
{
%gate.downgate.state=true;
%gate.downgate.clearCollisionShapes();
%gate.downgate.setCollisionSuppress(true);
%gate.downgate.playAnimation("bitweb:anim_beam_open");
}
else if (%gate.downgate.state)//close
{
%gate.downgate.state=false;
%gate.downgate.createPolygonBoxCollisionShape(%this.gatecolboxsize,
%gate.downgate.localpoint.X,%gate.downgate.localpoint.Y);
%gate.downgate.setCollisionSuppress(false);
%gate.downgate.playAnimation("bitweb:anim_beam_close");
}
}

}

%xchosengates.deleteObjects();%xchosengates.delete();
%ychosengates.deleteObjects();%ychosengates.delete();

%this.schedule_shuffle.schedulehandle=schedule(20000,0,"bitweb::shufflegates",%this);
}
