function gui_mainmenu::player1loadskillbar()
{
%f=new OpenFileDialog(gui_openfiledialog);
%f.Title="Load Player 1 Skill Bar";
%f.DefaultFile="skillbar.txt";
%f.Filters="*.txt";
%f.MultipleFiles=false;
%f.MustExist=true;
%filename=%f.execute();
if (%filename)
{
%filename=%f.fileName;
echo("filename:"@%filename);
///////////////
%barfile=new FileObject();
%barfile.OpenForRead(%filename);

for (%x=0;%x<$player1skillbar.getcount();%x++)
{

%slot=$player1skillbar.getObject(%x);

%txtline=%barfile.readline();
if (%txtline$="0")
{
%slot.moduleid=0;
if (!$player1activeskillbarnibble)//first nibble active
{
if (%x<4)
{
%slot.guihandle.Image="DotsandCrits:image_noskillset";
%slot.guihandle.setAnimation("DotsandCrits:anim_noskillset");
}
else
{
%slot.guihandle.Image="DotsandCrits:image_noskillsetinactive";
%slot.guihandle.setAnimation("DotsandCrits:anim_noskillsetinactive");
}
}
else
{
if (%x<4)
{
%slot.guihandle.Image="DotsandCrits:image_noskillsetinactive";
%slot.guihandle.setAnimation("DotsandCrits:anim_noskillsetinactive");
}
else
{
%slot.guihandle.Image="DotsandCrits:image_noskillset";
%slot.guihandle.setAnimation("DotsandCrits:anim_noskillset");
}
}
}
else
{
%moduleid=ModuleDatabase.findModule(%txtline,"1");
if (%moduleid)
{
%slot.moduleid=%moduleid;
%slot.moduleid.ScopeSet.setskillbaricon(%slot);
echo(%slot.moduleid.ModuleId);
}
}
%slot.skillstate=0;
cancel(%slot.cdschedule);
%slot.cdschedule=0;
}
%barfile.close();
%barfile.delete();
//////////////
}else {%filename="";}
echo("filename:"@%filename);
%f.delete();
}

function gui_mainmenu::player2loadskillbar()
{
%f=new OpenFileDialog(gui_openfiledialog);
%f.Title="Load Player 2 Skill Bar";
%f.DefaultFile="skillbar2.txt";
%f.Filters="*.txt";
%f.MultipleFiles=false;
%f.MustExist=true;
%filename=%f.execute();
if (%filename)
{
%filename=%f.fileName;
echo("filename:"@%filename);
///////////////
%barfile=new FileObject();
%barfile.OpenForRead(%filename);

for (%x=0;%x<$player2skillbar.getcount();%x++)
{

%slot=$player2skillbar.getObject(%x);

%txtline=%barfile.readline();
if (%txtline$="0")
{
%slot.moduleid=0;
if (!$player2activeskillbarnibble)
{
if (%x<4)
{
%slot.guihandle.Image="DotsandCrits:image_noskillset";
%slot.guihandle.setAnimation("DotsandCrits:anim_noskillset");
}
else
{
%slot.guihandle.Image="DotsandCrits:image_noskillsetinactive";
%slot.guihandle.setAnimation("DotsandCrits:anim_noskillsetinactive");
}
}
else
{
if (%x<4)
{
%slot.guihandle.Image="DotsandCrits:image_noskillsetinactive";
%slot.guihandle.setAnimation("DotsandCrits:anim_noskillsetinactive");
}
else
{
%slot.guihandle.Image="DotsandCrits:image_noskillset";
%slot.guihandle.setAnimation("DotsandCrits:anim_noskillset");
}
}
}
else
{
%moduleid=ModuleDatabase.findModule(%txtline,"1");
if (%moduleid)
{
%slot.moduleid=%moduleid;
%slot.moduleid.ScopeSet.setskillbaricon(%slot);
echo(%slot.moduleid.ModuleId);
}
}
%slot.skillstate=0;
cancel(%slot.cdschedule);
%slot.cdschedule=0;
}
%barfile.close();
%barfile.delete();
//////////////
}else {%filename="";}
echo("filename:"@%filename);
%f.delete();
}
