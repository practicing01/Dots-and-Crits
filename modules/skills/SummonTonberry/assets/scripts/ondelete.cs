function class_tonberry::onDelete(%this)
{
cancel(%this.schedule_follow);
cancel(%this.schedule_snare);
%this.handle_attached_gui.delete();
}
