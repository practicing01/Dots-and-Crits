$joypadbuttons=new SimSet();

for (%x=0;%x<32;%x++)
{
%button=new ScriptObject()
{
state=false;
name="button"@%x;
map=-1;
};

$joypadbuttons.add(%button);
}

%button=new ScriptObject()
{
state=false;
name="upov";
map=-1;
};
$joypadbuttons.add(%button);

%button=new ScriptObject()
{
state=false;
name="dpov";
map=-1;
};
$joypadbuttons.add(%button);

%button=new ScriptObject()
{
state=false;
name="lpov";
map=-1;
};
$joypadbuttons.add(%button);

%button=new ScriptObject()
{
state=false;
name="rpov";
map=-1;
};
$joypadbuttons.add(%button);

%button=new ScriptObject()
{
state=false;
name="upov2";
map=-1;
};
$joypadbuttons.add(%button);

%button=new ScriptObject()
{
state=false;
name="dpov2";
map=-1;
};
$joypadbuttons.add(%button);

%button=new ScriptObject()
{
state=false;
name="lpov2";
map=-1;
};
$joypadbuttons.add(%button);

%button=new ScriptObject()
{
state=false;
name="rpov2";
map=-1;
};
$joypadbuttons.add(%button);

function setjoybuttonstate(%buttonindex,%state)
{
$joypadbuttons.getObject(%buttonindex).state=%state;
}
