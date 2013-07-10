function bitweb::shufflegates(%this)
{

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
if (getRandom(0,1))//open
{
%gate.leftgate.state=true;
%gate.leftgate.setCollisionSuppress(true);
%gate.leftgate.frame=0;
}
else//close
{
%gate.leftgate.state=false;
%gate.leftgate.setCollisionSuppress(false);
%gate.leftgate.frame=2;
}
}
else//right
{
if (getRandom(0,1))//open
{
%gate.rightgate.state=true;
%gate.rightgate.setCollisionSuppress(true);
%gate.rightgate.frame=0;
}
else//close
{
%gate.rightgate.state=false;
%gate.rightgate.setCollisionSuppress(false);
%gate.rightgate.frame=2;
}
}

}

for (%x=0;%x<%ychosengates.getCount();%x++)
{

%gate=%this.simset_gates.getObject(%ychosengates.getObject(%x).index);

if (getRandom(0,1))//up
{
if (getRandom(0,1))//open
{
%gate.upgate.state=true;
%gate.upgate.setCollisionSuppress(true);
%gate.upgate.frame=0;
}
else//close
{
%gate.upgate.state=false;
%gate.upgate.setCollisionSuppress(false);
%gate.upgate.frame=2;
}
}
else//down
{
if (getRandom(0,1))//open
{
%gate.downgate.state=true;
%gate.downgate.setCollisionSuppress(true);
%gate.downgate.frame=0;
}
else//close
{
%gate.downgate.state=false;
%gate.downgate.setCollisionSuppress(false);
%gate.downgate.frame=2;
}
}

}

%xchosengates.deleteObjects();%xchosengates.delete();
%ychosengates.deleteObjects();%ychosengates.delete();

%this.schedule_shuffle.schedulehandle=schedule(20000,0,"bitweb::shufflegates",%this);
}
