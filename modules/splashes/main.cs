exec("./assets/scripts/splashes.cs");

//splash screen logic here
//at end, schedule function to unload module
//and to load main menu module

function loadmainmenu()
{
$obj_mourningdovesoftsplash.stopTimer();

ModuleDatabase.unloadExplicit("splashes");
if (ConsoleDialog.isAwake()){Canvas.popDialog(ConsoleDialog);}
Canvas.pushDialog(gui_mainmenu);
Canvas.pushDialog(gui_skillbar);

}

$obj_mourningdovesoftsplash=new SceneObject()
{
class="class_mourningdovesoftsplash";
seconds_passed=0;
phase=0;
};

function class_sun::onMoveToComplete(%this)
{
$obj_mourningdovesoftsplash.phase=1;
$obj_mourningdovesoftsplash.seconds_passed=0;
}

function class_mourningdovesoftsplash::splashphases(%this)
{
if (%this.phase==0)
{
if (%this.seconds_passed==0)
{
sprite_blackscreen.SceneLayer=31;
sprite_mdsbg.setVisible(true);
sprite_mdsbg.SceneLayer=2;
sprite_mdsfg.setVisible(true);
sprite_mdsfg.SceneLayer=0;
compsprite_sun.setVisible(true);
compsprite_sun.SceneLayer=1;
sprite_mdssky.setVisible(true);
sprite_mdssky.SceneLayer=4;

compsprite_sun.Position="60 -47.5";

%mourningdovesound=alxPlay("splashes:audio_mourningdove");
compsprite_sun.AngularVelocity=15;
compsprite_sun.moveTo("0 0",20,true,false);

}
}
else if (%this.phase==1)
{
if (%this.seconds_passed==0)
{
sprite_mdsbg.setVisible(false);
sprite_mdsfg.setVisible(false);
compsprite_sun.setVisible(false);
sprite_mdssky.setVisible(false);

sprite_torquelogo.setVisible(true);
%torquelogosound=alxPlay("splashes:audio_torquewrench");
schedule(4000,0,"loadmainmenu");
}
else if (%this.seconds_passed>=3)
{
%this.phase=2;
%this.seconds_passed=-1;
}

}
else if (%this.phase==2)
{
if (%this.seconds_passed==0)
{
sprite_torquelogo.setVisible(false);
//more phases
}

}

%this.seconds_passed++;
}

$obj_mourningdovesoftsplash.startTimer("splashphases",1000);
