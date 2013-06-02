function gui_mainmenu::player1saveskillbar()
{
%f=new SaveFileDialog(gui_savefiledialog);
%f.Title="Save Player 1 Skill Bar";
%f.DefaultFile="skillbar.txt";
%filename=%f.execute();
if (%filename)
{
%filename=%f.fileName;
///////////////
%barfile=new FileObject();
%barfile.OpenForWrite(%filename);
for (%x=0;%x<$player1skillbar.getcount();%x++)
{
%slot=$player1skillbar.getObject(%x);
if (%slot.moduleid)
{
%barfile.writeline(%slot.moduleid.ModuleId);
echo(%slot.moduleid.ModuleId);
}
else{%barfile.writeline("0");echo("0");}
}
%barfile.close();
%barfile.delete();
//////////////
}else {%filename="";}
echo("filename:"@%filename);
%f.delete();
}

function gui_mainmenu::player2saveskillbar()
{
%f=new SaveFileDialog(gui_savefiledialog);
%f.Title="Save Player 2 Skill Bar";
%f.DefaultFile="skillbar2.txt";
%filename=%f.execute();
if (%filename)
{
%filename=%f.fileName;
///////////////
%barfile=new FileObject();
%barfile.OpenForWrite(%filename);
for (%x=0;%x<$player2skillbar.getcount();%x++)
{
%slot=$player2skillbar.getObject(%x);
if (%slot.moduleid)
{
%barfile.writeline(%slot.moduleid.ModuleId);
echo(%slot.moduleid.ModuleId);
}
else{%barfile.writeline("0");echo("0");}
}
%barfile.close();
%barfile.delete();
//////////////
}else {%filename="";}
echo("filename:"@%filename);
%f.delete();
}
