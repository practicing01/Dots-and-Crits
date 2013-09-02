function DeusExTelum::load_radar(%this)
{

%size="0 0";
if (%this.ass_hollowarrow.getCellWidth()==0)
{
%size=%this.ass_hollowarrow.getImageSize();
}
else
{
%size.X=%this.ass_hollowarrow.getCellWidth();
%size.Y=%this.ass_hollowarrow.getCellHeight();
}

%guisprite_radar=new GuiSpriteCtrl()
{
Profile=gui_profile_modalless;
Position=0 SPC $resolution.Y-%size.Y;
Extent=%size;
Image="DeusExTelum:image_hollowArrow";
HorizSizing="relative";
VertSizing="relative";
class="class_DeusExTelum_Radar";
parentmodule=%this;
};

%this.gui_radar=new GuiControl()
{
Profile=gui_profile_modalless;
Position="0 0";
Extent=$resolution;
HorizSizing="relative";
VertSizing="relative";
};

%this.gui_radar.addGuiControl(%guisprite_radar);

Canvas.pushDialog(%this.gui_radar);

%guisprite_radar.rotate_radar();

}
