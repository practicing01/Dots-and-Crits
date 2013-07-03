function createtonberryskillbar()
{
//--- OBJECT WRITE BEGIN ---
%tonberryskillbar=new GuiControl(gui_tonberry_skillbar) {
   canSaveDynamicFields = "0";
   isContainer = "1";
   Profile = "gui_profile_modalless";
   HorizSizing = "relative";
   VertSizing = "relative";
   Position = "0 0";
   //Extent = "100 50";
   Extent = "1280 800";
   MinExtent = "1 1";
   canSave = "1";
   Visible = "1";
   Active = "0";
   tooltipWidth = "250";
   hovertime = "1000";

   new GuiButtonCtrl(movebutt) {
      canSaveDynamicFields = "0";
      isContainer = "0";
      Profile = "BlueButtonProfile";
      HorizSizing = "relative";
      VertSizing = "relative";
      Position = "590 375";
      Extent = "50 25";
      MinExtent = "1 1";
      canSave = "1";
      Visible = "1";
      Command = "gui_tonberry_skillbar.move();";
      Active = "1";
      tooltipWidth = "250";
      hovertime = "1000";
      text = "Move";
      groupNum = "-1";
      buttonType = "PushButton";
      useMouseEvents = "1";
   };
   new GuiButtonCtrl(followbutt) {
      canSaveDynamicFields = "0";
      isContainer = "0";
      Profile = "BlueButtonProfile";
      HorizSizing = "relative";
      VertSizing = "relative";
      Position = "640 375";
      Extent = "50 25";
      MinExtent = "1 1";
      canSave = "1";
      Visible = "1";
      Command = "gui_tonberry_skillbar.follow();";
      Active = "1";
      tooltipWidth = "250";
      hovertime = "1000";
      text = "Follow";
      groupNum = "-1";
      buttonType = "PushButton";
      useMouseEvents = "1";
   };
   new GuiButtonCtrl(snarebutt) {
      canSaveDynamicFields = "0";
      isContainer = "0";
      Profile = "BlueButtonProfile";
      HorizSizing = "relative";
      VertSizing = "relative";
      Position = "590 400";
      Extent = "50 25";
      MinExtent = "1 1";
      canSave = "1";
      Visible = "1";
      Command = "gui_tonberry_skillbar.snare();";
      Active = "1";
      tooltipWidth = "250";
      hovertime = "1000";
      text = "Snare";
      groupNum = "-1";
      buttonType = "PushButton";
      useMouseEvents = "1";
   };
   new GuiButtonCtrl(shankbutt) {
      canSaveDynamicFields = "0";
      isContainer = "0";
      Profile = "BlueButtonProfile";
      HorizSizing = "relative";
      VertSizing = "relative";
      Position = "640 400";
      Extent = "50 25";
      MinExtent = "1 1";
      canSave = "1";
      Visible = "1";
      Command = "gui_tonberry_skillbar.shank();";
      Active = "1";
      tooltipWidth = "250";
      hovertime = "1000";
      text = "Shank";
      groupNum = "-1";
      buttonType = "PushButton";
      useMouseEvents = "1";
   };
};
//--- OBJECT WRITE END ---
return %tonberryskillbar;
}
