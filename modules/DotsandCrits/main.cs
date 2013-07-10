function DotsandCrits::loadPreferences(%this)
{
exec("./scripts/defaultPreferences.cs");

if (isFile("preferences.cs"))
{
exec("preferences.cs");
}

}

function DotsandCrits::create(%this)
{

%this.loadPreferences();
exec("./scripts/constants.cs");
exec("./scripts/canvas.cs");
exec("./scripts/openal.cs");
exec("./scripts/console.cs");

initializeCanvas("Dots and Crits");

Canvas.BackgroundColor="black";
Canvas.UseBackgroundColor=true;

exec("./gui/guiProfiles.cs");

initializeOpenAL();
InitAudiere();

exec("./scripts/variables.cs");
exec("./scripts/initfunctions.cs");

exec( "./scenes/DotsandCritsscene/DotsandCritsscene.cs" );

createDotsandCritswindow();
createDotsandCritsscene();

DotsandCrits.add(TamlRead("./gui/ConsoleDialog.gui.taml"));
GlobalActionMap.bindCmd(keyboard,"tilde","toggleConsole();","");

ModuleDatabase.LoadExplicit("mainmenu");

ModuleDatabase.LoadExplicit("pausemenu");
GlobalActionMap.bindCmd(keyboard,"escape","togglepausemenu();","");

ModuleDatabase.LoadExplicit("skillbar");

$enableDirectInput=true;
activateDirectInput();
enableJoystick();

new RenderProxy(CannotRenderProxy)
{
Image="DotsandCrits:CannotRender";
};
DotsandCrits.add(CannotRenderProxy);

$camsize=DotsandCritswindow.getCameraSize();

ModuleDatabase.LoadExplicit("splashes");

}

function DotsandCrits::destroy(%this)
{
destroyDotsandCritswindow();
}
